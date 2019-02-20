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
using System.IO;
using System.Text;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Features.KmzMaker;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio
{
    public class IptcGpsController : PictureDetailControllerBase
    {
        private IptcView iptcView;
        private ExifGpsView exifGpsView;

        private bool goToNextFileAfterSave;
        private bool processFilesInSubdirectories;
        
        private bool askForFileSave;
        private string lastGpsFile;

        private BackgroundWorker saveToAllWorker;
        private BackgroundWorker gpsBackgroundWorker;
        private BackgroundWorker gpsBackgroundWorker2;

        public IptcGpsController(MainForm form, IptcView iptcView, ExifGpsView exifGpsView) : base(form)
        {
            this.iptcView = iptcView;
            this.iptcView.EnterPressed += new EventHandler(Save_Click);
            this.iptcView.PageDownPressed += new EventHandler(NavigateNext_Click);
            this.iptcView.PageUpPressed += new EventHandler(NavigatePrev_Click);
            this.iptcView.DeletePressed += new EventHandler(Delete_Click);

            this.exifGpsView = exifGpsView;
            this.exifGpsView.EnterPressed += new EventHandler(Save_Click);
            this.exifGpsView.PageDownPressed += new EventHandler(NavigateNext_Click);
            this.exifGpsView.PageUpPressed += new EventHandler(NavigatePrev_Click);
            this.exifGpsView.DeletePressed += new EventHandler(Delete_Click);
            this.exifGpsView.CreateKmzClick += new EventHandler(exifGpsView_CreateKmzClick);
            this.exifGpsView.TagFromGpsLogClick += new EventHandler(exifGpsView_TagFromGpsLogClick);

            this.GoToNextFileAfterSave = Settings.Default.GoToNextPicture;

            saveToAllWorker = new BackgroundWorker();
            saveToAllWorker.WorkerReportsProgress = true;
            saveToAllWorker.DoWork += new DoWorkEventHandler(saveToAllWorker_DoWork);
            saveToAllWorker.ProgressChanged += new ProgressChangedEventHandler(this.mainForm.WorkProgressChanged);
            saveToAllWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(saveToAllWorker_RunWorkerCompleted);

            gpsBackgroundWorker = new BackgroundWorker();
            gpsBackgroundWorker.WorkerReportsProgress = true;
            gpsBackgroundWorker.DoWork += new DoWorkEventHandler(gpsBackgroundWorker_DoWork);
            gpsBackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.mainForm.WorkProgressChanged);
            gpsBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(gpsBackgroundWorker_RunWorkerCompleted);
          
            gpsBackgroundWorker2 = new BackgroundWorker();
            gpsBackgroundWorker2.WorkerReportsProgress = true;
            gpsBackgroundWorker2.DoWork += new DoWorkEventHandler(gpsBackgroundWorker2_DoWork);
            gpsBackgroundWorker2.ProgressChanged += new ProgressChangedEventHandler(this.mainForm.WorkProgressChanged);
            gpsBackgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(gpsBackgroundWorker2_RunWorkerCompleted);
        }

        #region file navigation from views
        private void Delete_Click(object sender, EventArgs e)
        {
            FireNavigateFiles(NavigateFileOperation.Delete);
        }

        private void NavigatePrev_Click(object sender, EventArgs e)
        {
            FireNavigateFiles(NavigateFileOperation.Previous);
        }

        private void NavigateNext_Click(object sender, EventArgs e)
        {
            FireNavigateFiles(NavigateFileOperation.Next);
        }
        #endregion

        public override RequestFileChangeResult RequestFileChange()
        {
            if (!askForFileSave)
                return RequestFileChangeResult.Close;
            if (this.currentPicture == null)
                return RequestFileChangeResult.Close;
            if (!this.currentPicture.ExistFile)
                return RequestFileChangeResult.Close;
            IptcModel iptcModel = iptcView.GetModel();
            ExifGpsModel exifGpsModel = exifGpsView.GetModel();
            if (!iptcModel.PendingUpdates && !exifGpsModel.PendingUpdates)
                return RequestFileChangeResult.Close;
            if (!isDataLoaded)
                return RequestFileChangeResult.Close;

            DialogResult r = MessageBox.Show("Save changes to this picture?", "Iptc and Gps Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (r == DialogResult.Cancel)
                return RequestFileChangeResult.DoNotClose;

            if (r == DialogResult.Yes)
            {
                mainForm.WaitCursor(true);
                SaveToPicture(currentPicture, false);
                mainForm.WaitCursor(false);
                return RequestFileChangeResult.CloseAndSave;
            }

            askForFileSave = false;
            return RequestFileChangeResult.Close;
        }

        #region save
        public void Save_Click(object sender, EventArgs e)
        {
            if ( currentPicture == null )
                return;

            mainForm.WaitCursor(true);

            SaveToPicture(currentPicture, true);

            askForFileSave = false;
            FireDataChanged();

            if (this.goToNextFileAfterSave)
                FireNavigateFiles(NavigateFileOperation.Next);

            mainForm.WaitCursor(false);            
        }

        private bool SaveToPicture(PictureMetaData pic, bool commit)
        {
            // todo: die worker und modelle können mehrfach verwendet werden! 
            IptcWorker iptcWorker = new IptcWorker();
            ExifGpsWorker exifGpsWorker = new ExifGpsWorker();

            IptcModel iptcModel = iptcView.GetModel();
            ExifGpsModel exifGpsModel = exifGpsView.GetModel();

            bool somethingChanged = false;
            if ( iptcWorker.ProcessFile(pic,iptcModel) )
                somethingChanged = true;
            if (exifGpsWorker.ProcessFile(pic,exifGpsModel) )
                somethingChanged = true;
            
            if ( iptcModel.PendingUpdates )
                iptcModel.UpdateSettings();
            
            if ( somethingChanged && commit )
                if (!pic.SaveChanges())
                    return this.ShowFileVanishedMsg(pic.Filename);

            return true;
        }

        public void SaveToAll_Click(object sender, EventArgs e)
        {
            if (saveToAllWorker.IsBusy)
                return;

            IptcModel model = iptcView.GetModel();
            if ( model.KeywordChecked )
            {
                if ( model.KeywordsChecked.Count != 0 || model.KeywordsUnchecked.Count != 0 )
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("You are going to change the keywords of ALL selected files!");
                    sb.AppendLine();
                    if (model.KeywordsChecked.Count != 0)
                    {
                        string checkedKeywords = String.Join(", ", model.KeywordsChecked.ToArray());
                        sb.Append("Adding ");
                        sb.AppendLine(checkedKeywords);
                    }
                    if (model.KeywordsUnchecked.Count != 0)
                    {
                        string uncheckedKeywords = String.Join(", ", model.KeywordsUnchecked.ToArray());
                        sb.Append("Removing ");
                        sb.AppendLine(uncheckedKeywords);
                    }
                    sb.AppendLine();
                    sb.Append("Are you sure?");

                    if ( MessageBox.Show(sb.ToString(),mainForm.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
            }

            PauseOtherWorker();

            List<string> filenames = this.GetAllFileList(this.processFilesInSubdirectories);
            saveToAllWorker.RunWorkerAsync(filenames);
        }

        void saveToAllWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> filenames = (List<string>) e.Argument;

            BackgroundWorker worker = (BackgroundWorker) sender;
            worker.ReportProgress(0);

            int i = 0;
            foreach (string filename in filenames)
            {
                i++;
                PictureMetaData pmd;
                if (this.currentPicture != null
                    && this.currentPicture.Filename == filename)
                    pmd = currentPicture;
                else
                {
                    if (File.Exists(filename))
                        pmd = new PictureMetaData(filename);
                    else
                    {
                        worker.ReportProgress(i * 100 / filenames.Count);
                        continue;
                    }
                }

                bool breakForeach = SaveToPicture(pmd, true) == false;

                if (pmd != currentPicture)
                    pmd.Close();

                if (breakForeach)
                    break;

                worker.ReportProgress(i * 100 / filenames.Count);
            }
        }
        void saveToAllWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FireDataChanged();

            mainForm.WorkFinished();

            RestartOtherWorker();
        }
        #endregion

        #region Refresh/Clear Data and Settings
        public override void ClearData()
        {
            base.ClearData();

            iptcView.SetModel(new IptcModel());
            exifGpsView.SetModel(new ExifGpsModel());
        }

        public override void RefreshData()
        {
            base.RefreshData();

            iptcView.SetModel(new IptcModel(currentPicture));
            exifGpsView.SetModel(new ExifGpsModel(currentPicture));

            askForFileSave = true;
        }

        public override void RefreshSettings()
        {
            base.RefreshSettings();

            iptcView.RefreshSettings();
        }
        #endregion

        #region the gps buttons
        private struct GpsWorkerArguemnts
        {
            public GpsLog log;
            public DateTime firstPicture;
            public DateTime lastPicture;
            public List<PictureMetaData> pictures;

            public GpsWorkerArguemnts(GpsLog log, DateTime firstPicture, DateTime lastPicture, List<PictureMetaData> pictures)
            {
                this.log = log;
                this.firstPicture = firstPicture;
                this.lastPicture = lastPicture;
                this.pictures = pictures;
            }

            public GpsWorkerArguemnts(GpsLog log)
            {
                this.log = log;
                this.pictures = null;
                this.firstPicture = DateTime.Now;
                this.lastPicture = DateTime.Now;
            }
        }

        void exifGpsView_TagFromGpsLogClick(object sender, EventArgs e)
        {
            // the filename of the gps log
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open gps nmea file";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog(mainForm) != DialogResult.OK)
                return;

            this.lastGpsFile = ofd.FileName;

            // read the gps log
            mainForm.WaitCursor(true);
            GpsLog log = GpsLogFactory.FromFile(ofd.FileName);
            mainForm.WaitCursor(false);

            // empty log -> exit
            if (log.Count == 0)
            {
                MessageBox.Show("The gps log file is empty or PhotoTagStudio cannot read it.", mainForm.Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ask for gps time offset
            PictureGpsOffsetDialog d = new PictureGpsOffsetDialog(currentPicture, log.FirstTime.Value, log.LastTime.Value);
            d.Offset = Settings.Default.GPSTimeOffset;
            if (d.ShowDialog(mainForm) != DialogResult.OK)
                return;

            // set offset to gps log
            Settings.Default.GPSTimeOffset = d.Offset;
            log.Offset = d.Offset;

            PauseOtherWorker();
            gpsBackgroundWorker.RunWorkerAsync( new GpsWorkerArguemnts(log) );
        }

        void gpsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker) sender;
            backgroundWorker.ReportProgress(0);

            GpsWorkerArguemnts args = (GpsWorkerArguemnts) e.Argument;

            List<string> filenames = this.GetAllFileList(false);

            // compute the timespan of all pictures
            DateTime firstPicture = new DateTime(4000, 1, 1);
            DateTime lastPicture = new DateTime(1, 1, 1);
            List<PictureMetaData> pictures = new List<PictureMetaData>();
            int i = 0;
            foreach (string filename in filenames)
            {
                i++;
                PictureMetaData pmd;
                if (this.currentPicture != null
                    && this.currentPicture.Filename == filename)
                    pmd = currentPicture;
                else
                    pmd = new PictureMetaData(filename);

                if (pmd.ExifOriginalDateTime.HasValue)
                {
                    DateTime time = pmd.ExifOriginalDateTime.Value;

                    if (time > lastPicture)
                        lastPicture = time;
                    if (time < firstPicture)
                        firstPicture = time;

                    pictures.Add(pmd);
                }
                backgroundWorker.ReportProgress(i * 100 / filenames.Count);
            }

            e.Result = new GpsWorkerArguemnts(args.log, firstPicture, lastPicture, pictures);
        }

        void gpsBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GpsWorkerArguemnts args = (GpsWorkerArguemnts)e.Result;

            mainForm.WorkFinished();

            // ask the user: do it now?
            string text =
                String.Format(
                    "The GPS time is between {0} and {1}.\nThe picture time is between {2} and {3} ({4} and {5}).\n\nContinue?",
                    args.log.FirstTime,
                    args.log.LastTime,
                    args.firstPicture.Add(args.log.Offset),
                    args.lastPicture.Add(args.log.Offset),
                    args.firstPicture,
                    args.lastPicture);
            if (MessageBox.Show(text, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               gpsBackgroundWorker2.RunWorkerAsync(args);
            }
            else
            {
                foreach (PictureMetaData pmd in args.pictures)
                    if (pmd != currentPicture)
                        pmd.Close();
                RestartOtherWorker();
            }
        }

        void gpsBackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker)sender;
            backgroundWorker.ReportProgress(0);

            GpsWorkerArguemnts args = (GpsWorkerArguemnts)e.Argument;
            
            int i = 0;
            foreach (PictureMetaData pmd in args.pictures)
            {
                i++;
                UpdateGpsData(pmd, args.log);

                if (pmd != currentPicture)
                    pmd.Close();
                backgroundWorker.ReportProgress(i * 100 / args.pictures.Count);
            }


        }

        void gpsBackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FireDataChanged();
            mainForm.WorkFinished();
            RestartOtherWorker();
        }

        private void UpdateGpsData(PictureMetaData picture, GpsLog log)
        {
            if (picture.ExifOriginalDateTime.HasValue)
            {
                GpsLogEntry entry = log.GetNearestEntry(picture.ExifOriginalDateTime.Value);
                if (entry != null)
                {
                    picture.GpsLatitude = new GpsCoordinate(entry.Latitude);
                    picture.GpsLongitude = new GpsCoordinate(entry.Longitude);
                    picture.GpsLatitudeRef = entry.Latitude >= 0 ? "N" : "S";
                    picture.GpsLongitudeRef = entry.Longitude >= 0 ? "E" : "W";
                    picture.GpsDateTimeStamp = entry.Time;

                    picture.SaveChanges();
                }
            }
        }

        void exifGpsView_CreateKmzClick(object sender, EventArgs e)
        {
            KmzMakerForm f = new KmzMakerForm(currentPicture, currentDirectory, new GetAllFilesDelegate(this.GetAllFileList));
            f.GpsRouteFile = lastGpsFile;
            if (f.ShowDialog(mainForm) == DialogResult.OK)
                if (f.GpsRouteFile != "")
                    lastGpsFile = f.GpsRouteFile;
        }
        #endregion

        #region properties
        public bool GoToNextFileAfterSave
        {
            get { return goToNextFileAfterSave; }
            set
            {
                goToNextFileAfterSave = value;
                Settings.Default.GoToNextPicture = goToNextFileAfterSave;
            }
        }
        public bool ProcessFilesInSubdirectories
        {
            get { return processFilesInSubdirectories; }
            set { processFilesInSubdirectories = value; }
        }
        #endregion
    }
}
