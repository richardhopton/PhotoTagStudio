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
using System.Diagnostics;
using System.IO;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Features.Renamer;

namespace Schroeter.PhotoTagStudio.Workers
{
    public class RenameWorker : MultiFileWorkerBase<RenameModel>
    {
        // for interactive mode only
        public PictureMetaData currentPicture = null;
        public string rootDirectory = "";

        private List<string> newFiles;

        bool changeDirectorynames;
        public bool ChangeDirectorynames
        {
            get { return changeDirectorynames; }
            set { changeDirectorynames = value; }
        }

        public override void ProcessFiles(RenameModel model)
        {
            if (model.ChangeFilenames)
                RenameFiles(model);
            else
            {
                newFiles = new List<string>();
                foreach (string file in files)
                    newFiles.Add(file);
            }

            if (model.ChangeDirectorynames)
                RenameDirectories(model);
        }

        private void RenameFiles(RenameModel model)
        {
            newFiles = new List<string>();

            RenamerEngine renamer = new RenamerEngine(model.FilenamePattern.Contains("%#"), !model.FilenamePattern.Contains("%##"));

            files.Sort();
            foreach (string filename in files)
            {
                // get the new name form the metadata
                PictureMetaData pmd = new PictureMetaData(filename);
                string newname = FileNameFormater.FormatFilename(pmd, model.FilenamePattern);
                newname = newname.Replace("%##", "%#");
                pmd.Close();

                if (newname != "")
                {
                    // open a file info
                    FileInfo fi = new FileInfo(filename);
                    newname = fi.DirectoryName + "\\" + newname;

                    // give the new name to the renamer
                    renamer.AddNewRenameItem(fi, newname);
                }
                else 
                    newFiles.Add(filename);  

                // next
                this.FireOneFileProcessed();
            }

            // and now: do all the dirty working
            renamer.CopyMove(true);

            // create the list of new files
            foreach (string filename in renamer.GetAllNewFilenames())
                if ( File.Exists(filename) )
                    newFiles.Add(filename);
        }

        private void RenameDirectories(RenameModel model)
        {
            // find all directories to rename
            List<string> directories = new List<string>();
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                string dir = fi.Directory.FullName;
                if ( !directories.Contains(dir) )
                    directories.Add(dir);
            }

            // compute the new names for these directories
            RenamerEngine renamer = new RenamerEngine(model.DirectoryPattern.Contains("%#"), !model.DirectoryPattern.Contains("%##"), false);
            foreach (string directory in directories)
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                string newName = GetNewDirectoryname(di, model.DirectoryPattern);
                if ( newName != "")
                    renamer.AddNewRenameItem(di,newName);                
            }

            renamer.CopyMove(true);

            rootDirectory = renamer.GetNewName(rootDirectory);

            // update the new files
            List<string> tempFiles = new List<string>();
            foreach (KeyValuePair<string, string> oldAndNewFilename in renamer.GetAllOldAndNewFilenames())
            {
                string oldDirectory = oldAndNewFilename.Key.ToLower();
                string newDirectory = oldAndNewFilename.Value.ToLower();

                if (oldDirectory != newDirectory)
                {
                    for (int i = 0; i < newFiles.Count; i++ )
                    {
                        if (newFiles[i].ToLower().StartsWith(oldDirectory))
                        {
                            string newFile = newDirectory + "\\" + newFiles[i].Substring(oldDirectory.Length);
                            newFile = newFile.Replace("\\\\", "\\");
                            newFiles[i] = newFile;

                            tempFiles.Add(newFile);
                        }
                    }
                }
            }
            
            for (int i = 0; i < newFiles.Count; i++ )
                if ( !File.Exists(newFiles[i]))
                {
                    newFiles.RemoveAt(i);
                    i--;
                }            
            foreach (string file in files)
                if ( File.Exists(file) && !newFiles.Contains(file) )
                    newFiles.Add(file);
            foreach (string file in tempFiles)
                if (File.Exists(file) && !newFiles.Contains(file))
                    newFiles.Add(file);

            //TODO debugging
            Debug.Assert(this.files.Count == this.newFiles.Count,"Anzahl an Dateien nach Rename falsch.", string.Format("vorher {0} nachher {1}",this.files.Count,this.newFiles.Count));
        }

        private string GetNewDirectoryname(DirectoryInfo directory, string pattern)
        {
            pattern = pattern.Replace("%##%", "%#");

            // get the new name form the metadata
            PictureMetaData pmd;
            bool dontClosePmd = false;
            if (this.rootDirectory.ToLower() == directory.FullName.ToLower() && this.currentPicture != null)
            {
                pmd = this.currentPicture;
                dontClosePmd = true;
            }
            else
                pmd = GetPictureMetaDataFromDirectory(directory);

            if (pmd != null)
            {
                string newname = FileNameFormater.FormatFilename(pmd, pattern);

                if (!dontClosePmd)
                    pmd.Close();

                if (newname != "" && newname.ToLower() != directory.Name.ToLower())
                {
                    newname = directory.Parent.FullName + "\\" + newname;
                    newname = newname.Replace("\\\\", "\\");
                    return newname;
                }
            }

            return "";
        }

        private static PictureMetaData GetPictureMetaDataFromDirectory(DirectoryInfo di)
        {
            FileInfo[] fis = di.GetFiles("*.jpg");
            if (fis.Length > 0)
            {
                return new PictureMetaData(fis[0].FullName);
            }
            else
                return null;
        }

        public override List<string> GetChangedFileList()
        {
            return newFiles;
        }
    }
}
