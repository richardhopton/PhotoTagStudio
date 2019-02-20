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

using System.Windows.Forms;
using Raccoom.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class FolderBrowseBox : Form
    {
        public FolderBrowseBox(string title, string text, string startDir)
        {
            InitializeComponent();

            this.Text = title;
            this.label1.Text = text;

            TreeViewFolderBrowserDataProviderShell32 dss32 = new TreeViewFolderBrowserDataProviderShell32();
            this.directoryTree.DataSource = dss32;

            this.directoryTree.Populate();
            this.directoryTree.Nodes[0].Expand();

            if (startDir != "")
            {
                this.directoryTree.ShowFolder(startDir);
                this.directoryTree.SelectedDirectories.Clear();
                this.directoryTree.SelectedDirectories.Add(startDir);
                this.directoryTree.SelectedNode.Expand();
            }
        }
            
        public string Directory
        {
            get
            {
                TreeNodePath node = this.directoryTree.SelectedNode as TreeNodePath;
                if (node != null)
                    return node.Path;

                return "";
            }
        }

        public bool Subdirectories
        {
            get
            {
                return this.checkBox1.Checked;
            }
            set
            {
                this.checkBox1.Checked = value;
            }
        }

        private void directoryTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            TreeNodePath node = e.Node as TreeNodePath;
            if (node != null)
                if (node.Path.StartsWith("::") || node.Path == "")
                    e.Cancel = true;
        }
    }
}