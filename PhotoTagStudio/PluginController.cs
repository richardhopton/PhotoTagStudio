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
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio
{
    public class PluginController : PictureDetailControllerBase
    {
        private PluginView pluginView;
        private bool processFilesInSubdirectories;
        private BackgroundWorker backgroundWorker;

        public PluginController(MainForm form, PluginView pluginView) : base(form)
        {
            this.pluginView = pluginView;
            this.pluginView.EnterPressed += new EventHandler(Execute_Click);

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(mainForm.WorkProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }
        
        public void Execute_Click(object sender, EventArgs e)
        {
            if (pluginView.GetModel().Plugin == "")
            {
                MessageBox.Show("Please select a plugin in the list above first.", "PhotoTagStudio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (currentPicture == null)
                return;

            mainForm.WaitCursor(true);

            PluginWorker worker = new PluginWorker();
            bool changes = worker.ProcessFile(currentPicture, pluginView.GetModel());

            if (changes)
            {
               if ( !currentPicture.SaveChanges() )
               {
                   this.ShowFileVanishedMsg(currentPicture.Filename);
                   mainForm.WaitCursor(false);
                   return;
               }
               
                FireDataChanged();
            }

            mainForm.WaitCursor(false);    
        }

        public void ExecuteForAll_Click(object sender, EventArgs e)
        {
            if ( backgroundWorker.IsBusy )
                return;

            if (pluginView.GetModel().Plugin == "")
            {
                MessageBox.Show("Please select a plugin in the list above first.", "PhotoTagStudio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PauseOtherWorker();
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker) sender;

            PluginWorker worker = new PluginWorker();

            backgroundWorker.ReportProgress(0);

            List<string> filenames = this.GetAllFileList(this.processFilesInSubdirectories);
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
                        backgroundWorker.ReportProgress(i * 100 / filenames.Count);
                        continue;
                    }
                }

                bool breakForeach = false;
                if (worker.ProcessFile(pmd, pluginView.GetModel()))
                    if (!pmd.SaveChanges())
                        breakForeach = !this.ShowFileVanishedMsg(pmd.Filename);

                if (pmd != currentPicture)
                    pmd.Close();

                if (breakForeach)
                    break;

                backgroundWorker.ReportProgress(i * 100 / filenames.Count);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FireDataChanged();

            mainForm.WorkFinished();

            RestartOtherWorker();
        }

        public bool ProcessFilesInSubdirectories
        {
            get { return processFilesInSubdirectories; }
            set { processFilesInSubdirectories = value; }
        }
    }
}
