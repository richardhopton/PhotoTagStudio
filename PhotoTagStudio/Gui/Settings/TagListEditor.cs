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
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    public partial class TagListEditor : UserControl
    {
        private const int IMAGE_INDEX_GROUP = 1;
        private BaseTagList value;
        private GroupedTagListHelper groupedTagListHelper;

        public TagListEditor()
        {
            InitializeComponent();
        }

        public BaseTagList Value
        {
            get
            { 
                return this.value; 
            }
            set
            {
                this.value = value;
                if (value != null)
                {
                    if (this.groupedTagListHelper != null)
                        this.groupedTagListHelper.UnregisterDragDrop();

                    DisplayList();
                    this.checkBox1.Checked = this.value.CanGrow;

                    this.treeView1.ShowRootLines = value is GroupedTagList;
                   
                    this.btnAddGroup.Visible = value is GroupedTagList;


                    if (value is GroupedTagList)
                    {
                        this.groupedTagListHelper = new GroupedTagListHelper(this.treeView1, (GroupedTagList)this.value);
                        this.groupedTagListHelper.RegisterDragDrop();
                    }
                    else
                        this.textBox1.Width = this.treeView1.Width;
                }
                else
                {
                    this.treeView1.Nodes.Clear();
                    this.checkBox1.Checked = false;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                string s = this.textBox1.Text;

                if (this.value is GroupedTagList)
                {
                    GroupedTagList gtl = (GroupedTagList)this.value;

                    string group = GroupedTagList.DEFAULT_GROUP;
                    TreeNode groupNode = this.treeView1.SelectedNode;
                    if (groupNode != null)
                    {
                        if (this.treeView1.SelectedNode.Parent != null)
                            groupNode = this.treeView1.SelectedNode.Parent;
                        group = groupNode.Text;
                    }

                    if (gtl.Add(s, group))
                    {
                        if ( groupNode == null )
                            this.DisplayList();
                        else
                        {
                            TreeNode n = new TreeNode(s);
                            groupNode.Nodes.Add(n);
                            this.treeView1.SelectedNode = n;
                        }
                    }
                }
                else
                {
                    TagList tl = (TagList)this.value;
                    if (tl.Add(s))
                        this.treeView1.Nodes.Add(s);
                }

                this.textBox1.Text = "";
            }
        }
        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            // Entf
            if (e.KeyValue == 46)
            {
                if (this.treeView1.SelectedNode == null)
                    return;

                if (this.value is TagList)
                {
                    string value = this.treeView1.SelectedNode.Text;

                    TagList tl = (TagList)this.value;
                    tl.Data.Remove(value);
                }
                else
                {
                    GroupedTagList gtl = (GroupedTagList)this.value;

                    if (this.treeView1.SelectedNode.Parent == null)
                    {
                        // group seleced
                        string group = this.treeView1.SelectedNode.Text;

                        gtl.Remove(group);
                    }
                    else
                    {
                        // value under group selected
                        string value = this.treeView1.SelectedNode.Text;
                        string group = this.treeView1.SelectedNode.Parent.Text;

                        gtl.Remove(value, group);
                    }
                }

                this.treeView1.SelectedNode.Remove();
            }
        }

        private void DisplayList()
        {
            this.treeView1.Nodes.Clear();

            if (this.value is TagList)
            {
                foreach (string s in ((TagList)this.value).Data)
                        this.treeView1.Nodes.Add(s);
            }
            else
            {
                GroupedTagList gtl = (GroupedTagList)this.value;

                foreach (string g in gtl.GetGroups())
                {
                    TreeNode n = new TreeNode(g);
                    n.ImageIndex = IMAGE_INDEX_GROUP;
                    n.SelectedImageIndex = IMAGE_INDEX_GROUP;
                    foreach (string v in gtl.GetValues(g))
                        n.Nodes.Add(v);
                    this.treeView1.Nodes.Add(n);
                    n.Expand();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.value.CanGrow = this.checkBox1.Checked;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (this.value is GroupedTagList)
            {
                GroupedTagList gtl = (GroupedTagList)this.value;
                gtl.Sort();
            }
            else
            {
                TagList tl = (TagList)this.value;
                tl.Data.Sort();
            }

            DisplayList();
        }
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            TreeNode n = new TreeNode(this.textBox1.Text);
            n.ImageIndex = IMAGE_INDEX_GROUP;
            n.SelectedImageIndex = IMAGE_INDEX_GROUP;

            this.treeView1.Nodes.Add(n);
            this.textBox1.Text = "";
        }
    }
}