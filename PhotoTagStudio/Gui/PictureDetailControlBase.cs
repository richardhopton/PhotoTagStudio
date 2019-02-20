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
using System.Threading;
using System.Windows.Forms;
using Schroeter.Photo;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class PictureDetailControlBase : UserControl, IPictureDetailControllerBase
    {
        protected bool isDataLoaded;

        public event DirectoryChanged DirectoryChangedEvent;
        protected void FireDirectoryChanged(bool withSubdirs)
        {
            if (this.DirectoryChangedEvent != null)
                this.DirectoryChangedEvent(withSubdirs);
        }

        public event DataChanged DataChangedEvent;
        protected void FireDataChanged()
        {
            if (this.DataChangedEvent != null)
                this.DataChangedEvent();
        }

        public event NavigateFiles NavigateFilesEvent;
        protected void FireNavigateFiles(NavigateFileOperation operation)
        {
            if (this.NavigateFilesEvent != null)
                NavigateFilesEvent(operation);
        }

        public event DirectoryNameChanged DirectoryNameChangedEvent;
        protected void FireDirectoryNameChanged(string navigateTo)
        {
            if (this.DirectoryNameChangedEvent != null)
                this.DirectoryNameChangedEvent(navigateTo);
        }

        #region Get all files / directories

        private GetAllFilesDelegate getAllFilesDelegate;
        private GetAllFilesDelegate getAllDirectoryDelegate;
        public void SetGetAllFilesDelegate(GetAllFilesDelegate getAllFilesDelegate, GetAllFilesDelegate getAllDirectoryDelegate)
        {
            this.getAllFilesDelegate = getAllFilesDelegate;
            this.getAllDirectoryDelegate = getAllDirectoryDelegate;
        }

        protected List<string> GetAllFileList(bool subdirectories)
        {
            if (this.getAllFilesDelegate == null)
                return new List<string>();
            else
                return this.getAllFilesDelegate(subdirectories);
        }
        protected List<string> GetAllDirectoryList(bool subdirectories)
        {
            if (this.getAllDirectoryDelegate == null)
                return new List<string>();
            else
                return this.getAllDirectoryDelegate(subdirectories);
        }
        #endregion

        protected PictureMetaData currentPicture;
        protected string currentDirectory;

        public PictureDetailControlBase()
        {
            InitializeComponent();
            currentPicture = null;
        }

        public void UpdatePicture(PictureMetaData picture)
        {
            isDataLoaded = false;
            
            if (this.currentPicture != null
                && picture != null
                && this.currentPicture.Filename == picture.Filename)
                return;

            this.currentPicture = picture;

            if (this.currentPicture == null)
                this.ClearData();
            else
                this.RefreshData();
        }
        
        public virtual void UpdateDirectory(string path)
        {
            currentDirectory = path;
        }
        
        private delegate void SimpleDelegate();
        private Thread DataChangeThread;
        private bool RefreshCalledWhileInvisible = false;

        protected virtual void ClearMyData() { }
        public void ClearData()
        {
            if (DataChangeThread != null)
                if (DataChangeThread.ThreadState == ThreadState.Running)
                    DataChangeThread.Abort();

            DataChangeThread = new Thread(this.ClearDataWorker);
            DataChangeThread.Name = "ClearData of " + this.GetType();
            DataChangeThread.Start();
        }
        private void ClearDataWorker()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new SimpleDelegate(this.ClearMyData));
            }
            else
            {
                this.ClearMyData();
            }
        }
        protected virtual void RefreshMyData() { }
        public void RefreshData()
        {
            if (DataChangeThread != null)
                if (DataChangeThread.ThreadState == ThreadState.Running)
                    DataChangeThread.Abort();

            if (this.Visible)
            {
                DataChangeThread = new Thread(this.RefreshDataWorker);
                DataChangeThread.Name = "RefreshData of " + this.GetType();
                DataChangeThread.Start();
            }
            else
                this.RefreshCalledWhileInvisible = true;
        }
        private void RefreshDataWorker()
        {
            if (this.InvokeRequired)
            {
                isDataLoaded = true;
                this.Invoke(new SimpleDelegate(this.RefreshMyData));
            }
            else
            {
                isDataLoaded = true;
                this.RefreshMyData();                
            }
        }

        protected virtual void RefreshMySettings() {}
        public void RefreshSettings()
        {
            this.RefreshMySettings();
        }

        private void PictureDetailControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && this.RefreshCalledWhileInvisible)
            {
                DataChangeThread = new Thread(this.RefreshDataWorker);
                DataChangeThread.Name = "RefrehData (visible changed) of " + this.GetType();
                DataChangeThread.Start();
                this.RefreshCalledWhileInvisible = false;
            }
        }

        public virtual RequestFileChangeResult RequestFileChange()
        {
            return RequestFileChangeResult.Close;
        }
        
        public PictureMetaData Picture
        {
            get
            {
                return currentPicture;
            }
        }

        #region stop and restart all other work
        bool pictureDisplayWasWorking;
        protected void StopOtherWorker()
        {
            MainForm f = (MainForm)this.FindForm();
            f.pictureDisplay.StopAllWork();
            pictureDisplayWasWorking = false;
        }
        
        protected void PauseOtherWorker()
        {
            MainForm f = (MainForm)this.FindForm();
            pictureDisplayWasWorking = f.pictureDisplay.StopAllWork();
        }
        
        protected void RestartOtherWorker()
        {
            if (pictureDisplayWasWorking)
            {
                MainForm f = (MainForm)this.FindForm();
                f.pictureDisplay.ReCreateAllThumbnails();
                pictureDisplayWasWorking = false;
            }
        }
        #endregion

        protected bool ShowFileVanishedMsg(string filename)
        {
            return MessageBox.Show(String.Format("The file {0} has vanished. Cannot save changes.", filename),"PhotoTagStudio",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1) == DialogResult.OK;
        }
    }
}