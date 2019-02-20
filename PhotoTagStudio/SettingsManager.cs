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

using System.IO;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Features.Renamer;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio
{
    public class SettingsManager
    {
        private const string DEFAULT_FILE_FORMAT = "%dc[yyyy-MM-dd HH-mm-ss]";
        private const string DEFAULT_DIRECTORY_FORMAT = "%dc[yyyy-MM-dd]";

        public static void ImportOldConfig()
        {
            if (Settings.Default.NewSettingFile)
            {
                Settings.Default.Upgrade();
                Settings.Default.NewSettingFile = false;
            }
        }

        public static void InitUserSettings()
        {
            if (Settings.Default.Headlines == null)
                Settings.Default.Headlines = new TagList();

            if (Settings.Default.Captions == null)
                Settings.Default.Captions = new TagList();

            if (Settings.Default.Contacts == null)
                Settings.Default.Contacts = new TagList(true);

            if (Settings.Default.Copyrights == null)
                Settings.Default.Copyrights = new TagList(true);

            if (Settings.Default.Authors == null)
                Settings.Default.Authors = new TagList(true);

            if (Settings.Default.Writers == null)
                Settings.Default.Writers = new TagList(true);

            if (Settings.Default.Objectnames == null)
                Settings.Default.Objectnames = new TagList();

            if (Settings.Default.Locations == null)
                Settings.Default.Locations = new LocationList(true);

            if (Settings.Default.FilenameFormats == null)
            {
                Settings.Default.FilenameFormats = new TagList(true);
                Settings.Default.FilenameFormats.Add(DEFAULT_FILE_FORMAT);
            }

            if (Settings.Default.DirectorynameFormats == null)
            {
                Settings.Default.DirectorynameFormats = new TagList(true);
                Settings.Default.DirectorynameFormats.Add(DEFAULT_DIRECTORY_FORMAT);
            }

            if (Settings.Default.GroupedKeywords == null)
            {
                if (Settings.Default.Keywords == null)
                    Settings.Default.GroupedKeywords = new GroupedTagList(true);
                else
                {
                    Settings.Default.GroupedKeywords = new GroupedTagList(Settings.Default.Keywords);
                    Settings.Default.Keywords = null;
                }
            }

            if (Settings.Default.PresetModels == null)
            {
                Settings.Default.PresetModels = new PresetStore();

                CopyMoveModel cpm = new CopyMoveModel();
                cpm.FilenameFormat = DEFAULT_FILE_FORMAT;
                cpm.DirectorynameFormat = DEFAULT_DIRECTORY_FORMAT;
                Settings.Default.PresetModels.SaveLastModel(cpm);

                RenameModel rm = new RenameModel();
                rm.FilenamePattern = DEFAULT_FILE_FORMAT;
                rm.DirectoryPattern = DEFAULT_DIRECTORY_FORMAT;
                rm.ChangeDirectorynames = false;
                rm.ChangeFilenames = false;
                Settings.Default.PresetModels.SaveLastModel(rm);
            }

            if (Settings.Default.MacroRecentFiles == null)
                Settings.Default.MacroRecentFiles = new RecentList();
            else
                // remove files that does not exist
                Settings.Default.MacroRecentFiles.RemoveAll(delegate(string s) { return !File.Exists(s); });

        }

        public static void RegisterManager()
        {
            Schroeter.Photo.PictureMetaData.RotateAsExifOrientation = Settings.Default.RotatePreview;

            Settings.Default.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Settings_PropertyChanged);
        }

        private static void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RotatePreview")
                Schroeter.Photo.PictureMetaData.RotateAsExifOrientation = Settings.Default.RotatePreview;
        }
    }
}
