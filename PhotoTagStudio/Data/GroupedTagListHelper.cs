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
using System.Drawing;
using System.Windows.Forms;
using Schroeter.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Data
{
    public class GroupedTagListHelper
    {
        GroupedTagList list;
        TreeView tree;

        public GroupedTagListHelper(TreeView tree, GroupedTagList list)
        {
            this.tree = tree;
            this.list = list;
        }

        #region drag drop
        public void RegisterDragDrop()
        {
            tree.DragOver += new DragEventHandler(tree_DragOver);
            tree.DragDrop += new DragEventHandler(tree_DragDrop);
            tree.ItemDrag += new ItemDragEventHandler(tree_ItemDrag);

            tree.AllowDrop = true;
        }
        public void UnregisterDragDrop()
        {
            tree.DragOver -= new DragEventHandler(tree_DragOver);
            tree.DragDrop -= new DragEventHandler(tree_DragDrop);
            tree.ItemDrag -= new ItemDragEventHandler(tree_ItemDrag);

            tree.AllowDrop = false;
        }

        private void tree_DragOver(object sender, DragEventArgs e)
        {
            if (  !e.Data.GetDataPresent(typeof(TreeNode))
                  && !e.Data.GetDataPresent(typeof(ThreeStateTreeNode)))
                e.Effect = DragDropEffects.None;
            else
            {
                TreeView tree = (TreeView)sender;
                Point p = tree.PointToClient(new Point(e.X, e.Y));
                TreeNode n = tree.GetNodeAt(p);
                if (n != null)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }
        private void tree_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode nSource = null;
            if ( e.Data.GetDataPresent(typeof(TreeNode) ) )
                nSource = (TreeNode)e.Data.GetData(typeof(TreeNode));
            else if ( e.Data.GetDataPresent(typeof(ThreeStateTreeNode)))
                nSource = (ThreeStateTreeNode)e.Data.GetData(typeof(ThreeStateTreeNode));
            else    
                return;

            TreeView tree = (TreeView)sender;
            Point p = tree.PointToClient(new Point(e.X, e.Y));
            TreeNode nDest = tree.GetNodeAt(p);
            if (nDest == null)
                return;

            if (nDest == nSource)
                return;

            TreeNode nDestGroup = nDest;
            if (nDest.Parent != null)
                nDestGroup = nDest.Parent;

            TreeNode nSourceGroup = nSource.Parent;

            if (nSourceGroup == nDestGroup)
                return;

            list.Move(nSource.Text, nSourceGroup.Text, nDestGroup.Text);

            nSource.Remove();
            nDestGroup.Nodes.Add(nSource);
        }
        private void tree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode n = e.Item as TreeNode;
            if (n != null && n.Level == 1)
            {
                TreeView tree = (TreeView)sender;
                tree.DoDragDrop(n, DragDropEffects.Move);
            }
        }
        #endregion

        #region save collapesd
        private List<string> collapsedKeywordGroups;

        public void RegisterCollapsMemory()
        {
            this.tree.AfterCollapse += new TreeViewEventHandler(tree_AfterCollapse);
            this.tree.AfterExpand += new TreeViewEventHandler(tree_AfterExpand);

            collapsedKeywordGroups = new List<string>();
        }

        public void UnregisterCollapsMemory()
        {
            this.tree.AfterCollapse -= new TreeViewEventHandler(tree_AfterCollapse);
            this.tree.AfterExpand -= new TreeViewEventHandler(tree_AfterExpand);
        }

        private void tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (this.collapsedKeywordGroups.Contains(e.Node.Text))
                this.collapsedKeywordGroups.Remove(e.Node.Text);

            (sender as TreeView).Invalidate();
        }

        private void tree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (!this.collapsedKeywordGroups.Contains(e.Node.Text))
                this.collapsedKeywordGroups.Add(e.Node.Text);
        }

        public bool ExpandNode(string groupName)
        {
            return !this.collapsedKeywordGroups.Contains(groupName);
        }
        #endregion
    }
}
