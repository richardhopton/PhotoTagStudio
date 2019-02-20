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
using System.Text;
using System.Xml.Serialization;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Data
{
    [MacroEnabled("Rename", typeof(RenameView), typeof(RenameWorker))]
    public class RenameModel : ModelBase
    {
        private bool changeFilenames = true;
        private bool changeDirectorynames = false;
        private string filenamePattern = "";
        private string directoryPattern = "";

        #region properties

        public bool ChangeFilenames
        {
            get { return changeFilenames; }
            set { SetDirty(); changeFilenames = value; }
        }

        public bool ChangeDirectorynames
        {
            get { return changeDirectorynames; }
            set { SetDirty(); changeDirectorynames = value; }
        }

        public string FilenamePattern
        {
            get { return filenamePattern; }
            set
            {
                SetDirty();
                filenamePattern = value;
                if (enableSpecialUpdateLogic)
                    changeFilenames = true;
            }
        }

        public string DirectoryPattern
        {
            get { return directoryPattern; }
            set 
            {
                SetDirty();
                directoryPattern = value;
                if (enableSpecialUpdateLogic)
                    changeDirectorynames = true;
            }
        }
        #endregion
    }
}
