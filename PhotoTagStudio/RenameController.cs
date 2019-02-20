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
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Features.Renamer;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio
{
    class RenameController : PictureDetailControllerBase
    {
        private RenameView renameView;
        private bool processFilesInSubdirectories;
        private BackgroundWorker backgroundWorker;

        public RenameController(MainForm form, RenameView renameView) : base(form)
        {
            this.renameView = renameView;
            this.renameView.TextBoxChanged += new EventHandler(renameView_TextBoxChanged);

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(mainForm.WorkProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

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
        public override void RefreshSettings()
        {
            base.RefreshSettings();

            this.renameView.RefreshSettings();
        }
        private void UpdatePreviews()
        {
            if (currentPicture != null)
            {
                renameView.labFilenameExample.Text = FileNameFormater.FormatFilename(currentPicture, renameView.txtFilename.Text) + ".jpg";
                renameView.labDirectoryExample.Text = FileNameFormater.FormatFilename(currentPicture, renameView.txtDirectoryname.Text);
            }
        }
        private void renameView_TextBoxChanged(object sender, EventArgs e)
        {
            this.UpdatePreviews();
        }

        #region the actual renaming
        public void Rename_Click(object sender, EventArgs e)
        {            
            // get the model
            RenameModel model = renameView.GetModel();

            if ( model.ChangeDirectorynames == false && model.ChangeFilenames == false)
                return; // nothing to do

            List<string> files = this.GetAllFileList(this.processFilesInSubdirectories);
            if ( files.Count == 0 )
                return; // nothing to do

            // do gui / settings work
            renameView.SaveLastModel();
            Settings.Default.FilenameFormats.AddIfGrowing(model.FilenamePattern);
            Settings.Default.DirectorynameFormats.AddIfGrowing(model.DirectoryPattern);
           
            StopOtherWorker();

            backgroundWorker.RunWorkerAsync(new RenameWorkerArgument(files, model));
        }

        private struct RenameWorkerArgument
        {
            public List<string> filenames;
            public RenameModel model;

            public RenameWorkerArgument(List<string> filenames, RenameModel model)
            {
                this.filenames = filenames;
                this.model = model;
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RenameWorkerArgument workerArgs = (RenameWorkerArgument) e.Argument;

            RenameModel model = workerArgs.model;
            BackgroundWorker backgroundWorker = (BackgroundWorker) sender;

            backgroundWorker.ReportProgress(0);

            // create worker
            RenameWorker worker = new RenameWorker();
            worker.currentPicture = this.currentPicture;
            worker.rootDirectory = this.currentDirectory;
            worker.SetFileList(workerArgs.filenames);
            worker.OneFileProcessed += delegate(object s, ProgressChangedEventArgs args) { backgroundWorker.ReportProgress(args.ProgressPercentage); };

            // start working
            worker.ProcessFiles(model);

            worker.ChangeDirectorynames = model.ChangeDirectorynames;
            e.Result = worker;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RenameWorker worker = (RenameWorker) e.Result;

            // go to the renamd directory or fire events
            if (worker.ChangeDirectorynames)
            {
                if (worker.rootDirectory != "" && Directory.Exists((worker.rootDirectory)))
                    this.FireDirectoryNameChanged(worker.rootDirectory);
                else
                    this.FireDirectoryChanged(true);
            }
            else
                this.FireDirectoryChanged(false);

            FireDataChanged();

            mainForm.WorkFinished();
        }
        #endregion

        #region properties
        public bool ProcessFilesInSubdirectories
        {
            get { return processFilesInSubdirectories; }
            set { processFilesInSubdirectories = value; }
        }
        #endregion
    }
}
