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
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    public partial class SettingsMain : UserControl
    {
        public SettingsMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            FileInfo fi = new FileInfo(config.FilePath);
            System.Diagnostics.Process.Start("explorer", fi.DirectoryName);
        }

        private void SettingsMain_Load(object sender, EventArgs e)
        {
            this.chkRotate.Checked = Settings.Default.RotatePreview;
            this.chkBackgroundThumbnails.Checked = Settings.Default.LoadThumbnailsInBackground;
            this.chkCollapseKeywordGroups.Checked = Settings.Default.CollapseIptcKeywordGroupsOnStartup;
        }

        private void chkRotate_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.RotatePreview = this.chkRotate.Checked;
        }

        private void chkBackgroundThumbnails_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.LoadThumbnailsInBackground = this.chkBackgroundThumbnails.Checked;
        }

        private void chkCollapseKeywordGroups_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.CollapseIptcKeywordGroupsOnStartup = this.chkCollapseKeywordGroups.Checked;
        }
    }
}
