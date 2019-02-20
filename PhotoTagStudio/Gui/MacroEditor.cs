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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class MacroEditor : FormWithStatusDisplay
    {
        private string currentFile;
        private string startDirectory;

        private bool isDirty = false;

        public MacroEditor(string startDirectory, string loadMacroFileName) : this(startDirectory)
        {
            Macro m = Macros.OpenMacroFromFile(loadMacroFileName);
            UpdateRecentMacros();
            if (m == null)
                return;
            RefreshGui(m, loadMacroFileName);
        }

        public MacroEditor(string startDirectory)
        {
            InitializeComponent();

           // this.Icon = Resources.PTS;
            this.startDirectory = startDirectory;

            CreateAddMenu();
            CurrentFile = "";

            UpdateRecentMacros();
        }

        #region find all available models
        private struct AvailableModule
        {
            public String Name;
            public Type View;
            public Type Model;

            public AvailableModule(string name, Type view, Type model)
            {
                Name = name;
                View = view;
                Model = model;
            }

            public ModelBase CreateNewModel()
            {
                // creating a new model with the parameterless constructor
                return Model.GetConstructor(new Type[] {}).Invoke(null) as ModelBase;
            }

            public PresetableViewBase CreateNewView()
            {
                // creating a new view with the parameterless constructor
                object o = View.GetConstructor(new Type[] { }).Invoke(null);
                return o as PresetableViewBase;
            }
        }

        private static SortedList<string, AvailableModule> availableModules;
        private static SortedList<string, AvailableModule> AvailableModules
        {
            get
            {
                if (availableModules == null)
                {
                    availableModules = new SortedList<string, AvailableModule>();

                    Type macroEnabledAttributeType = typeof(MacroEnabledAttribute);
                    foreach (Type type in typeof(MacroEditor).Assembly.GetTypes())
                    {
                        object[] attributes = type.GetCustomAttributes(macroEnabledAttributeType, false);
                        if ( attributes.Length > 0 )
                        {
                            MacroEnabledAttribute meatt = attributes[0] as MacroEnabledAttribute;
                            if (meatt != null)
                                availableModules.Add(meatt.Name,new AvailableModule(meatt.Name,meatt.View,type));
                        }
                    }
                }

                return availableModules;
            }
        }
        #endregion

        #region add button and contextmenu
        private Point clickPosition;
        private void CreateAddMenu()
        {
            foreach (KeyValuePair<string, AvailableModule> availableModule in AvailableModules)
            {
                ToolStripItem i = this.contextMenuAdd.Items.Add(availableModule.Key);
                i.Tag = availableModule.Value;
                i.Click += new EventHandler(addMenuItem_Click);
            }
        }
        private void btnAddWorkItem_Click(object sender, EventArgs e)
        {
            if ( clickPosition != null)
            {
                this.contextMenuAdd.Show((Control) sender,clickPosition);
                isDirty = true;
            }
        }
        private void btnAddWorkItem_MouseDown(object sender, MouseEventArgs e)
        {
            clickPosition = e.Location;
        }
        private void addMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;
            if (tsi != null)
            {
                AvailableModule module = (AvailableModule)tsi.Tag;

                // create a model for this module
                // i use the view to create the model, if it has a default model we get this one
                PresetableViewBase view = module.CreateNewView();
                view.PreInit();
                ModelBase m = ModelBase.CloneModel(view.GetModelBase());

//                // see https://trac.irgendwie.net/PhotoTagStudio/ticket/72
//                // special for rename and copyMove - only on of them in every macro
//                if (m is RenameModel || m is CopyMoveModel)
//                {
//                    // check if there is already on of these
//                    foreach (ListViewItem l in this.listItems.Items)
//                        if (l.Tag is RenameModel || l.Tag is CopyMoveModel)
//                        {
//                            MessageBox.Show("You cannot add more than one of Renamer and Copy/Move to each macro. It makes simply no sense...",
//                                "Execute PhotoTagStudio Macro", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                            return; //do not add
//                        }
//                }

                ListViewItem lvi = new ListViewItem(module.Name);
                lvi.Tag = m;
                this.listItems.Items.Add(lvi);

                this.listItems.SelectedItems.Clear();
                lvi.Selected = true;
            }
        }
        #endregion

        #region toolbar buttons and menu
        private Macro GetCurrentMacro()
        {
            // move the focus to call validate in the current view and save the correct data
            this.txtName.Focus();

            Macro m = new Macro();
            m.Name = this.txtName.Text;
            m.Description = this.txtDescription.Text;
            foreach (ListViewItem lvi in this.listItems.Items)
            {
                ModelBase b = lvi.Tag as ModelBase;
                if (b != null)
                    m.WorkItems.Add(b);
            }
            return m;
        }

        private void buttonNewMacro_Click(object sender, EventArgs e)
        {
            if ( !CanClose() )
                return;

            ClearForm();

            CurrentFile = "";
            isDirty = false;
        }
        private void buttonOpenMacro_Click(object sender, EventArgs e)
        {
            if ( !CanClose() )
                return;            

            string s;
            Macro m = Macros.OpenMacro(this, out s);
            UpdateRecentMacros();
            if ( m == null )
                return;

            RefreshGui(m, s);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if ( currentFile == "" )
            {
                // no file name, so use save as
                buttonSaveAs_Click(sender,e);
                return;
            }

            RememberFileAndDirectory(currentFile);
            UpdateRecentMacros();

            Macro m = GetCurrentMacro();

            FileStream fs = new FileStream(currentFile, FileMode.Create);
            m.Serialize(fs);
            fs.Close();

            ResetAllIsDirty();
        }
        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            string filename = "";
            if (currentFile != "")
            {
                FileInfo fi = new FileInfo(currentFile);
                filename = fi.Name;
            }

            SaveFileDialog d = new SaveFileDialog();
            d.InitialDirectory = Settings.Default.MacroDirectory;
            d.FileName = filename;
            d.Title = "Save PhotoTagStudio macro";
            d.Filter = Macros.FILE_DIALOG_FILTER; 
            if (d.ShowDialog(this) == DialogResult.OK)
            {
                RememberFileAndDirectory(d.FileName);
                UpdateRecentMacros();

                Macro m = GetCurrentMacro();
                
                FileStream fs = new FileStream(d.FileName, FileMode.Create);
                m.Serialize(fs);
                fs.Close();

                CurrentFile = d.FileName;
            }

            ResetAllIsDirty();
        }
        private void buttonExecuteMacro_Click(object sender, EventArgs e)
        {
            Macros.ExecuteMacro(GetCurrentMacro(), startDirectory, true, this, this);
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void menuItemRecentMacro_Click(object sender, EventArgs e)
        {
            if (!CanClose())
                return;

            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            string file = (string) mi.Tag;

            Macro m =  Macros.OpenMacroFromFile(file);
            if (m == null)
                return;

            RefreshGui(m, file);
        }

        private void ResetAllIsDirty()
        {
            foreach (ListViewItem o in this.listItems.Items)
            {
                ModelBase m = o.Tag as ModelBase;
                if ( m!= null)
                    m.ResetDirty();
            }
            isDirty = false;
        }
        
        private void RefreshGui(Macro m, string s)
        {
            CurrentFile = s;

            ClearForm();

            bool cancel = false;
            foreach (ModelBase item in m.WorkItems)
            {
                string name = null;
                Type typeOfItem = item.GetType();

                // get the name
                foreach (KeyValuePair<string, AvailableModule> availableModule in AvailableModules)
                    if (availableModule.Value.Model == typeOfItem)
                    {
                        name = availableModule.Value.Name;
                        break;
                    }

                if (name == null)
                {
                    DialogResult result =
                        MessageBox.Show(
                            String.Format("The macro can not be loaded with this version of PhotoTagStudio. The module {0} is missing. If you load the macro anyway, the coresponding item will be removed.", item.GetType()),
                            "PhotoTagStudio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.OK)
                        continue;
                    else
                    {
                        cancel = true;
                        break;
                    }
                }

                ListViewItem lvi = new ListViewItem(name);
                lvi.Tag = item;
                this.listItems.Items.Add(lvi);

                item.ResetDirty();
            }

            if (!cancel)
            {
                this.txtName.Text = m.Name;
                this.txtDescription.Text = m.Description;
            }
            else
                this.listItems.Items.Clear();

            isDirty = false;
        }
        
        private bool CanClose()
        {
            if ( !isDirty )
                foreach (ListViewItem lvi in listItems.Items)
                {
                    ModelBase m = lvi.Tag as ModelBase;
                    if ( m != null )
                        if ( m.IsDirty )
                        {
                            isDirty = true;
                            break;
                        }
                }

            if ( isDirty )
            {
                DialogResult result = MessageBox.Show("The current macro has unsaved changes. Save it?",
                    "PhotoTagStudio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if ( result == DialogResult.No)
                    return true;
                else if ( result == DialogResult.Cancel )
                    return false;
                else // save? yes
                {
                    if ( currentFile == "" )
                    {
                        SaveFileDialog d = new SaveFileDialog();
                        d.InitialDirectory = Settings.Default.MacroDirectory;
                        d.Title = "Save PhotoTagStudio macro";
                        d.Filter = Macros.FILE_DIALOG_FILTER;
                        if (d.ShowDialog(this) == DialogResult.OK)
                        {
                            currentFile = d.FileName;
                            RememberFileAndDirectory(d.FileName);
                            UpdateRecentMacros();
                        }
                        else
                            return false;
                    }

                    Macro m = GetCurrentMacro();

                    FileStream fs = new FileStream(currentFile, FileMode.Create);
                    m.Serialize(fs);
                    fs.Close();

                    return true;
                }                
            }

            return true;
        }

        private void UpdateRecentMacros()
        {
            // delete all old recent entries
            List<ToolStripMenuItem> toDelete = new List<ToolStripMenuItem>();
            foreach (object o in toolStripMenuItemFile.DropDownItems)
            {
                ToolStripMenuItem mi = o as ToolStripMenuItem;
                if (mi != null && mi.Tag != null)
                    toDelete.Add(mi);
            }
            foreach (ToolStripMenuItem item in toDelete)
                toolStripMenuItemFile.DropDownItems.Remove(item);

            // add the new
            int i = 1;
            int pos = toolStripMenuItemFile.DropDownItems.IndexOf(toolStripMenuSeperatorRecent)+1;
            foreach (string s in Settings.Default.MacroRecentFiles)
            {
                FileInfo fi = new FileInfo(s);
                ToolStripMenuItem mi = new ToolStripMenuItem("&" + i++ + " " + fi.Name);
                mi.Tag = s;
                mi.Click += new EventHandler(menuItemRecentMacro_Click);
                toolStripMenuItemFile.DropDownItems.Insert(pos++,mi);
            }

            toolStripMenuSeperatorRecent.Visible = !(i == 1);
        }
        #endregion

        private void ClearForm()
        {
            this.listItems.Items.Clear();
            this.viewPanel.Controls.Clear();
            this.txtName.Text = "";
            this.txtDescription.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listItems.SelectedItems.Count == 0)
            {
                this.Cursor = Cursors.WaitCursor;
                this.viewPanel.Controls.Clear();
                this.Cursor = Cursors.Default;
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            ListViewItem lvi = listItems.SelectedItems[0];

            ModelBase model = (ModelBase)lvi.Tag;
            Type typeOfModel = model.GetType();
            PresetableViewBase view = null;

            foreach (KeyValuePair<string, AvailableModule> availableModule in AvailableModules)
                if (availableModule.Value.Model == typeOfModel)
                {
                    view = availableModule.Value.CreateNewView();
                    break;
                }

            viewPanel.Controls.Clear();
            if (view != null)
            {
                viewPanel.Controls.Add(view);
                view.Dock = DockStyle.Fill;
                view.PreInitMacroMode();

                view.SetModelBase(model);
            }

            this.Cursor = Cursors.Default;
        }
        private void listItems_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.listItems.SelectedItems.Count == 0)
                return;            
            
            ListViewItem lvi = this.listItems.SelectedItems[0];
            
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show(String.Format("Deleting {0}, are you sure?",lvi.Text),"PhotoTagStudio",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.listItems.Items.Remove(lvi);
                    if (this.listItems.Items.Count > 0)
                        this.listItems.Items[0].Selected = true;
                    else 
                        this.viewPanel.Controls.Clear();

                    isDirty = true;
                }
            }


        }

        #region Form Title
        private const string FORM_TITLE = "PhotoTagStudio - macro editor";
        private const string FORM_TITLE_WITH_FILE = "PhotoTagStudio - macro editor [{0}]";

        private string CurrentFile
        {
            get { return currentFile; }
            set
            {
                currentFile = value;

                if (currentFile == "")
                    this.Text = FORM_TITLE;
                else
                {
                    FileInfo fi = new FileInfo(currentFile);
                    this.Text = String.Format(FORM_TITLE_WITH_FILE, fi.Name);
                }
            }
        }
        #endregion

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
        }

        private void MacroEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CanClose();
        }

        private void listItems_KeyDown(object sender, KeyEventArgs e)
        {
            ListViewItem lvi = this.listItems.SelectedItems[0];

            if (e.Control && (e.KeyCode == Keys.Up))
            {
                int selectedIndex = lvi.Index;

                if (selectedIndex == 0)
                    return; //cannot move up

                this.listItems.Items.Remove(lvi);
                this.listItems.Items.Insert(selectedIndex - 1, lvi);

                isDirty = true;
            }

            if (e.Control && (e.KeyCode == Keys.Down))
            {
                int selectedIndex = lvi.Index;

                if (selectedIndex >= this.listItems.Items.Count-1)
                    return; //cannot move down

                this.listItems.Items.Remove(lvi);
                this.listItems.Items.Insert(selectedIndex + 1, lvi);

                isDirty = true;
            }
        }

        public static void RememberFileAndDirectory(string file)
        {
            FileInfo fi = new FileInfo(file);
            Settings.Default.MacroRecentFiles.Update(file);
            Settings.Default.MacroDirectory = fi.Directory.FullName;
        }
            
        #region IStatusDisplay Members

        #endregion
    }
}
