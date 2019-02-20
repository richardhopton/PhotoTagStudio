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
using System.IO;
using System.Text;
using System.Threading;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    public class CopyMoveWorker : MultiFileWorkerBase<CopyMoveModel>
    {
        private RenamerEngine renamer;
        private bool ReturnChangedFileList = true;
        private bool blockUntillCopyFinished = true;

        public CopyMoveWorker(bool blockUntillCopyFinished):this()
        {
            this.blockUntillCopyFinished = blockUntillCopyFinished;
        }

        public CopyMoveWorker():base()
        {
            
        }

        public override void CreateFileList(ModelBase model)
        {
            files = new List<string>();
            CopyMoveModel m = model as CopyMoveModel;

            if (m == null)
                return;

            DirectoryInfo di = new DirectoryInfo(m.SourceDirectory);
            FileInfo[] f = FileUtils.GetFiles(di, "*.jpg", m.ReadFromSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (FileInfo file in f)
                files.Add(file.FullName);
        }

        public override void ProcessFiles(CopyMoveModel model)
        {
            DirectoryInfo diDestination = new DirectoryInfo(model.DestinationDirecotry); 

            ReturnChangedFileList = model.ExecuteFollowingMacrosOn == ExecuteMacroOn.destination;

            string fileformat = model.FilenameFormat;
            // number parameter are not supportet for directoriey - because it is easy to place more then one file in every directory...
            string directoryformat = model.DirectorynameFormat.Replace("%##", "");
            directoryformat = directoryformat.Replace("%#", "");
            renamer = new RenamerEngine(fileformat.Contains("%#"), !model.FilenameFormat.Contains("%##"));
            // now generate the new filename and path for every file
            foreach (string filename in files)
            {
                FileInfo file = new FileInfo(filename);

                PictureMetaData pmd = new PictureMetaData(filename);
                string newFilename = FileNameFormater.FormatFilename(pmd, fileformat);
                if ( newFilename == "" )
                    // the old name without extension
                    newFilename = file.Name.Substring(0, file.Name.Length - file.Extension.Length);
                newFilename.Replace("%##", "%#");
                string newDirectoryname;
                if (model.DirectoryMode != DirectoryMode.ignore)
                    newDirectoryname = FileNameFormater.FormatFilename(pmd, directoryformat);
                else
                    newDirectoryname = "";
                pmd.Close();

                string fullnewname;
                switch (model.DirectoryMode)
                {
                    case DirectoryMode.createDestinationSubdirs:
                        fullnewname = diDestination.FullName + "\\" + newDirectoryname + "\\" + newFilename;
                        break;
                    //case DirectoryMode.createDestinationSubdirsForEverySourceDir:
                    //    DirectoryInfo diSource = new DirectoryInfo(model.SourceDirectory);
                    //    string dirNameBelowSourceDir = file.Directory.FullName.Substring(diSource.FullName.Length);
                    //    fullnewname = model.DestinationDirecotry + "\\" + dirNameBelowSourceDir + "\\" + newDirectoryname + "\\" + newFilename;
                    //    break;
                    case DirectoryMode.ignore:
                    default:
                        fullnewname = diDestination.FullName + "\\" + newFilename;
                        break;
                }
                // repair the name
                fullnewname = fullnewname.Replace(@"\\", @"\");
                fullnewname = fullnewname.Replace(@"\\", @"\");

                renamer.AddNewRenameItem(file, fullnewname);

                this.FireOneFileProcessed();
            }

            bool move = model.Mode == CopyMoveMode.move;
            Thread copyWorker = new Thread(delegate() { renamer.CopyMove(move); });
            copyWorker.Start();
            
            if ( blockUntillCopyFinished )
                copyWorker.Join();
        }

        public override List<string> GetChangedFileList()
        {
            if (ReturnChangedFileList)
            {
                List<string> l = new List<string>();

                if (renamer != null)
                    foreach (string s in renamer.GetAllNewFilenames())
                        if (File.Exists(s))
                            l.Add(s);

                return l;
            }
            else
                return files;
        }

        public override bool ProvidesItsOwnStartDirectories(ModelBase model, out string directory)
        {
            CopyMoveModel m = model as CopyMoveModel;
            if (m == null || m.SourceDirectory == "")
            {
                directory = "";
                return false;
            }
            else
            {
                directory = m.SourceDirectory;
                return true;
            }
        }
    }
}
