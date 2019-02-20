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

namespace Schroeter.Windows.Forms
{
    public class ThreeStateTreeNode : TreeNode
    {
        private CheckState checkState;
        private bool hasCheckBox;
        private bool showPlusMinus = true;
        private bool bold = false;

        //TODO: alle konstruktoren
        public ThreeStateTreeNode()
            : base()
        {
            CheckState = CheckState.Unchecked;
            hasCheckBox = true;
        }

        public ThreeStateTreeNode(string Text)
            : base(Text)
        {
            CheckState = CheckState.Unchecked;
            hasCheckBox = true;
        }

        public ThreeStateTreeNode(string Text, bool check)
            : base(Text)
        {
            if ( check ) 
                CheckState = CheckState.Checked;
            else
                CheckState = CheckState.Unchecked;

            hasCheckBox = true;
        }


        public CheckState CheckState
        {
            get { return checkState; }
            set 
            { 
                checkState = value;

                ThreeStateTreeView tree = this.TreeView as ThreeStateTreeView;
                if (tree != null && this.HasCheckBox)
                    tree.OnAfterCheckStateChanged(this);

                if ( this.TreeView != null )
                    this.TreeView.Invalidate(this.Bounds);
            }
        }
        
        public bool HasCheckBox
        {
            get { return hasCheckBox; }
            set { hasCheckBox = value; }
        }
        public bool ShowPlusMinus
        {
            get { return showPlusMinus; }
            set { showPlusMinus = value; }
        }
        public bool Bold
        {
            get { return bold; }
            set { bold = value; }
        }
    }
}