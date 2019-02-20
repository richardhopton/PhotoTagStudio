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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Raccoom.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Features.About;
using Schroeter.PhotoTagStudio.Features.Renamer;
using Schroeter.PhotoTagStudio.Gui.Setting;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.Windows.Forms;
using ShellLib;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class MainForm : FormWithStatusDisplay
    {
        private PictureDetailControlList displayControls;
        private string navigateTo;
        private string currentDirectory;

        private IptcGpsController iptcGpsController;
        private RenameController renameController;
        private PluginController pluginController;
        private ExifDateController exifDateController;

        private ToolStripProgressBar toolStripProgressBar2;
        private StatusDisplay secondStatusDisplay;
        
        public MainForm(string startDirOrFile) : this()
        {
            navigateTo = startDirOrFile.Trim();
        }

        public MainForm()
        {
            InitializeComponent();

            iptcView1.PreInit();
            exifGpsView1.PreInit();
            iptcGpsController = new IptcGpsController(this, this.iptcView1, this.exifGpsView1);
            this.buttonGpsViewSave.Click += iptcGpsController.Save_Click;            
            this.buttonGpsViewSaveAll.Click += iptcGpsController.SaveToAll_Click;
            this.buttonIptcViewSave.Click += iptcGpsController.Save_Click;
            this.buttonIptcViewSaveAll.Click += iptcGpsController.SaveToAll_Click;
            this.bindingSourceIptcGpsController.DataSource = iptcGpsController;

            renameView1.PreInit();
            renameController = new RenameController(this, this.renameView1);
            this.buttonRename.Click += renameController.Rename_Click;
            renameController.ProcessFilesInSubdirectories = this.chkRenameSubdirs.Checked;

            pluginView1.PreInit();
            pluginController = new PluginController(this, this.pluginView1);
            this.buttonPluginRun.Click += this.pluginController.Execute_Click;
            this.buttonPluginRunAll.Click +=this.pluginController.ExecuteForAll_Click;
            pluginController.ProcessFilesInSubdirectories = this.chkPluginSubdirs.Checked;

            exifDateView1.PreInit();
            exifDateController = new ExifDateController(this,exifDateView1);
            this.buttonExifDateViewSave.Click += exifDateController.Save_Click;
            this.buttonExifDateViewSaveAll.Click += exifDateController.SaveToAll_Click;
            this.bindingSourceExifDateController.DataSource = exifDateController;

            this.Icon = Resources.PTS;

            this.splitContainer1.Panel1MinSize = 100;
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer2.Panel1MinSize = 100;
            this.splitContainer2.Panel2MinSize = 325;
            this.splitContainer3.Panel2MinSize = 100;
            this.splitContainer3.Panel1MinSize = 100;

            displayControls = new PictureDetailControlList();
            displayControls.Add(this.iptcGpsController);
            displayControls.Add(this.pictureDisplay);
            displayControls.Add(this.exifDisplay1);
            displayControls.Add(this.completeTagList1);
            displayControls.Add(this.imageDisplay1);
            displayControls.Add(this.renameController);
            displayControls.Add(this.pluginController);
            displayControls.Add(this.exifDateController);

            displayControls.RegisterEvents(this.RefreshDetailViews, 
                                           this.RefreshCurrentDirectoryView, 
                                           this.RefreshDirectoryTree, 
                                           this.NavigateFiles,
                                           this.ListAllCheckedFiles, 
                                           this.ListSelectedDirectory);

            // add the secondary status display
            this.toolStripProgressBar2 = new ToolStripProgressBar();
            this.toolStripProgressBar2.Margin = new Padding(735, 3, 1, 3);
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar2.Visible = false;
            this.statusStrip.Items.Add(this.toolStripProgressBar2);
            secondStatusDisplay = new StatusDisplay(this.toolStripProgressBar2);
            this.pictureDisplay.SetStatusDisplay(secondStatusDisplay);

            UpdateRecentMacros();

            Default_PropertyChanged(null, new PropertyChangedEventArgs("VisibleTabs"));
            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Default_PropertyChanged);
        }

        void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ( e.PropertyName == "VisibleTabs" )
            {
                foreach (TabPage page in this.tabControl.AllTabPages)
                    this.tabControl.PageVisible(page, Settings.Default.VisibleTabs.Contains(page.Text));
            }
        }

        private void SaveSettings(object sender, FormClosedEventArgs e)
        {
            Settings.Default.LastWorkingDirectory = currentDirectory;
            Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1_Resize(sender, e);

            //TODO TreeViewFolderBrowserDataProvider ds = new TreeViewFolderBrowserDataProvider();
            TreeViewFolderBrowserDataProviderShell32 dss32 = new TreeViewFolderBrowserDataProviderShell32();
            this.directoryTree.DataSource = dss32;
            this.directoryTree.Populate();
            this.directoryTree.Nodes[0].Expand();

            this.fileList.BindSelectAllCheckBox(this.chkSelectAllFiles);

            this.displayControls.RefreshSettings();

            if (this.navigateTo != "")
            {
                FileInfo fi = new FileInfo(this.navigateTo);
                if (fi.Exists)
                {
                    if (fi.Extension.ToLower() == ".ptsmacro")
                    {
                        Form f = new MacroEditor(GetCurrentDirectory(),navigateTo);
                        f.ShowInTaskbar = true;
                        f.ShowDialog(this);
                        this.Close();
                    }
                    else
                    {
                        ShowSelectAndExpandFolder(fi.Directory.FullName);

                        foreach (TreeNode n in this.fileList.Nodes)
                            if (n.Tag is FileInfo)
                                if (((FileInfo) n.Tag).Name.ToUpper() == fi.Name.ToUpper())
                                {
                                    this.fileList.SelectedNode = n;
                                    break;
                                }
                    }
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(this.navigateTo);
                    if (di.Exists)
                    {
                        ShowSelectAndExpandFolder(di.FullName);
                    }
                }
            }

            this.buttonViewPreview.Checked = Settings.Default.GuiShowPreview;
            this.buttonViewFolderTree.Checked = Settings.Default.GuiShowDirectoryTree;

            MainForm_Resize(sender, e);
        }

        private void RefreshFileList(string path, bool rememberSelectedFileAndCheckState)
        {
            SaveSettings(null, null);

            // remember the currently selected file and the currently checked files
            Dictionary<string,int> checkedFiles = new Dictionary<string, int>();
            string selectedFile = "";
            if (rememberSelectedFileAndCheckState)
            {
                if (this.fileList.SelectedNode != null && this.fileList.SelectedNode.Tag is FileInfo)
                    selectedFile = ((FileInfo) this.fileList.SelectedNode.Tag).Name;
                foreach (ThreeStateTreeNode n in this.fileList.Nodes)
                    if (n.CheckState == CheckState.Checked)
                    {
                        FileInfo fi = n.Tag as FileInfo;
                        if (fi != null)
                            checkedFiles.Add(fi.Name, 0);
                    }
            }

            //this.fileList.BeginUpdate();
            this.fileList.Nodes.Clear();
            RefreshFileInfo(null);

            if (!path.StartsWith("::") && path != "")
            {
                DirectoryInfo di = new DirectoryInfo(path);
                if (di.Exists)
                {
                    currentDirectory = path;
                    
                    FileInfo[] files = di.GetFiles("*.jpg");
                    Array.Sort(files, CompareFileInfo);

                    foreach (FileInfo fi in files)
                    {
                        ThreeStateTreeNode n = new ThreeStateTreeNode(fi.Name);
                        if (rememberSelectedFileAndCheckState)
                        {
                            n.CheckState = checkedFiles.ContainsKey(fi.Name) ? CheckState.Checked : CheckState.Unchecked;
                            if (fi.Name == selectedFile)
                                this.fileList.SelectedNode = n;
                        }
                        else
                            n.CheckState = CheckState.Checked;
                        n.Tag = fi;
                        this.fileList.Nodes.Add(n);

                    }
                }
            }

            //// select the before remembed file again
            //foreach (TreeNode n in this.fileList.Nodes)
            //    if (n.Tag is FileInfo)
            //        if (((FileInfo)n.Tag).Name == file)
            //        {
            //            this.fileList.SelectedNode = n;
            //            break;
            //        }

            this.fileList.UpdateSelectAllCheckBox();

            //ShowFileCount
            this.labFileCount.Text = String.Format("{0} files", this.fileList.Nodes.Count);

            //this.fileList.EndUpdate();
        }

        private static int CompareFileInfo(FileInfo a, FileInfo b)
        {
            return a.Name.CompareTo(b.Name);
        }

        private void RefreshFileInfo(FileInfo fi)
        {
            PictureMetaData pmd;

            if (fi == null)
                pmd = null;
            else
                pmd = new PictureMetaData(fi.FullName);

            this.displayControls.UpdatePicture(pmd);
        }

        private void RefreshDetailViews()
        {
            this.displayControls.RefreshSettingsAndData();
        }
        
        private void NavigateFiles(NavigateFileOperation operation)
        {
            if (operation == NavigateFileOperation.Next || operation == NavigateFileOperation.Previous)
            {
                TreeNode n = this.fileList.SelectedNode;
                int i = this.fileList.Nodes.IndexOf(n);

                if (i == -1)
                    i = operation == NavigateFileOperation.Next ? 0 : this.fileList.Nodes.Count-1;
                else
                    i += operation == NavigateFileOperation.Next ? 1 : -1;

                if (i >=0 && i < this.fileList.Nodes.Count )
                {
                    n = this.fileList.Nodes[i];
                    this.fileList.SelectedNode = n;
                }
            }

            if ( operation == NavigateFileOperation.Delete )
            {
                TreeNode n = this.fileList.SelectedNode;
                if (n != null && n.Tag is FileSystemInfo)
                {
                    ShellFileOperation fo = new ShellFileOperation();
                    int i = this.fileList.Nodes.IndexOf(n);
                    
                    fo.Operation = ShellFileOperation.FileOperations.FO_DELETE;
                    fo.OwnerWindow = this.Handle;
                    fo.SourceFiles = new string[] { ((FileSystemInfo)n.Tag).FullName }; ;

                    bool RetVal = fo.DoOperation();
                    if (RetVal)
                    {
                        // delete was successful -> update the list
                        RefreshFileList(currentDirectory, true);

                        if (i >= this.fileList.Nodes.Count)
                            i = this.fileList.Nodes.Count - 1;

                        if (i >=0 && i < this.fileList.Nodes.Count )
                        {
                            n = this.fileList.Nodes[i];
                            this.fileList.SelectedNode = n;
                        }
                    }
                }
            }
        }

        private void RefreshCurrentDirectoryView(bool withSubdir)
        {
            string path = GetCurrentDirectory();
            if (path != "")
            {
                if (!withSubdir)
                    this.RefreshFileList(path, false);
                else
                    UpdateDirectoryTree();

                this.displayControls.UpdateDirectory(path);
            }	
        }

        private void RefreshDirectoryTree(string navigateTo)
        {
            if (navigateTo != "")
            {
                this.directoryTree.Populate();
                ShowSelectAndExpandFolder(navigateTo);
            }

            this.RefreshFileList(navigateTo,false);
        }

        private void directoryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNodePath node = e.Node as TreeNodePath;
            DirectoryInfo di = null;
            if (node != null)
                di = new DirectoryInfo(node.Path);
                
            if ( di != null && di.Exists )
            {
                this.RefreshFileList(di.FullName, false);
                this.displayControls.UpdateDirectory(di.FullName);
            }
            else
                MessageBox.Show("The directory does no longer exist!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void directoryTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

            TreeNodePath node = e.Node as TreeNodePath;
            if (node != null)
                if (node.Path.StartsWith("::") || node.Path == "")                
                    e.Cancel = true;

            if (!CanChangeFile())
                e.Cancel = true;
        }

        private void fileList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FileInfo fi = null;

            if (e.Node != null)
                fi = e.Node.Tag as FileInfo;

            if (fi != null)
            {
                fi.Refresh();
                if (fi.Exists)
                    RefreshFileInfo(fi);
                else
                    ShowWarningFileRemoved();
            }
        }

        private List<string> ListAllCheckedFiles(bool subdirectories)
        {
            bool someFileVanished = false;

            List<string> l = new List<string>();
            List<ThreeStateTreeNode> todelete = new List<ThreeStateTreeNode>();
            foreach (ThreeStateTreeNode n in this.fileList.Nodes)
                if (n.CheckState == CheckState.Checked && n.Tag is FileInfo)
                {
                    FileInfo fi = (FileInfo) n.Tag;
                    fi.Refresh();
                    if ( fi.Exists )
                        l.Add(((FileInfo)n.Tag).FullName);
                    else
                    {
                        someFileVanished = true;
                        todelete.Add(n);
                    }
                }
            //remove vanished files from list at this point
            foreach (ThreeStateTreeNode node in todelete)
                this.fileList.Nodes.Remove(node);

            if (subdirectories)
            {
                string path = GetCurrentDirectory();
                if (path != "")
                {
                    Queue<DirectoryInfo> dirs = new Queue<DirectoryInfo>();
                    DirectoryInfo di = new DirectoryInfo(path);
                    if (di.Exists)
                    {
                        foreach (DirectoryInfo d in di.GetDirectories())
                            dirs.Enqueue(d);

                        while (dirs.Count > 0)
                        {
                            DirectoryInfo dir = dirs.Dequeue();
                            if (dir.Exists)
                            {
                                FileInfo[] files = dir.GetFiles("*.jpg");
                                foreach (FileInfo file in files)
                                    l.Add(file.FullName);
                                foreach (DirectoryInfo subdir in dir.GetDirectories())
                                    dirs.Enqueue(subdir);
                            }
                        }
                    }
                    else
                        someFileVanished = true; // in fact the direcotry ist vanished
                }
            }

            if (someFileVanished)
            {
                if (MessageBox.Show("Some files has vanished. All other files will be processed.", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel )
                    l.Clear();
            }

            return l;
        }

        private List<string> ListSelectedDirectory(bool subdirectories)
        {
            string path = GetCurrentDirectory();
            if (path != "")
            {
                List<string> outputList = new List<string>();
                Queue<DirectoryInfo> queue = new Queue<DirectoryInfo>();
                queue.Enqueue(new DirectoryInfo(path));

                while (queue.Count > 0)
                {
                    DirectoryInfo dir = queue.Dequeue();
                    if (dir.Exists)
                    {
                        outputList.Insert(0,dir.FullName);
                        if ( subdirectories )
                            foreach (DirectoryInfo d in dir.GetDirectories())
                                queue.Enqueue(d);
                    }
                }

                return outputList;
            }
            else
                return new List<string>();
        }
        
        #region Menu - set parts visible
        private void viewPreview_Click(object sender, EventArgs e)
        {
            this.buttonViewPreview.Checked = !this.buttonViewPreview.Checked;
        }
        private void viewFolder_Click(object sender, EventArgs e)
        {
            this.buttonViewFolderTree.Checked = !this.buttonViewFolderTree.Checked;
        }
        private void viewPreview_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.GuiShowPreview = this.buttonViewPreview.Checked;
            this.splitContainer3.Panel2Collapsed = !this.buttonViewPreview.Checked;
            this.buttonViewPreview.Checked = this.buttonViewPreview.Checked;
        }
        private void viewFolder_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.GuiShowDirectoryTree = this.buttonViewFolderTree.Checked;
            this.splitContainer1.Panel1Collapsed = !this.buttonViewFolderTree.Checked;
            this.buttonViewFolderTree.Checked = this.buttonViewFolderTree.Checked;
        }
        #endregion

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuViewSettings_Click(object sender, EventArgs e)
        {
            SettingsForm f = new SettingsForm();
            f.ShowDialog(this);

            // todo: nur wenn sich was verändert hat
            this.displayControls.RefreshSettingsAndData();
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.ShowDialog(this);
        }

        #region F5 = refresh
        private void fileList_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    if (CanChangeFile())
                    {
                        string path = GetCurrentDirectory();
                        if (path != "")
                        {
                            this.WaitCursor(true);
                            this.RefreshFileList(path, true);
                            this.WaitCursor(false);
                        }
                    }
                    break;

                case Keys.Delete:
                    this.NavigateFiles(NavigateFileOperation.Delete);
                    break;
            }
        }

        private void directoryTree_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                this.WaitCursor(true);
                UpdateDirectoryTree();
                this.WaitCursor(false);
            }
        }

        private void UpdateDirectoryTree()
        {
            DirectoryInfo d = null;
            string path = GetCurrentDirectory();
            if ( path != "" )
                d = new DirectoryInfo(path);
                
            this.directoryTree.Populate();

            if (d != null && d.Exists)
            {
                ShowSelectAndExpandFolder(d.FullName);
                this.RefreshFileList(d.FullName, false);
            }
            else
            {
                this.directoryTree.Nodes[0].Expand();
                this.RefreshFileList("",false);
            }
        }

        #endregion

        private void menuExtrasMassTagging_Click(object sender, EventArgs e)
        {
            string path = GetCurrentDirectory();
            Features.MassTagging.MassTaggingForm f = new Features.MassTagging.MassTaggingForm(path);
            f.ShowDialog(this);

            if (f.SettingsChanged)
                this.displayControls.RefreshSettingsAndData();
        }

        private void fileList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (!CanChangeFile())
                e.Cancel = true;
        }

        private bool CanChangeFile()
        {
            RequestFileChangeResult r = this.displayControls.CanUpdatePicture();

            if (r == RequestFileChangeResult.DoNotClose)
                return false;

            if (r == RequestFileChangeResult.CloseAndSave)
                this.displayControls.CurrentPicture.SaveChanges();

            return true;
        }

        private void menuFileOpenDirectory_Click(object sender, EventArgs e)
        {
            if (!CanChangeFile())
                return;

            FolderBrowserDialog f = new FolderBrowserDialog();
            f.SelectedPath = currentDirectory;
            if (f.ShowDialog(this) == DialogResult.OK)
                ShowSelectAndExpandFolder(f.SelectedPath);
        }

        private void ShowSelectAndExpandFolder(string path)
        {
            this.directoryTree.ShowFolder(path );
            this.directoryTree.SelectedDirectories.Clear();
            this.directoryTree.SelectedDirectories.Add(path);
            this.directoryTree.SelectedNode.Expand();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.pictureDisplay.StopAllWork();
            
            if (!CanChangeFile())
                e.Cancel = true;
        }

        private void tableLayoutPanel1_Resize(object sender, EventArgs e)
        {
            int h = this.tableLayoutPanel1.GetRowHeights()[0]-10;
            this.fileList.Height = h - (h % this.fileList.ItemHeight)+3;
        }

        private void menuHelpLicense_Click(object sender, EventArgs e)
        {
            AboutAndInfo.ShowLicence(this);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Padding p = this.toolStripProgressBar2.Margin;
            p.Left = this.Width - 130;
            this.toolStripProgressBar2.Margin = p;
        }

        private void copyPhotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyMoveForm c = new CopyMoveForm();
            c.ShowDialog(this);
        }

        #region Macro
        private void newEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = GetCurrentDirectory();

            Form f = new MacroEditor(s);
            f.ShowDialog(this);

            UpdateRecentMacros();
        }
        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Macro m = Macros.OpenMacro(this);
            UpdateRecentMacros();

            if (m != null)
                Macros.ExecuteMacro(m,GetCurrentDirectory(), true, this, this);
        }

        private string GetCurrentDirectory()
        {
            string s = "";
            if ( this.directoryTree.SelectedNode != null)
                if (this.directoryTree.SelectedNode is TreeNodePath)
                {
                    s = ((TreeNodePath) this.directoryTree.SelectedNode).Path;
                    if ( s.StartsWith("::") ) 
                        s = "";
                }
            return s;
        }

        private void UpdateRecentMacros()
        {
            // delete all old recent entries
            List<ToolStripMenuItem> toDelete = new List<ToolStripMenuItem>();
            foreach (object o in macrosToolStripMenuItem.DropDownItems)               
            {
                ToolStripMenuItem mi = o as ToolStripMenuItem;
                if ( mi != null && mi.Tag != null)
                    toDelete.Add(mi);
            }
            foreach (ToolStripMenuItem item in toDelete)
                macrosToolStripMenuItem.DropDownItems.Remove(item);

            // add the new
            int i = 1;
            foreach (string s in Settings.Default.MacroRecentFiles)
            {
                FileInfo fi = new FileInfo(s);
                ToolStripMenuItem mi = new ToolStripMenuItem("&" + i++ + " " + fi.Name);
                mi.Tag = s;
                mi.Click += new EventHandler(menuItemRecentMacro_Click);
                macrosToolStripMenuItem.DropDownItems.Add(mi);
            }

            toolStripMenuSeperatorMacros.Visible = !(i == 1);
        }

        private void menuItemRecentMacro_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            string file = (string) mi.Tag;

            Macro m = Macros.OpenMacroFromFile(file);
            if ( m != null )
            {
                StandAloneMacroExecutionForm macroForm = new StandAloneMacroExecutionForm(m,"",true);
                macroForm.ShowDialog(this);
            }                
        }
        #endregion

        private void chkRenameSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            this.renameController.ProcessFilesInSubdirectories = chkRenameSubdirs.Checked;
        }

        private void chkPluginSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            this.pluginController.ProcessFilesInSubdirectories = this.chkPluginSubdirs.Checked;
        }

        private void chkGoToNext_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if ( chk != null )
            {
                this.chkExifDateViewGoToNext.Checked = chk.Checked;
                this.chkIptcViewGoToNext.Checked = chk.Checked;
                this.chkGpsViewGoToNext.Checked = chk.Checked;
            }
        }

        private void chkSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk != null)
            {
                this.chkExifDateViewSubdirs.Checked = chk.Checked;
                this.chkIptcViewSubdirs.Checked = chk.Checked;
                this.chkGpsViewSubdirs.Checked = chk.Checked;
            }
        }

        private void tabControl_PageVisibleChangedByContextMenu(object sender, PageVisibleChangedByContextMenuEventArgs e)
        {
            if (e.Visible && !Settings.Default.VisibleTabs.Contains(e.Page.Text))
                Settings.Default.VisibleTabs.Add(e.Page.Text);

            if (!e.Visible && Settings.Default.VisibleTabs.Contains(e.Page.Text))
                Settings.Default.VisibleTabs.Remove(e.Page.Text);
        }

        #region drag and drop support
        private void fileList_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging || e.Button != MouseButtons.Left)
                return;

            if (this.fileList.SelectedNode == null)
                return;

            FileInfo fi = this.fileList.SelectedNode.Tag as FileInfo;
            if (fi == null)
                return;

            fi.Refresh();
            if (fi.Exists)
                StartFileDragDrop(fi.FullName);
            else
                ShowWarningFileRemoved();
        }

        private bool isDragging = false;
        private void StartFileDragDrop(string filename)
        {
            DataObject d = new DataObject();
            StringCollection col = new StringCollection();
            col.Add(filename);
            d.SetFileDropList(col);

            // this call blocks until the drag and drop operation is completed
            isDragging = true;
            bool pictureDisplayWasWorking = pictureDisplay.StopAllWork();
            DragDropEffects effect = DoDragDrop(d, DragDropEffects.Copy | DragDropEffects.Move);
            if (pictureDisplayWasWorking)
                pictureDisplay.ReCreateAllThumbnails();
            isDragging = false;
            
            // the file was removed
            if ( !File.Exists(filename) )
            {
                this.fileList.SelectedNode.Remove();
                if ( this.fileList.SelectedNode == null )
                    RefreshFileInfo(null);
            }
        }
        #endregion

        private void ShowWarningFileRemoved()
        {
            MessageBox.Show("The file does not longer exist!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            string path = GetCurrentDirectory();
            if (path != "")
            {
                this.WaitCursor(true);
                this.RefreshFileList(path, true);
                this.WaitCursor(false);
            }
        }
    }
}