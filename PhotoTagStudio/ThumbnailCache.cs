#region Copyright (C) 2005-2008 Benjamin Schröter <benjamin@irgendwie.net>
//
// This file is part of PhotoTagStudio
//
// PhotoTagStudio is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// PhotoTagStudio is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with PhotoTagStudio; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, 5th Floor, Boston, MA 02110-1301 USA.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Schroeter.Photo;

namespace Schroeter.PhotoTagStudio
{
    public class ThumbnailCache
    {
        private BackgroundWorker backgroundWorker;

        private Dictionary<string, Image> images;
        private IStatusDisplay statusDisplay;

        private string currentPath;
        private Thread singleWorker;
        private Semaphore sema;

        private Size thumbnailSize;

        public ThumbnailCache()
        {
            this.sema = new Semaphore(1, 1);
            images = new Dictionary<string, Image>();

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);

        }

        #region properties
        public Size ThumbnailSize
        {
            get { return thumbnailSize; }
            set { thumbnailSize = value; }
        }

        public string CurrentPath
        {
            get { return currentPath; }
            set { currentPath = value; }
        }
        #endregion

        public void SetStatusDisplay(IStatusDisplay statusDisplay)
        {
            this.statusDisplay = statusDisplay;
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(statusDisplay.WorkProgressChanged);
        }

        private bool ExistThumbnail(string name)
        {
            return images.ContainsKey(name.ToLower());
        }
    
        public void CreateAllThumbnails()
        {
            CreateAllThumbnails(CurrentPath);
        }
        public void CreateAllThumbnails(string path)
        {
            Cancel();

            images = new Dictionary<string, Image>();
            CurrentPath = path;

            ReCreateAllThumbnails();
        }

        public void ReCreateAllThumbnails()
        {
            if (backgroundWorker.IsBusy)
                return;

            this.sema = new Semaphore(1, 1);
            statusDisplay.WorkFinished();

            if (!CurrentPath.StartsWith("::"))
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        #region backgroundWorker
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(CurrentPath);
            FileInfo[] files = di.GetFiles("*.jpg");

            BackgroundWorker worker = (BackgroundWorker) sender;
            worker.ReportProgress(0);

            int c = 0;
            foreach (FileInfo fi in files)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                if (!ExistThumbnail(fi.FullName))
                {
                    CreateThumbnail(fi.FullName);
                }
                else
                {
                    Image i = images[fi.FullName.ToLower()];
                    if (i.Width < thumbnailSize.Width && i.Height < thumbnailSize.Height)
                    {
                        CreateThumbnail(fi.FullName);
                    }
                }

                c++;
                worker.ReportProgress((c*100)/files.Length);
            }

            worker.ReportProgress(100);
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusDisplay.WorkFinished();
        }

        #endregion

        public bool Cancel()
        {
            bool b = false;

            if ( backgroundWorker.IsBusy )
            {
                backgroundWorker.CancelAsync();
                while (backgroundWorker.IsBusy)
                {
                    // Keep UI messages moving, so the form remains 
                    // responsive during the asynchronous operation.
                    Application.DoEvents();
                }

                b = true;
            }

            if (singleWorker != null && singleWorker.IsAlive)
            {
                singleWorker.Abort();
                singleWorker.Join();
                b = true;
            }

            statusDisplay.WorkFinished();
            
            return b;
        }

        public delegate void CreateThumbnailCallback(string name, Image thumbnail);
        public bool GetThumbnail(string name, CreateThumbnailCallback callback)
        {
            if ( ExistThumbnail(name) )
            {
                Image i = images[name.ToLower()];
                if (i.Width < thumbnailSize.Width && i.Height < thumbnailSize.Height)
                {
                    // 1st callback with wrong (lower) size
                    callback(name, i);
                    
                    // then generate the new (better) thumbnail
                    if ( singleWorker != null && singleWorker.IsAlive )
                        singleWorker.Abort();
                    singleWorkerName = name;
                    singleWorkerCallback = callback;  // and do a 2nd callback with the better thumbnail with a higher size
                    singleWorker = new Thread(this.SingleWorkerDoWork);
                    singleWorker.Name = "Thumbnail single worker";
                    singleWorker.Priority = ThreadPriority.BelowNormal;
                    singleWorker.Start();

                    return true;
                }
                else
                {
                    callback(name, i);
                    return false;
                }
            }
            else
            {
                callback(name, CreateThumbnail(name));
                return false;
            }
        }

        private string singleWorkerName;
        private CreateThumbnailCallback singleWorkerCallback;        
        private void SingleWorkerDoWork()
        {
            Image i = CreateThumbnail(singleWorkerName);
            singleWorkerCallback(singleWorkerName, i);
        }
        
        private Image CreateThumbnail(string name)
        {           
            name = name.ToLower();
            Image i = null;
            Image iRes = null;
            try
            {
                FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
                i = Image.FromStream(fs);

                double pHeight = (double)i.Height / thumbnailSize.Height;
                double pWidth = (double)i.Width / thumbnailSize.Width;
                if (pHeight > pWidth)
                    iRes = ImageResize.ConstrainProportions(i, thumbnailSize.Height, ImageResize.Dimensions.Height);
                else
                    iRes = ImageResize.ConstrainProportions(i, thumbnailSize.Width, ImageResize.Dimensions.Width);

                fs.Close();
                fs.Dispose();

                sema.WaitOne();
                if (images.ContainsKey(name))
                    images[name] = iRes;
                else
                    images.Add(name, iRes);
                sema.Release();
            }
            catch
            {}
            
            return iRes;
        }
        
        public void Clear()
        {
            images.Clear();
        }
    }
}