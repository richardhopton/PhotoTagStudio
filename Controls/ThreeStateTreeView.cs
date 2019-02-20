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
using System.Drawing;
using System.Windows.Forms;

namespace Schroeter.Windows.Forms
{
    public class ThreeStateTreeView : TreeView
    {
        private int checkBoxWidth;
        private int plusMinusWidth;
        private bool reverseCheckStateOrder;

        public event TreeViewEventHandler AfterCheckStateChanged;

        public ThreeStateTreeView()
            : base()
        {
            InitializeComponent();
         
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.FullRowSelect = true;
            this.ShowLines = true;
            this.ShowRootLines = true;
            this.ShowPlusMinus = true;

            this.DrawNode += new DrawTreeNodeEventHandler(ThreeStateTreeView_DrawNode);

            this.NodeMouseClick += new TreeNodeMouseClickEventHandler(ThreeStateTreeView_NodeMouseClick);

            this.KeyUp += new KeyEventHandler(ThreeStateTreeView_KeyUp);

            this.AfterCheck += new TreeViewEventHandler(ThreeStateTreeView_AfterCheck);

            this.checkBoxWidth = CheckBoxRenderer.GetGlyphSize(this.CreateGraphics(), System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal).Width;
            this.checkBoxWidth += 2;

            this.plusMinusWidth = 16;

            this.borderHeight = this.Bounds.Width - this.ClientRectangle.Width - 1;
        }

        #region SelectAll Check Box
        private CheckBox selectAllCheckBox;
        private bool dontUpdateList = false;
        private System.ComponentModel.IContainer components;
        private ImageList images;
        private bool dontUpdateAllCheckBox = false;
        
        public void BindSelectAllCheckBox(CheckBox checkBox)
        {
            if (this.selectAllCheckBox != null)
                this.selectAllCheckBox.CheckStateChanged -= new EventHandler(selectAllCheckBox_CheckStateChanged);

            this.selectAllCheckBox = checkBox;
            checkBox.ThreeState = true;

            this.selectAllCheckBox.CheckStateChanged += new EventHandler(selectAllCheckBox_CheckStateChanged);
        }

        public void UpdateSelectAllCheckBox()
        {
            if (this.selectAllCheckBox != null)
                ThreeStateTreeView_AfterCheck(null, null);
        }

        private void ThreeStateTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (dontUpdateList || this.selectAllCheckBox == null)
                return;

            dontUpdateAllCheckBox = true;

            int countChecked = 0;
            int countUnchecked = 0;
            int countNodes = 0;
            foreach (TreeNode n in this.Nodes)
                CountNodes(n, ref countChecked, ref countUnchecked, ref countNodes);

            if (countUnchecked == countNodes)
                this.selectAllCheckBox.CheckState = CheckState.Unchecked;
            else if (countChecked == countNodes)
                this.selectAllCheckBox.CheckState = CheckState.Checked;
            else
                this.selectAllCheckBox.CheckState = CheckState.Indeterminate;

            dontUpdateAllCheckBox = false;
        }
        private void CountNodes(TreeNode node, ref int countChecked, ref int countUncheckd, ref int countNodes)
        {
            ThreeStateTreeNode tstn = node as ThreeStateTreeNode;
            if (tstn != null && tstn.HasCheckBox)
            {
                countNodes++;
                if (tstn.CheckState == CheckState.Checked)
                    countChecked++;
                else if (tstn.CheckState == CheckState.Unchecked)
                    countUncheckd++;
            }

            foreach (TreeNode n in node.Nodes)
                CountNodes(n, ref countChecked, ref countUncheckd, ref countNodes);
        }

        private void selectAllCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (dontUpdateAllCheckBox)
                return;

            dontUpdateList = true;

            if (ReverseCheckStateOrder && this.threeState)
            {
                dontUpdateAllCheckBox = true;

                if (this.selectAllCheckBox.CheckState == CheckState.Checked)
                    this.selectAllCheckBox.CheckState = CheckState.Indeterminate;
                else if (this.selectAllCheckBox.CheckState == CheckState.Unchecked)
                    this.selectAllCheckBox.CheckState = CheckState.Checked;
                else
                    this.selectAllCheckBox.CheckState = CheckState.Unchecked;

                dontUpdateAllCheckBox = false;
            }
            
