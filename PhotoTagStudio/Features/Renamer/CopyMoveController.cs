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

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    class CopyMoveController
    {
        private CopyMoveModel model;
        private BackgroundWorker backgroundWorker;
        private IStatusDisplay statusDisplay;

        public CopyMoveController(CopyMoveModel m, IStatusDisplay statusDisplay)
        {
            this.statusDisplay = statusDisplay;

            model = m;
        
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(statusDisplay.WorkProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        public bool Work()
        {
            if ( model.ForbitExecution() || model.SourceDirectory == "" )
            {
                MessageBox.Show("One of the source or destination directory is invalid!", "PhotoTagStudio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // check if source dir exists
            if ( !Directory.Exists(model.SourceDirectory) )
            {
                MessageBox.Show(String.Format("The source directory {0} does no exist!",model.SourceDirectory), "PhotoTagStudio", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            backgroundWorker.RunWorkerAsync();

            while (backgroundWorker.IsBusy)
            {
                // Keep UI messages moving, so the form remains 
                // responsive during the asynchronous operation.
                Application.DoEvents();
            }

            return true;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker) sender;

            CopyMoveWorker worker = new CopyMoveWorker(false);
            worker.CreateFileList(model);
            worker.OneFileProcessed += delegate(object s, ProgressChangedEventArgs args) { backgroundWorker.ReportProgress(args.ProgressPercentage,statusDisplay); };
            backgroundWorker.ReportProgress(0);

            worker.ProcessFiles(model);
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusDisplay.WorkFinished();
        }
    }
}
