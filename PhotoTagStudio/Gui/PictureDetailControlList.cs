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

using System.Collections.Generic;
using Schroeter.Photo;

namespace Schroeter.PhotoTagStudio.Gui
{
    public class PictureDetailControlList : List<IPictureDetailControllerBase>
    {
        private PictureMetaData currentPicture;
        public PictureMetaData CurrentPicture
        {
            get { return currentPicture; }
        }

        private string currentDirectory;
        public string CurrentDirectory
        {
            get
            {
                return currentDirectory;
            }
        }

        public void RegisterEvents(DataChanged dataChanged,
            DirectoryChanged directoryChanged,
            DirectoryNameChanged directoryNameChanged,
            NavigateFiles navigateFiles,
            GetAllFilesDelegate ListAllCheckedFiles,
            GetAllFilesDelegate ListSelectedDirectory)
        {
            foreach (IPictureDetailControllerBase p in this)
            {
                p.DataChangedEvent += dataChanged;
                p.DirectoryChangedEvent += directoryChanged;
                p.DirectoryNameChangedEvent += directoryNameChanged;
                p.NavigateFilesEvent += navigateFiles;
                p.SetGetAllFilesDelegate(ListAllCheckedFiles, ListSelectedDirectory);
            }
        }

        public void RefreshSettings()
        {
            foreach (IPictureDetailControllerBase pdc in this)
                pdc.RefreshSettings();
        }

        public void RefreshSettingsAndData()
        {
            foreach (IPictureDetailControllerBase pdc in this)
            {
                pdc.RefreshSettings();
                pdc.RefreshData();
            }
        }

        public void UpdatePicture(PictureMetaData pmd)
        {
            if (this.currentPicture != null)
                this.currentPicture.Close();

            this.currentPicture = pmd;

            foreach (IPictureDetailControllerBase c in this)
                c.UpdatePicture(pmd);
        }

        public void UpdateDirectory(string path)
        {
            this.currentDirectory = path;

            foreach (IPictureDetailControllerBase c in this)
                c.UpdateDirectory(path);            
        }
        
        public RequestFileChangeResult CanUpdatePicture()
        {
            int countDoNotClose = 0;
            int countCloseAndSave = 0;
            int countClose = 0;

            foreach (IPictureDetailControllerBase c in this)
            {
                RequestFileChangeResult r = c.RequestFileChange();
                switch (r)
                {
                    case RequestFileChangeResult.Close:
                        countClose++;
                        break;
                    case RequestFileChangeResult.CloseAndSave:
                        countCloseAndSave++;
                        break;
                    case RequestFileChangeResult.DoNotClose:
                        countDoNotClose++;
                        break;
                }
            }

            int count = this.Count;

            // one say dont close
            if (countDoNotClose > 0)
                return RequestFileChangeResult.DoNotClose;

            // all say close
            if (countClose == count)
                return RequestFileChangeResult.Close;

            // none say dont close and one or more say save
            return RequestFileChangeResult.CloseAndSave;
        }
    }
}