            if (!this.threeState && this.selectAllCheckBox.CheckState == CheckState.Indeterminate)
                this.selectAllCheckBox.CheckState = CheckState.Unchecked;

            foreach (TreeNode n in this.Nodes)
                CheckNodes(n, this.selectAllCheckBox.CheckState);

            dontUpdateList = false;
        }
        private void CheckNodes(TreeNode node, CheckState state)
        {
            ThreeStateTreeNode tstn = node as ThreeStateTreeNode;
            if (tstn != null && tstn.HasCheckBox)
            {
                tstn.CheckState = state;
                tstn.Checked = !tstn.Checked; //TODO
            }

            foreach (TreeNode n in node.Nodes)
                CheckNodes(n, state);
        }
        #endregion

        #region special select
        private Point mouseDownLocation;
        private bool specialSelectMode = false;
        private void ThreeStateTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDownLocation = e.Location;
        }

        protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
        {
            if (specialSelectMode && mouseDownLocation != null && e.Action == TreeViewAction.ByMouse)
                if (mouseDownLocation.X <= this.checkBoxWidth)
                    e.Cancel = true;

            if ( !e.Cancel )
                base.OnBeforeSelect(e);
        }
        public bool SpecialSelectMode
        {
            get 
            { 
                return specialSelectMode; 
            }
            set 
            { 
                specialSelectMode = value;

                if (specialSelectMode)
                {
                    this.MouseDown += new MouseEventHandler(ThreeStateTreeView_MouseDown);
                }
                else
                {
                    this.MouseDown -= new MouseEventHandler(ThreeStateTreeView_MouseDown);
                }
            }
        }
        #endregion

        #region threestate
        private bool threeState;
        public bool ThreeState
        {
            get { return threeState; }
            set { threeState = value; }
        }
        private void SetNextState(TreeNode node)
        {
            ThreeStateTreeNode tstn = node as ThreeStateTreeNode;

            if (tstn != null)
                tstn.CheckState = GetNextState(tstn.CheckState);

            node.Checked = !node.Checked; 

            TreeViewEventArgs args = new TreeViewEventArgs(node);
            this.OnAfterCheck(args);
        }
        private CheckState GetNextState(CheckState currentState)
        {
            switch( currentState )
            {
                case CheckState.Checked:
                    if (threeState)
                    {
                        if (ReverseCheckStateOrder)
                            return CheckState.Unchecked;
                        else
                            return CheckState.Indeterminate;
                    }
                    else
                       return CheckState.Unchecked;
                    
                case CheckState.Indeterminate:
                    if (ReverseCheckStateOrder)
                       return CheckState.Checked;
                    else
                       return CheckState.Unchecked;

                case CheckState.Unchecked:
                    if (threeState)
                    {
                        if (ReverseCheckStateOrder)
                            return CheckState.Indeterminate;
                        else
                            return CheckState.Checked;
                    }
                    else
                        return CheckState.Checked;
            }

            return CheckState.Unchecked; // never happens
        }
        public bool ReverseCheckStateOrder
        {
            get { return reverseCheckStateOrder; }
            set { reverseCheckStateOrder = value; }
        }
        #endregion

        private void ThreeStateTreeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                SetNextState(this.SelectedNode);
        }

        private void ThreeStateTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int startcheckbox = 0;
            if ( showPlusMinus( e.Node as ThreeStateTreeNode ) )
            {
                if (e.X < this.plusMinusWidth)
                {
                    if (e.Node.IsExpanded)
                        e.Node.Collapse();
                    else
                        e.Node.Expand();
                    
                    return;
                }
                startcheckbox += this.plusMinusWidth;
            }

            if (specialSelectMode && e.X > startcheckbox + this.checkBoxWidth)
                return;
            
            SetNextState(e.Node);
        }

        private void ThreeStateTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            ThreeStateTreeNode threeStateNode = e.Node as ThreeStateTreeNode;

            // farben für den text einstellen
            Brush brush;
            Brush brushBackground;
            if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
            {
                brush = SystemBrushes.HighlightText;
                brushBackground = SystemBrushes.Highlight;
            }
            else
            {
                brush = SystemBrushes.ControlText;
                brushBackground = SystemBrushes.ControlLightLight;
            }
         
            // den platz für das node festlegen
            Rectangle nodeRect = new Rectangle(e.Bounds.Location, e.Bounds.Size);
            // je nach level nach rechts einrücken
            nodeRect.X += this.Indent * threeStateNode.Level;
            nodeRect.Width -= this.Indent * threeStateNode.Level;

            // plus minus malen
            if (showPlusMinus(threeStateNode))
            {
                if (e.Node.Nodes.Count > 0)
                {
                    Image img;
                    if (threeStateNode.IsExpanded)
                        img = this.images.Images[0];
                    else
                        img = this.images.Images[1];

                    e.Graphics.DrawImageUnscaled(img, nodeRect);
                }
                nodeRect.X += this.plusMinusWidth;
                nodeRect.Width -= this.plusMinusWidth;
            }

            // checkbox malen
            if (threeStateNode != null && threeStateNode.HasCheckBox)
            {
                System.Windows.Forms.VisualStyles.CheckBoxState state;
                if (threeStateNode.CheckState == CheckState.Checked)
                    state = System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal;
                else if (threeStateNode.CheckState == CheckState.Unchecked)
                    state = System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal;
                else
                    state = System.Windows.Forms.VisualStyles.CheckBoxState.MixedNormal;

                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(nodeRect.X, nodeRect.Y + 2), state);
                Size s = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);

                nodeRect.X += this.checkBoxWidth;
                nodeRect.Width -= this.checkBoxWidth;
            }

            // hintergrund malen
            Rectangle rec = new Rectangle(nodeRect.X, nodeRect.Y, nodeRect.Width, nodeRect.Height);
            e.Graphics.FillRectangle(brushBackground, rec);
            
            Font f;
            if (threeStateNode != null && threeStateNode.Bold)
                f = new Font(this.Font, FontStyle.Bold);
            else
                f = this.Font;

            // text malen
            Rectangle recText = new Rectangle(nodeRect.X + 1, nodeRect.Y + 1, nodeRect.Width, nodeRect.Height);
            e.Graphics.DrawString(e.Node.Text,
                f,
                brush,
                recText, 
                new StringFormat(StringFormatFlags.NoWrap) );
        }

        private bool showPlusMinus(ThreeStateTreeNode threeStateNode)
        {
            bool showPlusMinus = this.ShowPlusMinus;
            if (threeStateNode != null)
                showPlusMinus &= threeStateNode.ShowPlusMinus;
            return showPlusMinus;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThreeStateTreeView));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "Minus.gif");
            this.images.Images.SetKeyName(1, "Plus.gif");
            // 
            // ThreeStateTreeView
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);

        }

        public void OnAfterCheckStateChanged(TreeNode node)
        {
            if (this.AfterCheckStateChanged != null)
            {
                TreeViewEventArgs args = new TreeViewEventArgs(node);
                this.AfterCheckStateChanged(this, args);
            }
        }

        #region IntegralHeight
        private bool integralHeight;
        private int borderHeight;
        public bool IntegralHeight
        {
            get { return integralHeight; }
            set { integralHeight = value; }
        }
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if (this.integralHeight)
            {
                // super einfache Lösung für die Sicherstellung von Höhen mit Vielfachen von ItemHeight  
                int tmpHeight = ((height - borderHeight) / this.ItemHeight) * this.ItemHeight + borderHeight;
                base.SetBoundsCore(x, y, width, tmpHeight, specified);
            }
            else
                base.SetBoundsCore(x, y, width, height, specified);
        }
        #endregion
    }
}