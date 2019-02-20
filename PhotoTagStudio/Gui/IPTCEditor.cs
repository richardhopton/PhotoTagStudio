#region Copyright (C) 2005-2007 Benjamin Schröter <benjamin@irgendwie.net>
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
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class IPTCEditor : PictureDetailControlBase
    {
        GroupedTagListHelper keywordTreeHelper;
        
        //view
        public IPTCEditor()
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

            this.chkGoToNext.Checked = Settings.Default.GoToNextPicture;
        }

        //view
        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayIPTCTagsWithFlickrNames")
                ShowIPTCorFlickrNames();
        }

        //ok
        protected override void ClearMyData()
        {
            this.ClearMyData(true);
        }
        //ok
        private void ClearMyData(bool beginEndUpdate)
        {
            if (beginEndUpdate)
                this.BeginUpdate();

            this.txtAuthorByline.Text = "";
            this.txtCaption.Text = "";
            this.txtCity.Text = "";
            this.txtContryCode.Text = "";
            this.txtContryName.Text = "";
            this.txtCopyright.Text = "";
            this.txtHeadline.Text = "";
            this.txtContact.Text = "";
            this.txtObjectName.Text = "";
            this.txtProvinceState.Text = "";
            this.txtSublocation.Text = "";
            this.txtWriter.Text = "";
            this.dateCreated.Value = DateTime.Now;
            this.timeCreated.Value = DateTime.Now;

            FillKeywordTree(false);

            this.chkCreatedFromExif.Checked = false;

            this.updateAuthor.Checked = false;
            this.updateCaption.Checked = false;
            this.updateCity.Checked = false;
            this.updateContact.Checked = false;
            this.updateCopyright.Checked = false;
            this.updateCountryCode.Checked = false;
            this.updateCountryName.Checked = false;
            this.updateDateCreated.Checked = false;
            this.updateHeadline.Checked = false;
            this.updateKeywords.Checked = false;
            this.updateObjectName.Checked = false;
            this.updateState.Checked = false;
            this.updateSublocation.Checked = false;
            this.updateWriter.Checked = false;

            this.buttonSave.Enabled = false;

            if (beginEndUpdate)
                this.EndUpdate();
        }
        //ok
        protected override void RefreshMyData()
        {
            askForFileSave = true;

            if (currentPicture == null)
            {
                this.ClearMyData(true);
                return;
            }

            this.BeginUpdate();

            this.ClearMyData(false);

            this.txtCity.Text = currentPicture.IptcCity;
            this.txtCaption.Text = currentPicture.IptcCaption;
            this.txtContryCode.Text = currentPicture.IptcCountryCode;
            this.txtContryName.Text = currentPicture.IptcCountryName;
            this.txtCopyright.Text = currentPicture.IptcCopyright;
            this.txtHeadline.Text = currentPicture.IptcHeadline;
            this.txtObjectName.Text = currentPicture.IptcObjectName;
            this.txtProvinceState.Text = currentPicture.IptcProvinceState;
            this.txtSublocation.Text = currentPicture.IptcSubLocation;

            if (currentPicture.ListByline().Count > 0)
                this.txtAuthorByline.Text = currentPicture.ListByline()[0];
            else
                this.txtAuthorByline.Text = "";

            if (currentPicture.ListWriter().Count > 0)
                this.txtWriter.Text = currentPicture.ListWriter()[0];
            else
                this.txtWriter.Text = "";

            if (currentPicture.ListContact().Count > 0)
                this.txtContact.Text = currentPicture.ListContact()[0];
            else
                this.txtContact.Text = "";

            if (currentPicture.IptcDateTimeCreated.HasValue)
            {
                this.dateCreated.Value = currentPicture.IptcDateTimeCreated.Value;
                this.timeCreated.Value = currentPicture.IptcDateTimeCreated.Value;
            }
            else
            {
                this.dateCreated.Value = DateTime.Now;
                this.timeCreated.Value = DateTime.Now;
            }

            FillKeywordTree(true);

            this.updateAuthor.Checked = false;
            this.updateCaption.Checked = false;
            this.updateCity.Checked = false;
            this.updateContact.Checked = false;
            this.updateCopyright.Checked = false;
            this.updateCountryCode.Checked = false;
            this.updateCountryName.Checked = false;
            this.updateHeadline.Checked = false;
            this.updateKeywords.Checked = false;
            this.updateObjectName.Checked = false;
            this.updateState.Checked = false;
            this.updateSublocation.Checked = false;
            this.updateWriter.Checked = false;

            this.chkCreatedFromExif_CheckedChanged(null, null);
            this.updateDateCreated.Checked = false;

            this.buttonSave.Enabled = true;

            this.EndUpdate();
        }
        // view
        private void FillKeywordTree(bool fromFile)
        {
            this.treeKeywords.Nodes.Clear();

            ThreeStateTreeNode defaultNode = null;
            List<string> keywords = new List<string>();
            
            // alle keywords der Datei auslesen
            if (fromFile) 
            {
                foreach (string s in currentPicture.ListKeyword())
                    keywords.Add(s);
            }
            
            // alle keywords aus den settings in den baum schreiben
            foreach (string g in Settings.Default.GroupedKeywords.GetGroups())
            {
                ThreeStateTreeNode n = new ThreeStateTreeNode(g);
                n.HasCheckBox = false;
                foreach (string v in Settings.Default.GroupedKeywords.GetValues(g))
                {
                    // wenn dieses keyword auch im file -> selektieren 
                    if (fromFile && keywords.Contains(v))
                    {
                        ThreeStateTreeNode x = new ThreeStateTreeNode(v, true);
                        x.Bold = true;
                        x.ShowPlusMinus = false;
                        n.Nodes.Add(x);
                        keywords.Remove(v);
                    }
                    else  // -> nicht selektieren
                    {
                        ThreeStateTreeNode x = new ThreeStateTreeNode(v);
                        x.CheckState = CheckState.Indeterminate;
                        x.ShowPlusMinus = false;
                        n.Nodes.Add(x);
                    }
                }
                this.treeKeywords.Nodes.Add(n);
                if ( keywordTreeHelper.ExpandNode(n.Text) )
                    n.Expand();

                if (g == GroupedTagList.DEFAULT_GROUP)
                    defaultNode = n;
            }
            
            // keywords die im file sind, aber nicht in den settings in die default grouo schreiben
            if (fromFile && keywords.Count != 0)
            {
                if (defaultNode == null)
                {
                    defaultNode = new ThreeStateTreeNode(GroupedTagList.DEFAULT_GROUP);
                    defaultNode.HasCheckBox = false;
                    this.treeKeywords.Nodes.Add(defaultNode);
                }
                foreach (string s in keywords)
                {
                    ThreeStateTreeNode x = new ThreeStateTreeNode(s, true);
                    x.Bold = true;
                    x.ShowPlusMinus = false;
                    defaultNode.Nodes.Add(x);
                }
                if ( keywordTreeHelper.ExpandNode(defaultNode.Text) )
                    defaultNode.Expand();
            }

            this.treeKeywords.UpdateSelectAllCheckBox();

            if (this.treeKeywords.Nodes.Count > 0)
                this.treeKeywords.Nodes[0].EnsureVisible();
        }
        //view
        protected override void RefreshMySettings()
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

        //model
        #region TextChanged events
        private void txtHeadline_TextChanged(object sender, EventArgs e)
        {
            this.updateHeadline.Checked = true;
        }
        private void txtCaption_TextChanged(object sender, EventArgs e)
        {
            this.updateCaption.Checked = true;
        }
        private void txtObjectName_TextChanged(object sender, EventArgs e)
        {
            this.updateObjectName.Checked = true;
        }
        private void txtWriter_TextChanged(object sender, EventArgs e)
        {
            this.updateWriter.Checked = true;
        }
        private void txtAuthorByline_TextChanged(object sender, EventArgs e)
        {
            this.updateAuthor.Checked = true;
        }
        private void txtCopyright_TextChanged(object sender, EventArgs e)
        {
            this.updateCopyright.Checked = true;
        }
        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            this.updateContact.Checked = true;
        }
        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            this.updateCity.Checked = true;
        }
        private void txtSublocation_TextChanged(object sender, EventArgs e)
        {
            this.updateSublocation.Checked = true;
        }
        private void txtProvinceState_TextChanged(object sender, EventArgs e)
        {
            this.updateState.Checked = true;
        }
        private void txtContryName_TextChanged(object sender, EventArgs e)
        {
            this.updateCountryName.Checked = true;
        }
        private void txtContryCode_TextChanged(object sender, EventArgs e)
        {
            this.updateCountryCode.Checked = true;
        }
        #endregion
        //model
        #region date / time changed
        private void dateCreated_ValueChanged(object sender, EventArgs e)
        {
            this.updateDateCreated.Checked = true;
        }
        private void timeCreated_ValueChanged(object sender, EventArgs e)
        {
            this.updateDateCreated.Checked = true;
        }
        #endregion

        //view
        private void chkCreatedFromExif_CheckedChanged(object sender, EventArgs e)
        {
            this.updateDateCreated.Checked = this.chkCreatedFromExif.Checked;
            this.dateCreated.Enabled = !this.chkCreatedFromExif.Checked;
            this.timeCreated.Enabled = !this.chkCreatedFromExif.Checked;

            if (this.chkCreatedFromExif.Checked)
            {
                if (this.currentPicture != null)
                {
                    DateTime? d = currentPicture.ExifOriginalDateTime;
                    if (d.HasValue)
                    {
                        this.dateCreated.Value = d.Value;
                        this.timeCreated.Value = d.Value;
                    }
                }
            }
        }
        //model
        private bool SaveToPicture(PictureMetaData pic, bool commit)
        {
            if (updateCaption.Checked)
            {
                pic.IptcCaption = this.txtCaption.Text;
                Settings.Default.Captions.AddIfGrowing(this.txtCaption.Text);
            }

            bool updateAnyLocation = false;
            if (updateCity.Checked)
            {
                pic.IptcCity = this.txtCity.Text;
                updateAnyLocation = true;
            }
            if (updateCountryCode.Checked)
            {
                pic.IptcCountryCode = this.txtContryCode.Text;
                updateAnyLocation = true;
            }
            if (updateCountryName.Checked)
            {
                pic.IptcCountryName = this.txtContryName.Text;
                updateAnyLocation = true;
            }
            if (updateState.Checked)
            {
                pic.IptcProvinceState = this.txtProvinceState.Text;
                updateAnyLocation = true;
            }
            if (updateSublocation.Checked)
            {
                pic.IptcSubLocation = this.txtSublocation.Text;
                updateAnyLocation = true;
            }
            if (updateAnyLocation)
            {
                Location l = new Location();
                l.City = this.txtCity.Text;
                l.Sublocation = this.txtSublocation.Text;
                l.State = this.txtProvinceState.Text;
                l.CountryName = this.txtContryName.Text;
                l.CountryCode = this.txtContryCode.Text;
                Settings.Default.Locations.AddIfGrowing(l);
            }

            if (updateCopyright.Checked)
            {
                pic.IptcCopyright = this.txtCopyright.Text;
                Settings.Default.Copyrights.AddIfGrowing(this.txtCopyright.Text);
            }

            if (updateHeadline.Checked)
            {
                pic.IptcHeadline = this.txtHeadline.Text;
                Settings.Default.Headlines.AddIfGrowing(this.txtHeadline.Text);
            }

            if (updateObjectName.Checked)
            {
                pic.IptcObjectName = this.txtObjectName.Text;
                Settings.Default.Objectnames.AddIfGrowing(this.txtObjectName.Text);
            }

            if (updateAuthor.Checked)
            {
                pic.ClearByline();
                pic.AddByline(this.txtAuthorByline.Text);
                Settings.Default.Authors.AddIfGrowing(this.txtAuthorByline.Text);
            }
            if (updateContact.Checked)
            {
                pic.ClearContact();
                pic.AddContact(this.txtContact.Text);
                Settings.Default.Contacts.AddIfGrowing(this.txtContact.Text);
            }
            if (updateWriter.Checked)
            {
                pic.ClearWriter();
                pic.AddWriter(this.txtWriter.Text);
                Settings.Default.Writers.AddIfGrowing(this.txtWriter.Text);
            }

            if (updateDateCreated.Checked)
            {
                if (chkCreatedFromExif.Checked)
                {
                    DateTime? d = pic.ExifOriginalDateTime;
                    if (d.HasValue)
                        pic.IptcDateTimeCreated = d.Value;
                }
                else
                {
                    DateTime datePart = this.dateCreated.Value;
                    DateTime timePart = this.timeCreated.Value;

                    datePart = datePart.AddHours(-datePart.Hour);
                    datePart = datePart.AddMinutes(-datePart.Minute);
                    datePart = datePart.AddSeconds(-datePart.Second);

                    datePart = datePart.AddHours(timePart.Hour);
                    datePart = datePart.AddMinutes(timePart.Minute);
                    datePart = datePart.AddSeconds(timePart.Second);

                    pic.IptcDateTimeCreated = datePart;
                }
            }

            if (updateKeywords.Checked)
            {
                List<string> keywords = pic.ListKeyword();
                foreach (ThreeStateTreeNode groupNode in this.treeKeywords.Nodes)
                    foreach (ThreeStateTreeNode node in groupNode.Nodes)
                    {
                        string nodeKeyword = node.Text;
                        string nodeGroup = node.Parent.Text;
                        bool picHasKeyword = keywords.Contains(nodeKeyword);

                        if (node.CheckState == CheckState.Checked)
                            Settings.Default.GroupedKeywords.AddIfGrowing(nodeKeyword, nodeGroup);

                        if (node.CheckState == CheckState.Indeterminate)
                            continue;

                        if (node.CheckState == CheckState.Unchecked
                            && !picHasKeyword)
                            continue;

                        if (node.CheckState == CheckState.Checked
                            && picHasKeyword)
                            continue;


                        if (node.CheckState == CheckState.Unchecked
                            && picHasKeyword)
                            pic.RemoveKeyword(nodeKeyword);
                        
                        if (node.CheckState == CheckState.Checked
                            && !picHasKeyword)
                            pic.AddKeyword(nodeKeyword);
                    }
            }

            if ( Settings.Default.RemoveThumbnailOrientation )
                if ( pic.ExifThumbnailOrientation != pic.ExifImageOrientation )
                    pic.RemoveExifThumbnailOrientation();

            if (commit)
                if (!pic.SaveChanges())
                    return this.ShowFileVanishedMsg(pic.Filename);

            return true;
        }
        //model
        private bool AnythingToDo()
        {
            return updateCaption.Checked ||
                    updateCity.Checked ||
                    updateCountryCode.Checked ||
                    updateCountryName.Checked ||
                    updateState.Checked ||
                    updateSublocation.Checked ||
                    updateCopyright.Checked ||
                    updateHeadline.Checked ||
                    updateObjectName.Checked ||
                    updateAuthor.Checked ||
                    updateContact.Checked ||
                    updateWriter.Checked ||
                    updateDateCreated.Checked ||
                    updateKeywords.Checked;
        }

        private bool askForFileSave;
        //controler
        public override RequestFileChangeResult RequestFileChange()
        {
            if (!askForFileSave)
                return RequestFileChangeResult.Close;
            if (this.currentPicture == null)
                return RequestFileChangeResult.Close;
            if (!this.currentPicture.ExistFile)
                return RequestFileChangeResult.Close;            
            if (!AnythingToDo())
                return RequestFileChangeResult.Close;
            if (!isDataLoaded)
                return RequestFileChangeResult.Close;
                
            DialogResult r = MessageBox.Show("Save changes to this picture?", "IPTC-Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (r == DialogResult.Cancel)
                return RequestFileChangeResult.DoNotClose;

            if (r == DialogResult.Yes)
            {
                MainForm f = (MainForm)this.FindForm();
                f.WaitCursor(true);
                SaveToPicture(currentPicture,false);
                f.WaitCursor(false);
                return RequestFileChangeResult.CloseAndSave;
            }

            askForFileSave = false;
            return RequestFileChangeResult.Close;
        }

        //view
        private void btnAddKeyword_Click(object sender, EventArgs e)
        {
            InputBox i = new InputBox("New tag", "Please enter the name of the new tag:", "");
            if (i.ShowDialog() == DialogResult.OK)
                if (i.Input.Trim() != "")
                {
                    ThreeStateTreeNode parent = this.treeKeywords.SelectedNode as ThreeStateTreeNode;
                    if (parent != null && parent.Parent != null)
                        parent = parent.Parent as ThreeStateTreeNode;
                    if (parent == null)
                    {
                        foreach (ThreeStateTreeNode n in this.treeKeywords.Nodes)
                            if (n.Text == GroupedTagList.DEFAULT_GROUP)
                            {
                                parent = n;
                                break;
                            }
                        if (parent == null)
                        {
                            parent = new ThreeStateTreeNode(GroupedTagList.DEFAULT_GROUP);
                            parent.HasCheckBox = false;
                            this.treeKeywords.Nodes.Add(parent);
                        }
                    }

                    ThreeStateTreeNode newnode = new ThreeStateTreeNode(i.Input.Trim(), true);
                    newnode.ShowPlusMinus = false;
                    parent.Nodes.Add(newnode);
                    parent.Expand();

                    this.updateKeywords.Checked = true;
                }
        }
        //controler
        private void buttonSave_Click(object sender, EventArgs e)
        {
            MainForm f = (MainForm)this.FindForm();
            f.WaitCursor(true);

            SaveToPicture(currentPicture,true);
            askForFileSave = false;
            FireDataChanged();
            
            if (this.chkGoToNext.Checked)
                FireRequestetGoToNext();

            f.WaitCursor(false);
        }
        //controller
        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            IStatusDisplay statusDisplay = (IStatusDisplay)this.FindForm();
            List<string> filenames = this.GetAllFileList( this.chkSubdirs.Checked );

            PauseOtherWorker();
            
            statusDisplay.WorkStart(filenames.Count);

            foreach (string filename in filenames)
            {
                PictureMetaData pmd;
                if (this.currentPicture != null 
                    && this.currentPicture.Filename == filename)
                    pmd = currentPicture;
                else
                {
                    if ( File.Exists(filename) )
                        pmd = new PictureMetaData(filename);
                    else
                        continue;
                }

                
                bool breakForeach = SaveToPicture(pmd,true) == false;                   

                if (pmd != currentPicture)
                    pmd.Close();

                if (breakForeach)
                    break;

                statusDisplay.WorkNextPart();
            }

            FireDataChanged();

            statusDisplay.WorkFinished();

            RestartOtherWorker();
        }

        //view
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

        //view
        private void txtCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txtCity.SelectedItem != null)
            {
                Location l = (Location)this.txtCity.SelectedItem;

                this.txtSublocation.Text = l.Sublocation;
                this.txtProvinceState.Text = l.State;
                this.txtContryCode.Text = l.CountryCode;
                this.txtContryName.Text = l.CountryName;
            }
        }
        //view
        private void txtCity_Format(object sender, ListControlConvertEventArgs e)
        {
            Location l = e.ListItem as Location;
            if (l != null)
                e.Value = l.City;
        }
        //view
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
        //view
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
        //view
        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.buttonSave_Click(sender, e);
        }
        //model
        private void treeKeywords_AfterCheckStateChanged(object sender, TreeViewEventArgs e)
        {
            this.updateKeywords.Checked = true;
        }
        //controler
        private void chkGoToNext_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.GoToNextPicture = this.chkGoToNext.Checked;
        }
    }
}