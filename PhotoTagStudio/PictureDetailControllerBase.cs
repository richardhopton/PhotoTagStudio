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
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Gui;

namespace Schroeter.PhotoTagStudio
{
    public class PictureDetailControllerBase : IPictureDetailControllerBase
    {
        protected MainForm mainForm;

        protected bool isDataLoaded;
        protected PictureMetaData currentPicture;
        protected string currentDirectory;

        public PictureDetailControllerBase(MainForm form)
        {
            this.mainForm = form;
            this.currentPicture = null;
        }

        #region events
        public event DirectoryChanged DirectoryChangedEvent;
        protected void FireDirectoryChanged(bool withSubdirs)
        {
            if (this.DirectoryChangedEvent != null)
                this.DirectoryChangedEvent(withSubdirs);
        }

        public event DataChanged DataChangedEvent;
        protected void FireDataChanged()
        {
            if (this.DataChangedEvent != null)
                this.DataChangedEvent();
        }

        public event NavigateFiles NavigateFilesEvent;
        protected void FireNavigateFiles(NavigateFileOperation operation)
        {
            if (this.NavigateFilesEvent != null)
                NavigateFilesEvent(operation);
        }

        public event DirectoryNameChanged DirectoryNameChangedEvent;
        protected void FireDirectoryNameChanged(string navigateTo)
        {
            if (this.DirectoryNameChangedEvent != null)
            {
                if (navigateTo.EndsWith("\\"))
                    navigateTo = navigateTo.Substring(0, navigateTo.Length - 1);
                this.DirectoryNameChangedEvent(navigateTo);
            }
        }
        #endregion

        #region Get all files / directories
        private GetAllFilesDelegate getAllFilesDelegate;
        private GetAllFilesDelegate getAllDirectoryDelegate;

        public void SetGetAllFilesDelegate(GetAllFilesDelegate getAllFilesDelegate, GetAllFilesDelegate getAllDirectoryDelegate)
        {
            this.getAllFilesDelegate = getAllFilesDelegate;
            this.getAllDirectoryDelegate = getAllDirectoryDelegate;
        }

        protected List<string> GetAllFileList(bool subdirectories)
        {
            if (this.getAllFilesDelegate == null)
                return new List<string>();
            else
                return this.getAllFilesDelegate(subdirectories);
        }
        protected List<string> GetAllDirectoryList(bool subdirectories)
        {
            if (this.getAllDirectoryDelegate == null)
                return new List<string>();
            else
                return this.getAllDirectoryDelegate(subdirectories);
        }
        #endregion

        public void UpdatePicture(PictureMetaData picture)
        {
            isDataLoaded = false;

            if (this.currentPicture != null
                && picture != null
                && this.currentPicture.Filename == picture.Filename)
                return;

            this.currentPicture = picture;

            if (this.currentPicture == null)
                this.ClearData();
            else
                this.RefreshData();
        }

        public virtual void UpdateDirectory(string path)
        {
            currentDirectory = path;
        }

        #region clear and refresh data /settings
        public virtual void ClearData()
        {
        }
        public virtual void RefreshData()
        {
            isDataLoaded = true;
        }
        public virtual void RefreshSettings()
        {
        }
        #endregion

        public PictureMetaData Picture
        {
            get
            {
                return currentPicture;
            }
        }

        public virtual RequestFileChangeResult RequestFileChange()
        {
            return RequestFileChangeResult.Close;
        }

        #region stop and restart all other work
        bool pictureDisplayWasWorking;
        protected void StopOtherWorker()
        {
            mainForm.pictureDisplay.StopAllWork();
            pictureDisplayWasWorking = false;
        }

        protected void PauseOtherWorker()
        {
            pictureDisplayWasWorking = mainForm.pictureDisplay.StopAllWork();
        }

        protected void RestartOtherWorker()
        {
            if (pictureDisplayWasWorking)
            {
                mainForm.pictureDisplay.ReCreateAllThumbnails();
                pictureDisplayWasWorking = false;
            }
        }
        #endregion

        protected bool ShowFileVanishedMsg(string filename)
        {
            return MessageBox.Show(String.Format("The file {0} has vanished. Cannot save changes.", filename), "PhotoTagStudio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK;
        }
    }
}
