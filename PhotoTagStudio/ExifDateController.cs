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
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio
{
    public class ExifDateController : PictureDetailControllerBase
    {
        private ExifDateView view;

        private bool goToNextFileAfterSave;
        private bool processFilesInSubdirectories;
        
        private BackgroundWorker saveToAllWorker;
        
        public ExifDateController(MainForm form, ExifDateView view) : base(form)
        {
            this.view = view;
            view.SelectionChanged += UpdatePreviews;

            this.GoToNextFileAfterSave = Settings.Default.GoToNextPicture;

            saveToAllWorker = new BackgroundWorker();
            saveToAllWorker.WorkerReportsProgress = true;
            saveToAllWorker.DoWork += new DoWorkEventHandler(saveToAllWorker_DoWork);
            saveToAllWorker.ProgressChanged += new ProgressChangedEventHandler(this.mainForm.WorkProgressChanged);
            saveToAllWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(saveToAllWorker_RunWorkerCompleted);
        }

        #region save
        public void Save_Click(object sender, EventArgs e)
        {
            if (currentPicture == null)
                return;

            mainForm.WaitCursor(true);

            SaveToPicture(currentPicture, true);

            FireDataChanged();

            if (this.goToNextFileAfterSave)
                FireNavigateFiles(NavigateFileOperation.Next);

            mainForm.WaitCursor(false);
        }

        private bool SaveToPicture(PictureMetaData pic, bool commit)
        {
            // todo: die worker und modelle können mehrfach verwendet werden! 
            ExifDateWorker worker = new ExifDateWorker();
            ExifDateModel model = view.GetModel();

            if (worker.ProcessFile(pic, model) && commit)
                if (!pic.SaveChanges())
                    return this.ShowFileVanishedMsg(pic.Filename);

            return true;
        }

        public void SaveToAll_Click(object sender, EventArgs e)
        {
            if (saveToAllWorker.IsBusy)
                return;

            PauseOtherWorker();

            List<string> filenames = this.GetAllFileList(this.processFilesInSubdirectories);
            saveToAllWorker.RunWorkerAsync(filenames);
        }

        private void saveToAllWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> filenames = (List<string>)e.Argument;

            BackgroundWorker worker = (BackgroundWorker)sender;
            worker.ReportProgress(0);

            int i = 0;
            foreach (string filename in filenames)
            {
                i++;
                PictureMetaData pmd;
                if (this.currentPicture != null && this.currentPicture.Filename == filename)
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
        private void saveToAllWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FireDataChanged();

            mainForm.WorkFinished();

            RestartOtherWorker();
        }
        #endregion

        #region preview
        private void UpdatePreviews()
        {
            UpdatePreviews(null, null);
        }
        private void UpdatePreviews(object sender, EventArgs e)
        {            
            if ( currentPicture == null )
            {
                view.labSourcePreview.Text = "";
                view.labTargetPreview.Text = "";
            }
            else
            {
                // label source
                DateTime date = DateTime.MinValue;
                bool show = false;
                switch(view.GetModel().SourceField)
                {
                    case ExifDateFields.ExifImageDateTime:
                        show = true;
                        if (currentPicture.ExifImageDateTime.HasValue)
                            date = currentPicture.ExifImageDateTime.Value;
                        break;
                    case ExifDateFields.ExifPhotoDateTimeOriginal:
                        show = true;
                        if ( currentPicture.ExifOriginalDateTime.HasValue )
                            date = currentPicture.ExifOriginalDateTime.Value;
                        break;
                    case ExifDateFields.ExifPhotoDateTimeDigitized:
                        show = true;
                        if (currentPicture.ExifDigitizedDateTime.HasValue)
                            date = currentPicture.ExifDigitizedDateTime.Value;
                        break;
                    case ExifDateFields.ExifGpsInfoDateTimeStamp:
                        show = true;
                        if (currentPicture.GpsDateTimeStamp.HasValue)
                            date = currentPicture.GpsDateTimeStamp.Value;
                        break;
                    case ExifDateFields.IptcCreated:
                        show = true;
                        if (currentPicture.IptcDateTimeCreated.HasValue)
                            date = currentPicture.IptcDateTimeCreated.Value;
                        break;
                }

                if (show)
                {
                    if (date == DateTime.MinValue)
                        view.labSourcePreview.Text = "no value";
                    else
                        view.labSourcePreview.Text = date.ToString(GuiUtils.GetShortDateLongTimeFormatPattern());
                }
                else
                    view.labSourcePreview.Text = "";

                // label target
                if (show)
                {
                    if (date == DateTime.MinValue)
                        view.labTargetPreview.Text = "no value";
                    else
                        view.labTargetPreview.Text = date.Add(view.GetModel().Offset).ToString(GuiUtils.GetShortDateLongTimeFormatPattern());                    
                }
                else
                {
                    // just show a copy of the value the user povided
                    view.labTargetPreview.Text = view.GetModel().CustomSource.ToString(GuiUtils.GetShortDateLongTimeFormatPattern());
                }
            }
        }
        #endregion

        #region Refresh/Clear Data and Settings
        public override void ClearData()
        {
            base.ClearData();
            UpdatePreviews();
        }

        public override void RefreshData()
        {
            base.RefreshData();
            UpdatePreviews();
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
