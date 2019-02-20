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
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    public partial class CopyMoveView : PresetableViewForCopyMoveModel
    {
        public CopyMoveView() :base()
        {
            InitializeComponent();
        }

        public void cmbDirectoryMode_Validated(object sender, EventArgs e)
        {
            switch (this.cmbDirectoryMode.SelectedIndex)
            {
                case 0:
                    this.model.DirectoryMode = DirectoryMode.ignore;
                    break;
                case 1:
                    this.model.DirectoryMode = DirectoryMode.createDestinationSubdirs;
                    break;
            }
        }

        public override void SetModel(CopyMoveModel m)
        {
            base.SetModel(m);

            this.bindingSource.DataSource = this.model;

            this.radioButtonCopy.Checked = this.model.Mode == CopyMoveMode.copy;
            this.radioButtonMove.Checked = this.model.Mode != CopyMoveMode.copy;
            switch (this.model.DirectoryMode)
            {
                case DirectoryMode.ignore:
                    this.cmbDirectoryMode.SelectedIndex = 0;
                    break;
                case DirectoryMode.createDestinationSubdirs:
                    this.cmbDirectoryMode.SelectedIndex = 1;
                    break;

            }
            switch(this.model.ExecuteFollowingMacrosOn)
            {
                case ExecuteMacroOn.source:
                    this.comboBoxExecuteMacroOn.SelectedIndex = 0;
                    break;
                case ExecuteMacroOn.destination:
                    this.comboBoxExecuteMacroOn.SelectedIndex = 1;
                    break;
            }

            this.textDirectoryName.Enabled = this.cmbDirectoryMode.SelectedIndex != 0;
        }

        private void btnSelectSourceDirectory_Click(object sender, EventArgs e)
        {            
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Description = "Please select the source directory:";
            f.SelectedPath = this.textSourceDirectory.Text;

            if (f.ShowDialog(this) == DialogResult.OK)
                this.textSourceDirectory.Text = f.SelectedPath;
        }

        private void btnSelectDestinationDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.Description = "Please select the destination directory:";
            f.SelectedPath = this.textDestinationDirectory.Text;

            if (f.ShowDialog(this) == DialogResult.OK)
                this.textDestinationDirectory.Text = f.SelectedPath;
        }

        public override void PreInit()
        {
            this.textFilename.DataSource = null;
            this.textFilename.DataSource = Settings.Default.FilenameFormats.Data;

            this.textDirectoryName.DataSource = null;
            this.textDirectoryName.DataSource = Settings.Default.DirectorynameFormats.Data;

            this.labelExecuteMacroOn.Visible = this.RunningInMacroMode;
            this.comboBoxExecuteMacroOn.Visible = this.RunningInMacroMode;

            base.PreInit();
        }

        private void radioButtonCopy_Validated(object sender, EventArgs e)
        {
            this.model.Mode = this.radioButtonCopy.Checked ? CopyMoveMode.copy : CopyMoveMode.move;
        }

        private void cmbDirectoryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textDirectoryName.Enabled = this.cmbDirectoryMode.SelectedIndex != 0;
        }

        private void radioButtonCopy_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxExecuteMacroOn.Enabled = this.radioButtonCopy.Checked;
        }

        private void comboBoxExecuteMacroOn_Validated(object sender, EventArgs e)
        {
            switch (this.comboBoxExecuteMacroOn.SelectedIndex)
            {
                case 0:
                    this.model.ExecuteFollowingMacrosOn = ExecuteMacroOn.source;
                    break;
                case 1:
                    this.model.ExecuteFollowingMacrosOn = ExecuteMacroOn.destination;
                    break;
            }
        }
    }

    // workaround, the visual studio (2005 and orcas beta 2) cannot design 
    // a control deriverd from PresetableView<CopyMoveModel> :-(
    // but PresetableViewForCopyMoveModel is fine :-)
    public class PresetableViewForCopyMoveModel : PresetableViewSaveLast<CopyMoveModel>
    {

    }
}
