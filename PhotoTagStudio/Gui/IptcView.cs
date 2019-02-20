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
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class IptcView : PresetableViewForIptcModel
    {
        private GroupedTagListHelper keywordTreeHelper;
        private bool suspendChechBoxUpdate;

        public IptcView()
            : base()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, false);
            this.UpdateStyles();

            this.treeKeywords.BindSelectAllCheckBox(this.chkSelectAllKeywords);
            keywordTreeHelper = new GroupedTagListHelper(this.treeKeywords, Settings.Default.GroupedKeywords);
            keywordTreeHelper.RegisterDragDrop();
            keywordTreeHelper.RegisterCollapsMemory();

            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);
            ShowIPTCorFlickrNames();

            this.nullableDateTimePicker1.CustomFormat = GuiUtils.GetShortDateLongTimeFormatPattern();
        }

        public override void SetModel(IptcModel m)
        {
            this.BeginUpdate();

            base.SetModel(m);

            suspendChechBoxUpdate = true;
            this.bindingSource.DataSource = this.model;            
            suspendChechBoxUpdate = false;

            FillKeywordTree();
            
            this.EndUpdate();
        }

        public override void PreInit()
        {
            RefreshSettings();

            base.PreInit();
        }

        #region keyword tree
        private void FillKeywordTree() 
        {
            this.treeKeywords.Nodes.Clear();

            ThreeStateTreeNode defaultNode = null;
            List<string> neededKeywords = new List<string>();

            foreach (string s in model.KeywordsChecked)
                neededKeywords.Add(s);
            foreach (string s in model.KeywordsUnchecked)
                neededKeywords.Add(s);

            // alle keywords aus den settings in den baum schreiben
            foreach (string g in Settings.Default.GroupedKeywords.GetGroups())
            {
                ThreeStateTreeNode n = new ThreeStateTreeNode(g);
                n.HasCheckBox = false;
                foreach (string v in Settings.Default.GroupedKeywords.GetValues(g))
                {
                    n.Nodes.Add(newNode(v));
                    
                    if (neededKeywords.Contains(v))
                        neededKeywords.Remove(v);
                }
                this.treeKeywords.Nodes.Add(n);
                if (keywordTreeHelper.ExpandNode(n.Text))
                    n.Expand();

                if (g == GroupedTagList.DEFAULT_GROUP)
                    defaultNode = n;
            }
            
            // keywords die im file sind, aber nicht in den settings in die default grouo schreiben
            if (neededKeywords.Count != 0)
            {
                if (defaultNode == null)
                {
                    defaultNode = new ThreeStateTreeNode(GroupedTagList.DEFAULT_GROUP);
                    defaultNode.HasCheckBox = false;
                    this.treeKeywords.Nodes.Add(defaultNode);
                }
                foreach (string s in neededKeywords)
                    defaultNode.Nodes.Add(newNode(s));

                if (keywordTreeHelper.ExpandNode(defaultNode.Text))
                    defaultNode.Expand();
            }

            this.treeKeywords.UpdateSelectAllCheckBox();

            if (this.treeKeywords.Nodes.Count > 0)
                this.treeKeywords.Nodes[0].EnsureVisible();

            if ( Settings.Default.CollapseIptcKeywordGroupsOnStartup )
                treeKeywords.CollapseAll();
        }

        private ThreeStateTreeNode newNode(string name)
        {
            ThreeStateTreeNode node = new ThreeStateTreeNode(name);

            if (model.KeywordsChecked.Contains(name))
                node.CheckState = CheckState.Checked;
            else if (model.KeywordsUnchecked.Contains(name))
                node.CheckState = CheckState.Unchecked;
            else
                node.CheckState = CheckState.Indeterminate;
            
            node.Bold = model.KeywordsBold.Contains(name);

            node.ShowPlusMinus = false;
            return node;
        }

        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            InputBox i = new InputBox("New tag", "Please enter the name of the new tag:", "");
            if (i.ShowDialog(this.FindForm()) == DialogResult.OK)
            {
                string name = i.Input.Trim();
                if (name != "")
                {
                    // find the parent node
                    ThreeStateTreeNode parent = this.treeKeywords.SelectedNode as ThreeStateTreeNode;
                    if (parent != null && parent.Parent != null)
                        parent = parent.Parent as ThreeStateTreeNode;
                    if (parent == null)
                    {
                        // finde the default group as parent
                        foreach (ThreeStateTreeNode n in this.treeKeywords.Nodes)
                            if (n.Text == GroupedTagList.DEFAULT_GROUP)
                            {
                                parent = n;
                                break;
                            }
                        if (parent == null)
                        {
                            // create the default group
                            parent = new ThreeStateTreeNode(GroupedTagList.DEFAULT_GROUP);
                            parent.HasCheckBox = false;
                            this.treeKeywords.Nodes.Add(parent);
                        }
                    }

                    ThreeStateTreeNode newnode = new ThreeStateTreeNode(name, true);
                    newnode.ShowPlusMinus = false;
                    parent.Nodes.Add(newnode);
                    parent.Expand();

                    model.SetKeyword(name,CheckState.Checked);
                    model.SetNewKeyword(name,parent.Text);
                }
            }
        }

        private void treeKeywords_AfterCheckStateChanged(object sender, TreeViewEventArgs e)
        {
            ThreeStateTreeNode n = e.Node as ThreeStateTreeNode;
            if ( n != null )
                model.SetKeyword(n.Text, n.CheckState );
        }
        #endregion

        #region dll import / BeginUpdate / EndUpdate
        private const int WM_SETREDRAW = 0x000B;

        [DllImport("user32", CharSet = CharSet.Auto)]
        private extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);

        private void SetRedraw(bool b)
        {
            foreach (Control c in this.Controls)
                SendMessage(c.Handle, WM_SETREDRAW, b ? 1 : 0, IntPtr.Zero);
        }
        public void BeginUpdate()
        {
            SetRedraw(false);
        }

        public void EndUpdate()
        {
            SetRedraw(true);
            this.Refresh();
        }
        #endregion

        #region everything for the CityComboBoy
        private void txtCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtCity.SelectedItem != null && !suspendChechBoxUpdate)
            {
                Location l = (Location)this.txtCity.SelectedItem;

                this.txtSublocation.Text = l.Sublocation;
                this.txtProvinceState.Text = l.State;
                this.txtContryCode.Text = l.CountryCode;
                this.txtContryName.Text = l.CountryName;
            }
        }

        private void txtCity_Format(object sender, ListControlConvertEventArgs e)
        {
            Location l = e.ListItem as Location;
            if (l != null)
                e.Value = l.City;
        }

        private void txtCity_DrawItem(object sender, DrawItemEventArgs e)
        {
            /*
             *  Das Control auf OwnerDraw umstellen
             *  DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
             * 
             *  DropDownList wenn nur Werte aus der Liste als Auswahl zulässig sind,
             *  ansonsten kann auch DropDown verwendet werden, dann sollte jedoch die Entscheidung unten
             *  entfernt werden
             *  DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             * 
             */
            // Hintergrund löschen
            e.DrawBackground();
            // sollte kein Element gewählt sein, dann gibt es nichts zu zeichnen
            if (e.Index != -1)
            {
                Brush brush;
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                    brush = SystemBrushes.HighlightText;
                else
                    brush = SystemBrushes.ControlText;

                // Eintrag im Control zeichnen
                e.Graphics.DrawString(
                    this.txtCity.Items[e.Index].ToString(),
                    this.txtCity.Font,
                    brush,
                    new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

            }
            // aktuelles Element hervorheben
            e.DrawFocusRectangle();

        }
        #endregion

        #region ShowIPTCorFlickrNames
        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayIPTCTagsWithFlickrNames")
                ShowIPTCorFlickrNames();
        }
        private void ShowIPTCorFlickrNames()
        {
            this.BeginUpdate();

            bool flickrNames = Settings.Default.DisplayIPTCTagsWithFlickrNames;

            Font f = new Font(this.labelKeywords.Font, flickrNames ? FontStyle.Bold : FontStyle.Regular);

            this.labelKeywords.Font = f;
            this.labelCity.Font = f;
            this.labelProvinceState.Font = f;
            this.labelCountryName.Font = f;
            this.labelObjectName.Font = f;
            this.labelCaption.Font = f;

            if (flickrNames)
            {
                this.labelKeywords.Text = "Tags:";
                this.labelObjectName.Text = "Title:";
                this.labelCaption.Text = "Description:";
            }
            else
            {
                this.labelKeywords.Text = "Keywords:";
                this.labelObjectName.Text = "Object Name:";
                this.labelCaption.Text = "Caption:";
            }

            this.EndUpdate();
        }
        #endregion

        #region the date/time fields
        private void chkCreatedFromExif_CheckedChanged(object sender, EventArgs e)
        {
            this.nullableDateTimePicker1.Enabled =  !this.chkCreatedFromExif.Checked;
        }
        #endregion

        public void RefreshSettings()
        {
            this.BeginUpdate();

            this.txtAuthorByline.DataSource = null;
            this.txtAuthorByline.DataSource = Settings.Default.Authors.Data;
            this.txtAuthorByline.SelectedItem = null;
            this.txtCaption.DataSource = null;
            this.txtCaption.DataSource = Settings.Default.Captions.Data;
            this.txtCaption.SelectedItem = null;
            this.txtContact.DataSource = null;
            this.txtContact.DataSource = Settings.Default.Contacts.Data;
            this.txtContact.SelectedItem = null;
            this.txtCopyright.DataSource = null;
            this.txtCopyright.DataSource = Settings.Default.Copyrights.Data;
            this.txtCopyright.SelectedItem = null;
            this.txtHeadline.DataSource = null;
            this.txtHeadline.DataSource = Settings.Default.Headlines.Data;
            this.txtHeadline.SelectedItem = null;
            this.txtObjectName.DataSource = null;
            this.txtObjectName.DataSource = Settings.Default.Objectnames.Data;
            this.txtObjectName.SelectedItem = null;
            this.txtWriter.DataSource = null;
            this.txtWriter.DataSource = Settings.Default.Writers.Data;
            this.txtWriter.SelectedItem = null;

            this.txtCity.DataSource = null;
            this.txtCity.DataSource = Settings.Default.Locations.Data;
            this.txtCity.SelectedItem = null;

            this.EndUpdate();
        }

        #region workaround for the vs2005 designer
        // the form designer didn't like it to call eventhandlers in the base classes
        protected override void txt_KeyDown(object sender, KeyEventArgs e)
        {
            base.txt_KeyDown(sender, e);
        }

        protected override void txt_KeyUp(object sender, KeyEventArgs e)
        {
            base.txt_KeyUp(sender, e);
        }
        #endregion
    }

    // workaround, the visual studio (2005 and orcas beta 2) cannot design 
    // a control deriverd from PresetableView<CopyMoveModel> :-(
    // but PresetableViewForCopyMoveModel is fine :-)
    public class PresetableViewForIptcModel : KeyboardInteractionPresetableView<IptcModel>
    {
    }
}