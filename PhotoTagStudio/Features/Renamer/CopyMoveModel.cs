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
using System.IO;
using System.Xml.Serialization;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    public enum CopyMoveMode
    {
        copy,
        move
    }

    public enum DirectoryMode
    {
        ignore,
        createDestinationSubdirs
    }

    public enum ExecuteMacroOn
    {
        source,
        destination
    }

    [Serializable]
    [MacroEnabled("Copy or move files", typeof(CopyMoveView), typeof(CopyMoveWorker))]
    public class CopyMoveModel : ModelBase
    {
        public CopyMoveModel()
        {
            
        }

        public override bool ForbitExecution()
        {
            //check soruce and destination is valid
            try
            {
                new FileInfo(destinationDirecotry);

                if (sourceDirectory != "")
                    new FileInfo(sourceDirectory);
            }
            catch
            {
                return true;
            }

            return false;
        }

        public string SourceDirectory
        {
            get { return sourceDirectory; }
            set { SetDirty(); sourceDirectory = value; }
        }

        public string DestinationDirecotry
        {
            get { return destinationDirecotry; }
            set { SetDirty(); destinationDirecotry = value; }
        }

        public bool ReadFromSubdirectories
        {
            get { return readFromSubdirectories; }
            set { SetDirty(); readFromSubdirectories = value; }
        }

        public string FilenameFormat
        {
            get { return filenameFormat; }
            set { SetDirty(); filenameFormat = value; }
        }

        public string DirectorynameFormat
        {
            get { return directorynameFormat; }
            set { SetDirty(); directorynameFormat = value; }
        }

        public CopyMoveMode Mode
        {
            get { return mode; }
            set { SetDirty(); mode = value; }
        }

        public DirectoryMode DirectoryMode
        {
            get { return directoryMode; }
            set { SetDirty(); directoryMode = value; }
        }

        public ExecuteMacroOn ExecuteFollowingMacrosOn
        {
            get { return executeMacroOnFollowingMacro; }
            set { executeMacroOnFollowingMacro = value; }
        }

        private string sourceDirectory ="";
        private string destinationDirecotry ="";
        private bool readFromSubdirectories = false;

        private string filenameFormat ="";
        private string directorynameFormat="";

        private CopyMoveMode mode = CopyMoveMode.copy;
        private DirectoryMode directoryMode = Renamer.DirectoryMode.ignore;
        private ExecuteMacroOn executeMacroOnFollowingMacro = ExecuteMacroOn.destination;
    }
}
