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
using Schroeter.PhotoTagStudio.Gui;

namespace Schroeter.PhotoTagStudio
{
    public enum RequestFileChangeResult
    {
        Close,
        CloseAndSave,
        DoNotClose
    }

    public enum NavigateFileOperation
    {
        Next,
        Previous,
        Delete
    }

    public delegate void DirectoryNameChanged(string navigateTo);
    public delegate void NavigateFiles(NavigateFileOperation operation);
    public delegate void DataChanged();
    public delegate void DirectoryChanged(bool withSubdirs);
    public delegate List<string> GetAllFilesDelegate(bool subdirectories);

    public interface IPictureDetailControllerBase
    {
        event DirectoryChanged DirectoryChangedEvent;
        event DataChanged DataChangedEvent;
        event NavigateFiles NavigateFilesEvent;
        event DirectoryNameChanged DirectoryNameChangedEvent;

        void SetGetAllFilesDelegate(GetAllFilesDelegate getAllFilesDelegate, GetAllFilesDelegate getAllDirectoryDelegate);
        void UpdatePicture(PictureMetaData picture);
        void UpdateDirectory(string path);
        void ClearData();
        void RefreshData();
        void RefreshSettings();

        PictureMetaData Picture { get; }

        RequestFileChangeResult RequestFileChange();
    }

}