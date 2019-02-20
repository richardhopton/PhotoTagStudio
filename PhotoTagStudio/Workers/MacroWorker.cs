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
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Workers
{
    class MacroWorker
    {
        private Macro macro;

        private List<string> files = new List<string>();
        private int numberOfStatusItems;
        private int finishedWorkItems;
        private int finishedStatusItems;

        private BackgroundWorker backgroundWorker;
        private IStatusDisplay statusDisplay;

        public MacroWorker(Macro macro, IStatusDisplay statusDisplay)
        {
            this.macro = macro;
            this.statusDisplay = statusDisplay;
            
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(this.statusDisplay.WorkProgressChanged);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        #region set workingset
        public void SetWorkingset(string rootDirectory, bool subdirs)
        {
            AddToWorkingset(rootDirectory, subdirs);
        }
        public void SetWorkingset(List<string> directories, bool subdirectories)
        {
            foreach (string directory in directories)
                AddToWorkingset(directory,subdirectories);
        }
        private void AddToWorkingset(string rootDirectory, bool subdirs)
        {
            DirectoryInfo diSource = new DirectoryInfo(rootDirectory);
            FileInfo[] fis = FileUtils.GetFiles(diSource, "*.jpg", subdirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (FileInfo fi in fis)
                if ( !files.Contains(fi.FullName))
                    files.Add(fi.FullName);
        }
        #endregion

        public bool ForbitExecution()
        {
            foreach (ModelBase item in macro.WorkItems)
                if ( item.ForbitExecution() )
                    return true;

            return false;
        }

        public void Start()
        {
            if ( backgroundWorker.IsBusy )
                return;

            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = (BackgroundWorker) sender;
            backgroundWorker.WorkerReportsProgress = true;
            numberOfStatusItems = macro.WorkItems.Count*files.Count;
            finishedWorkItems = 0;
            finishedStatusItems = 0;

            backgroundWorker.ReportProgress(0);

            List<ModelBase> singleWorkers = new List<ModelBase>();

            foreach (ModelBase item in macro.WorkItems)
            {
                bool isSingle = GetWorkerTypeForModel(item).IsSubclassOf(typeof (SingleFileWorkerBase));

                if (isSingle)
                {
                    singleWorkers.Add(item);
                }
                else
                {
                    if (singleWorkers.Count > 0)
                    {
                        // but first process the single workers
                        ProcessSingleWorkers(singleWorkers, backgroundWorker);
                        singleWorkers.Clear();
                    }

                    ProcessMultiWorker(item, backgroundWorker);
                }
            }
            // maybe some singleworkers need to process 
            if (singleWorkers.Count > 0)
                ProcessSingleWorkers(singleWorkers, backgroundWorker);
        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.statusDisplay.WorkFinished();
            this.statusDisplay = null;
        }

        public virtual bool ProvidesItsOwnStartDirectories(out string message)
        {
            if (macro.WorkItems.Count == 0)
            {
                message = "";
                return false;
            }

            ModelBase firstModel = macro.WorkItems[0];
            MultiFileWorkerBase firstWorker = GetWorkerInstanceForModel(firstModel) as MultiFileWorkerBase;
            if (firstWorker == null)  
            {
                message = "";
                return false;
            }

            return firstWorker.ProvidesItsOwnStartDirectories(firstModel, out message);
        }

        private void ProcessSingleWorkers(List<ModelBase> models, BackgroundWorker backgroundWorker)
        {
            SingleFileWorkerBase[] workers = new SingleFileWorkerBase[models.Count];
            int i = 0;
            foreach (ModelBase model in models)
                workers[i++] = (SingleFileWorkerBase) GetWorkerInstanceForModel(model);

            foreach (string file in files)
            {
                PictureMetaData pmd = new PictureMetaData(file);
                i = 0;
                bool changed = false;
                foreach (ModelBase model in models)
                {
                    changed = changed | workers[i++].ProcessFileModelBase(pmd, model);
                    finishedStatusItems++;
                    backgroundWorker.ReportProgress((finishedStatusItems)*100/numberOfStatusItems); 
                }

                if (changed)
                    pmd.SaveChanges();

                pmd.Close();
            }

            finishedWorkItems += workers.Length;
            finishedStatusItems += workers.Length*files.Count;
        }
        private void ProcessMultiWorker(ModelBase model, BackgroundWorker backgroundWorker)
        {
            MultiFileWorkerBase worker = (MultiFileWorkerBase) GetWorkerInstanceForModel(model);

            // init
            string m;
            if ( worker.ProvidesItsOwnStartDirectories(model,out m) )
            {
                worker.CreateFileList(model);
                this.numberOfStatusItems = finishedStatusItems + (macro.WorkItems.Count - finishedWorkItems)*worker.FileCount;
            }
            else
                worker.SetFileList(files);

            int i = 0;
            worker.OneFileProcessed += delegate(object s, ProgressChangedEventArgs e) { backgroundWorker.ReportProgress((finishedStatusItems+(++i)) * 100 / numberOfStatusItems); };
            
            // do the work
            worker.ProcessFileModelBase(model);
            
            // pre processing
            this.files = worker.GetChangedFileList();

            finishedWorkItems++;
            finishedStatusItems += worker.FileCount;
        }

        private Type GetWorkerTypeForModel(ModelBase model)
        {
            Type modelType = model.GetType();
            Type macroEnabledAttributeType = typeof(MacroEnabledAttribute);
            object[] attributes = modelType.GetCustomAttributes(macroEnabledAttributeType, false);
            if (attributes.Length > 0)
            {
                MacroEnabledAttribute meatt = attributes[0] as MacroEnabledAttribute;
                if (meatt != null) 
                    return meatt.Worker;
            }

            return null;
        }
        private WorkerBase GetWorkerInstanceForModel(ModelBase model)
        {
            Type workerType = GetWorkerTypeForModel(model);
            object o = workerType.GetConstructor(new Type[] { }).Invoke(null);
            return o as WorkerBase;
        }
    }
}
