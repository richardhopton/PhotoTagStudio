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
using System.ComponentModel;
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    public partial class SettingsForm : Form
    {
        private TreeNode nodeKeywords;
        private TreeNode nodeCaption;
        private TreeNode nodeObjectName;

        public SettingsForm()
        {
            InitializeComponent();

            this.Icon = Resources.PTS;

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            foreach (TreeNode n in this.treeView1.Nodes)
                nodes.Enqueue(n);
            while (nodes.Count > 0)
            {
                TreeNode node = nodes.Dequeue();

                switch(node.Name)
                {
                    case "NodeKeywords":
                        this.nodeKeywords = node;
                        break;
                    case "NodeCaption":
                        this.nodeCaption = node;
                        break;
                    case "NodeObjectNames":
                        this.nodeObjectName = node;
                        break;
                }

                foreach (TreeNode n in node.Nodes)
                    nodes.Enqueue(n);
            }
                
            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(this.Settings_PropertyChanged);

            ShowIPTCorFlickrNames();
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayIPTCTagsWithFlickrNames")
                ShowIPTCorFlickrNames();
        }
        private void ShowIPTCorFlickrNames()
        {
            if (Settings.Default.DisplayIPTCTagsWithFlickrNames )
            {
                this.nodeKeywords.Text = "Tags";
                this.nodeObjectName.Text = "Title";
                this.nodeCaption.Text = "Description";
            }
            else
            {
                this.nodeKeywords.Text = "Keywords";
                this.nodeObjectName.Text = "Object Name";
                this.nodeCaption.Text = "Caption";
            }
        }
        
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.MainPanel.Controls.Clear();

            if ( e.Node == null )
                return;

            Control newControl = null;
           
            string tag = e.Node.Tag as string;
            if (tag == null)
                tag = "";

            if ( tag.StartsWith("TagList") )
            {
                string name = tag.Split('.')[1];
                TagListEditor tle = new TagListEditor();
                switch (name)
                {
                    case "Writers":
                        tle.Value = Settings.Default.Writers;
                        break;
                    case "Authors":
                        tle.Value = Settings.Default.Authors;
                        break;
                    case "Captions":
                        tle.Value = Settings.Default.Captions;
                        break;
                    case "Contacts":
                        tle.Value = Settings.Default.Contacts;
                        break;
                    case "Copyrights":
                        tle.Value = Settings.Default.Copyrights;
                        break;
                    case "Headlines":
                        tle.Value = Settings.Default.Headlines;
                        break;
                    case "Objectnames":
                        tle.Value = Settings.Default.Objectnames;
                        break;
                    case "FilenameFormats":
                        tle.Value = Settings.Default.FilenameFormats;
                        break;
                    case "DirectorynameFormats":
                        tle.Value = Settings.Default.DirectorynameFormats;
                        break;
                    case "KeywordsG":
                        tle.Value = Settings.Default.GroupedKeywords;
                        break;
                    default:
                        tle = null;
                        break;
                }
                newControl = tle;
            }
            else if (tag == "LocationList")
            {
                LocationListEditor lle = new LocationListEditor();
                lle.Value = Settings.Default.Locations;
                newControl = lle;
            }
            else if (tag == "root")
            {
                newControl = new SettingsMain();
            }
            else if (tag == "ITPC")
            {
                newControl = new ITPCMain();
            }
            else if (tag == "kmz")
            {
                newControl = new KmzAndGps();
            }
            else if (tag == "tabs")
            {
                newControl = new VisibleTabs( this.Owner as MainForm );
            }

            if (newControl != null)
            {
                this.MainPanel.Controls.Add(newControl);
                newControl.Dock = DockStyle.Fill;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}