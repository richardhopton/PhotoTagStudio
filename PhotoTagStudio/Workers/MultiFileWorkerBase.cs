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
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Workers
{
    public abstract class MultiFileWorkerBase<MODEL> : MultiFileWorkerBase where MODEL : ModelBase
    {
        public abstract void ProcessFiles(MODEL model);

        public override void ProcessFileModelBase(ModelBase model)
        {
            ProcessFiles(model as MODEL);
        }
    }

    public abstract class MultiFileWorkerBase : WorkerBase
    {
        public event ProgressChangedEventHandler OneFileProcessed;

        public abstract void ProcessFileModelBase(ModelBase model);

        protected List<string> files = new List<string>();
        protected int finishedFiles = 0;

        public virtual void SetFileList(List<string> files)
        {
            this.files = files;
            finishedFiles = 0;
        }
        public virtual void CreateFileList(ModelBase model)
        {
            
        }
        public virtual List<string> GetChangedFileList()
        {
            return this.files;
        }

        protected List<string> GetDirectoriesFromFiles()
        {
            List<string> dirs = new List<string>();

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string path = fi.DirectoryName.ToLower();
                if ( !dirs.Contains(path) )
                    dirs.Add(path);
            }

            return dirs;
        }

        protected void FireOneFileProcessed()
        {
            finishedFiles++;
            int percentage = finishedFiles*100/files.Count;
            Debug.Assert(percentage <= 100, "MultiFileWorkerBase: the percentage is > 100");
            if (percentage > 100)
                percentage = 100;

            if (OneFileProcessed != null)
                OneFileProcessed(this, new ProgressChangedEventArgs(percentage,null));
        }

        public virtual bool ProvidesItsOwnStartDirectories(ModelBase model, out string directory)
        {
            directory = "";
            return false;
        }

        public int FileCount
        {
            get
            {
                return files.Count;
            }
        }
    }
}