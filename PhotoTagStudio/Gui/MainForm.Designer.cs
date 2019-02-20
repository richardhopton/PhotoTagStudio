namespace Schroeter.PhotoTagStudio.Gui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuViewSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.macrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSeperatorMacros = new System.Windows.Forms.ToolStripSeparator();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExtrasMassTagging = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPhotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelpLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonOpenDirectory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonViewFolderTree = new System.Windows.Forms.ToolStripButton();
            this.buttonViewPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.directoryTree = new Raccoom.Windows.Forms.TreeViewFolderBrowser();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkSelectAllFiles = new System.Windows.Forms.CheckBox();
            this.fileList = new Schroeter.Windows.Forms.ThreeStateTreeView();
            this.labFileCount = new System.Windows.Forms.Label();
            this.pictureDisplay = new Schroeter.PhotoTagStudio.Gui.PictureDisplay();
            this.tabControl = new Schroeter.Windows.Forms.TabControlWithHiddenTab();
            this.tabPageIptc = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonIptcViewSave = new System.Windows.Forms.Button();
            this.iptcView1 = new Schroeter.PhotoTagStudio.Gui.IptcView();
            this.chkIptcViewGoToNext = new System.Windows.Forms.CheckBox();
            this.bindingSourceIptcGpsController = new System.Windows.Forms.BindingSource(this.components);
            this.buttonIptcViewSaveAll = new System.Windows.Forms.Button();
            this.chkIptcViewSubdirs = new System.Windows.Forms.CheckBox();
            this.tabPageGps = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exifGpsView1 = new Schroeter.PhotoTagStudio.Gui.ExifGpsView();
            this.chkGpsViewGoToNext = new System.Windows.Forms.CheckBox();
            this.buttonGpsViewSave = new System.Windows.Forms.Button();
            this.chkGpsViewSubdirs = new System.Windows.Forms.CheckBox();
            this.buttonGpsViewSaveAll = new System.Windows.Forms.Button();
            this.tabPageEXIF = new System.Windows.Forms.TabPage();
            this.exifDisplay1 = new Schroeter.PhotoTagStudio.Gui.ExifDisplay();
            this.tabPageExifDates = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonExifDateViewSave = new System.Windows.Forms.Button();
            this.exifDateView1 = new Schroeter.PhotoTagStudio.Gui.ExifDateView();
            this.chkExifDateViewGoToNext = new System.Windows.Forms.CheckBox();
            this.bindingSourceExifDateController = new System.Windows.Forms.BindingSource(this.components);
            this.chkExifDateViewSubdirs = new System.Windows.Forms.CheckBox();
            this.buttonExifDateViewSaveAll = new System.Windows.Forms.Button();
            this.tabPageJPEG = new System.Windows.Forms.TabPage();
            this.imageDisplay1 = new Schroeter.PhotoTagStudio.Gui.ImageDisplay();
            this.tabPageAll = new System.Windows.Forms.TabPage();
            this.completeTagList1 = new Schroeter.PhotoTagStudio.Gui.CompleteTagList();
            this.tabPageRename = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.renameView1 = new Schroeter.PhotoTagStudio.Gui.RenameView();
            this.chkRenameSubdirs = new System.Windows.Forms.CheckBox();
            this.buttonRename = new System.Windows.Forms.Button();
            this.tabPagePlugins = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonPluginRun = new System.Windows.Forms.Button();
            this.buttonPluginRunAll = new System.Windows.Forms.Button();
            this.chkPluginSubdirs = new System.Windows.Forms.CheckBox();
            this.pluginView1 = new Schroeter.PhotoTagStudio.Gui.PluginView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageIptc.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceIptcGpsController)).BeginInit();
            this.tabPageGps.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPageEXIF.SuspendLayout();
            this.tabPageExifDates.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExifDateController)).BeginInit();
            this.tabPageJPEG.SuspendLayout();
            this.tabPageAll.SuspendLayout();
            this.tabPageRename.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPagePlugins.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.macrosToolStripMenuItem,
            this.extrasToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(962, 23);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileOpenDirectory,
            this.toolStripMenuItem2,
            this.menuFileExit});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // menuFileOpenDirectory
            // 
            this.menuFileOpenDirectory.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.openfolderHS;
            this.menuFileOpenDirectory.Name = "menuFileOpenDirectory";
            this.menuFileOpenDirectory.Size = new System.Drawing.Size(162, 22);
            this.menuFileOpenDirectory.Text = "Open &directory...";
            this.menuFileOpenDirectory.Click += new System.EventHandler(this.menuFileOpenDirectory_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(162, 22);
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewFolder,
            this.menuViewPreview,
            this.toolStripMenuItem1,
            this.menuViewSettings});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // menuViewFolder
            // 
            this.menuViewFolder.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.TreeView;
            this.menuViewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuViewFolder.Name = "menuViewFolder";
            this.menuViewFolder.Size = new System.Drawing.Size(125, 22);
            this.menuViewFolder.Text = "&Folder";
            this.menuViewFolder.Click += new System.EventHandler(this.viewFolder_Click);
            // 
            // menuViewPreview
            // 
            this.menuViewPreview.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.Picture;
            this.menuViewPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuViewPreview.Name = "menuViewPreview";
            this.menuViewPreview.Size = new System.Drawing.Size(125, 22);
            this.menuViewPreview.Text = "&Preview";
            this.menuViewPreview.Click += new System.EventHandler(this.viewPreview_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
            // 
            // menuViewSettings
            // 
            this.menuViewSettings.Name = "menuViewSettings";
            this.menuViewSettings.Size = new System.Drawing.Size(125, 22);
            this.menuViewSettings.Text = "&Settings...";
            this.menuViewSettings.Click += new System.EventHandler(this.menuViewSettings_Click);
            // 
            // macrosToolStripMenuItem
            // 
            this.macrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEditToolStripMenuItem,
            this.executeToolStripMenuItem,
            this.toolStripMenuSeperatorMacros});
            this.macrosToolStripMenuItem.Name = "macrosToolStripMenuItem";
            this.macrosToolStripMenuItem.Size = new System.Drawing.Size(58, 19);
            this.macrosToolStripMenuItem.Text = "&Macros";
            // 
            // newEditToolStripMenuItem
            // 
            this.newEditToolStripMenuItem.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.RecorderPlayHS;
            this.newEditToolStripMenuItem.Name = "newEditToolStripMenuItem";
            this.newEditToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newEditToolStripMenuItem.Text = "&New / Edit...";
            this.newEditToolStripMenuItem.Click += new System.EventHandler(this.newEditToolStripMenuItem_Click);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.executeToolStripMenuItem.Text = "&Execute...";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // toolStripMenuSeperatorMacros
            // 
            this.toolStripMenuSeperatorMacros.Name = "toolStripMenuSeperatorMacros";
            this.toolStripMenuSeperatorMacros.Size = new System.Drawing.Size(135, 6);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExtrasMassTagging,
            this.copyPhotosToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 19);
            this.extrasToolStripMenuItem.Text = "&Extras";
            // 
            // menuExtrasMassTagging
            // 
            this.menuExtrasMassTagging.Name = "menuExtrasMassTagging";
            this.menuExtrasMassTagging.Size = new System.Drawing.Size(154, 22);
            this.menuExtrasMassTagging.Text = "&Mass tagging...";
            this.menuExtrasMassTagging.Click += new System.EventHandler(this.menuExtrasMassTagging_Click);
            // 
            // copyPhotosToolStripMenuItem
            // 
            this.copyPhotosToolStripMenuItem.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.MoveToFolderHS;
            this.copyPhotosToolStripMenuItem.Name = "copyPhotosToolStripMenuItem";
            this.copyPhotosToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.copyPhotosToolStripMenuItem.Text = "&Copy photos...";
            this.copyPhotosToolStripMenuItem.Click += new System.EventHandler(this.copyPhotosToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuHelpLicense,
            this.menuHelpAbout});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem1.Text = "&Help";
            // 
            // MenuHelpLicense
            // 
            this.MenuHelpLicense.Name = "MenuHelpLicense";
            this.MenuHelpLicense.Size = new System.Drawing.Size(122, 22);
            this.MenuHelpLicense.Text = "&License...";
            this.MenuHelpLicense.Click += new System.EventHandler(this.menuHelpLicense_Click);
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            this.menuHelpAbout.Size = new System.Drawing.Size(122, 22);
            this.menuHelpAbout.Text = "&About...";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpenDirectory,
            this.toolStripSeparator1,
            this.buttonViewFolderTree,
            this.buttonViewPreview,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton3});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(962, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonOpenDirectory
            // 
            this.buttonOpenDirectory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonOpenDirectory.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.openfolderHS;
            this.buttonOpenDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOpenDirectory.Name = "buttonOpenDirectory";
            this.buttonOpenDirectory.Size = new System.Drawing.Size(23, 20);
            this.buttonOpenDirectory.Text = "Open directory";
            this.buttonOpenDirectory.Click += new System.EventHandler(this.menuFileOpenDirectory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonViewFolderTree
            // 
            this.buttonViewFolderTree.Checked = true;
            this.buttonViewFolderTree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonViewFolderTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonViewFolderTree.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.TreeView;
            this.buttonViewFolderTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonViewFolderTree.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.buttonViewFolderTree.Name = "buttonViewFolderTree";
            this.buttonViewFolderTree.Size = new System.Drawing.Size(23, 20);
            this.buttonViewFolderTree.Text = "View folder";
            this.buttonViewFolderTree.CheckedChanged += new System.EventHandler(this.viewFolder_CheckedChanged);
            this.buttonViewFolderTree.Click += new System.EventHandler(this.viewFolder_Click);
            // 
            // buttonViewPreview
            // 
            this.buttonViewPreview.Checked = true;
            this.buttonViewPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buttonViewPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonViewPreview.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.Picture;
            this.buttonViewPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonViewPreview.Margin = new System.Windows.Forms.Padding(0, 1, 3, 2);
            this.buttonViewPreview.Name = "buttonViewPreview";
            this.buttonViewPreview.Size = new System.Drawing.Size(23, 20);
            this.buttonViewPreview.Text = "View preview";
            this.buttonViewPreview.CheckedChanged += new System.EventHandler(this.viewPreview_CheckedChanged);
            this.buttonViewPreview.Click += new System.EventHandler(this.viewPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.RecorderPlayHS;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton1.Text = "Open macro editor";
            this.toolStripButton1.Click += new System.EventHandler(this.newEditToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Schroeter.PhotoTagStudio.Properties.Resources.MoveToFolderHS;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton3.Text = "Open copy photo window";
            this.toolStripButton3.Click += new System.EventHandler(this.copyPhotosToolStripMenuItem_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 488);
            this.panel1.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.directoryTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(962, 488);
            this.splitContainer1.SplitterDistance = 283;
            this.splitContainer1.TabIndex = 6;
            this.splitContainer1.TabStop = false;
            // 
            // directoryTree
            // 
            this.directoryTree.CheckboxBehaviorMode = Raccoom.Windows.Forms.CheckboxBehaviorMode.None;
            this.directoryTree.DataSource = null;
            this.directoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoryTree.HideSelection = false;
            this.directoryTree.Location = new System.Drawing.Point(0, 0);
            this.directoryTree.Name = "directoryTree";
            this.directoryTree.RootFolder = System.Environment.SpecialFolder.Desktop;
            this.directoryTree.SelectedDirectories = ((System.Collections.Specialized.StringCollection)(resources.GetObject("directoryTree.SelectedDirectories")));
            this.directoryTree.Size = new System.Drawing.Size(283, 488);
            this.directoryTree.TabIndex = 0;
            this.directoryTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.directoryTree_AfterSelect);
            this.directoryTree.KeyUp += new System.Windows.Forms.KeyEventHandler(this.directoryTree_KeyUp);
            this.directoryTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.directoryTree_BeforeSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl);
            this.splitContainer2.Size = new System.Drawing.Size(675, 488);
            this.splitContainer2.SplitterDistance = 242;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pictureDisplay);
            this.splitContainer3.Size = new System.Drawing.Size(242, 488);
            this.splitContainer3.SplitterDistance = 254;
            this.splitContainer3.TabIndex = 0;
            this.splitContainer3.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chkSelectAllFiles, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.fileList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labFileCount, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(242, 254);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Resize += new System.EventHandler(this.tableLayoutPanel1_Resize);
            // 
            // chkSelectAllFiles
            // 
            this.chkSelectAllFiles.AutoSize = true;
            this.chkSelectAllFiles.Location = new System.Drawing.Point(3, 234);
            this.chkSelectAllFiles.Name = "chkSelectAllFiles";
            this.chkSelectAllFiles.Size = new System.Drawing.Size(67, 17);
            this.chkSelectAllFiles.TabIndex = 1;
            this.chkSelectAllFiles.Text = "select all";
            this.chkSelectAllFiles.ThreeState = true;
            this.chkSelectAllFiles.UseVisualStyleBackColor = true;
            // 
            // fileList
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.fileList, 2);
            this.fileList.Dock = System.Windows.Forms.DockStyle.Top;
            this.fileList.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.fileList.FullRowSelect = true;
            this.fileList.HideSelection = false;
            this.fileList.IntegralHeight = true;
            this.fileList.Location = new System.Drawing.Point(3, 3);
            this.fileList.Name = "fileList";
            this.fileList.ReverseCheckStateOrder = false;
            this.fileList.ShowLines = false;
            this.fileList.ShowPlusMinus = false;
            this.fileList.ShowRootLines = false;
            this.fileList.Size = new System.Drawing.Size(236, 211);
            this.fileList.SpecialSelectMode = true;
            this.fileList.TabIndex = 2;
            this.fileList.ThreeState = false;
            this.fileList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.fileList_AfterSelect);
            this.fileList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.fileList_MouseMove);
            this.fileList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fileList_KeyUp);
            this.fileList.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.fileList_BeforeSelect);
            // 
            // labFileCount
            // 
            this.labFileCount.AutoSize = true;
            this.labFileCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFileCount.Location = new System.Drawing.Point(76, 231);
            this.labFileCount.Name = "labFileCount";
            this.labFileCount.Size = new System.Drawing.Size(163, 23);
            this.labFileCount.TabIndex = 3;
            this.labFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureDisplay
            // 
            this.pictureDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureDisplay.Location = new System.Drawing.Point(0, 0);
            this.pictureDisplay.Name = "pictureDisplay";
            this.pictureDisplay.Size = new System.Drawing.Size(242, 230);
            this.pictureDisplay.TabIndex = 0;
            this.pictureDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fileList_MouseMove);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageIptc);
            this.tabControl.Controls.Add(this.tabPageGps);
            this.tabControl.Controls.Add(this.tabPageEXIF);
            this.tabControl.Controls.Add(this.tabPageExifDates);
            this.tabControl.Controls.Add(this.tabPageJPEG);
            this.tabControl.Controls.Add(this.tabPageAll);
            this.tabControl.Controls.Add(this.tabPageRename);
            this.tabControl.Controls.Add(this.tabPagePlugins);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(429, 488);
            this.tabControl.TabIndex = 0;
            this.tabControl.PageVisibleChangedByContextMenu += new System.EventHandler<Schroeter.Windows.Forms.PageVisibleChangedByContextMenuEventArgs>(this.tabControl_PageVisibleChangedByContextMenu);
            // 
            // tabPageIptc
            // 
            this.tabPageIptc.Controls.Add(this.panel3);
            this.tabPageIptc.Location = new System.Drawing.Point(4, 22);
            this.tabPageIptc.Name = "tabPageIptc";
            this.tabPageIptc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIptc.Size = new System.Drawing.Size(421, 462);
            this.tabPageIptc.TabIndex = 10;
            this.tabPageIptc.Tag = 1;
            this.tabPageIptc.Text = "IPTC";
            this.tabPageIptc.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonIptcViewSave);
            this.panel3.Controls.Add(this.iptcView1);
            this.panel3.Controls.Add(this.chkIptcViewGoToNext);
            this.panel3.Controls.Add(this.buttonIptcViewSaveAll);
            this.panel3.Controls.Add(this.chkIptcViewSubdirs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(415, 456);
            this.panel3.TabIndex = 9;
            // 
            // buttonIptcViewSave
            // 
            this.buttonIptcViewSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIptcViewSave.Location = new System.Drawing.Point(372, 430);
            this.buttonIptcViewSave.Name = "buttonIptcViewSave";
            this.buttonIptcViewSave.Size = new System.Drawing.Size(40, 23);
            this.buttonIptcViewSave.TabIndex = 4;
            this.buttonIptcViewSave.Text = "Save";
            this.buttonIptcViewSave.UseVisualStyleBackColor = true;
            // 
            // iptcView1
            // 
            this.iptcView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.iptcView1.Location = new System.Drawing.Point(3, 3);
            this.iptcView1.Name = "iptcView1";
            this.iptcView1.Size = new System.Drawing.Size(409, 421);
            this.iptcView1.TabIndex = 0;
            // 
            // chkIptcViewGoToNext
            // 
            this.chkIptcViewGoToNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIptcViewGoToNext.AutoSize = true;
            this.chkIptcViewGoToNext.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceIptcGpsController, "GoToNextFileAfterSave", true));
            this.chkIptcViewGoToNext.Location = new System.Drawing.Point(43, 434);
            this.chkIptcViewGoToNext.Name = "chkIptcViewGoToNext";
            this.chkIptcViewGoToNext.Size = new System.Drawing.Size(73, 17);
            this.chkIptcViewGoToNext.TabIndex = 7;
            this.chkIptcViewGoToNext.Text = "go to next";
            this.chkIptcViewGoToNext.UseVisualStyleBackColor = true;
            this.chkIptcViewGoToNext.CheckedChanged += new System.EventHandler(this.chkGoToNext_CheckedChanged);
            // 
            // bindingSourceIptcGpsController
            // 
            this.bindingSourceIptcGpsController.DataSource = typeof(Schroeter.PhotoTagStudio.IptcGpsController);
            // 
            // buttonIptcViewSaveAll
            // 
            this.buttonIptcViewSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIptcViewSaveAll.Location = new System.Drawing.Point(291, 430);
            this.buttonIptcViewSaveAll.Name = "buttonIptcViewSaveAll";
            this.buttonIptcViewSaveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonIptcViewSaveAll.TabIndex = 5;
            this.buttonIptcViewSaveAll.Text = "Save to all";
            this.buttonIptcViewSaveAll.UseVisualStyleBackColor = true;
            // 
            // chkIptcViewSubdirs
            // 
            this.chkIptcViewSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIptcViewSubdirs.AutoSize = true;
            this.chkIptcViewSubdirs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceIptcGpsController, "ProcessFilesInSubdirectories", true));
            this.chkIptcViewSubdirs.Location = new System.Drawing.Point(122, 434);
            this.chkIptcViewSubdirs.Name = "chkIptcViewSubdirs";
            this.chkIptcViewSubdirs.Size = new System.Drawing.Size(163, 17);
            this.chkIptcViewSubdirs.TabIndex = 6;
            this.chkIptcViewSubdirs.Text = "process files in subdirectories";
            this.chkIptcViewSubdirs.UseVisualStyleBackColor = true;
            this.chkIptcViewSubdirs.CheckedChanged += new System.EventHandler(this.chkSubdirs_CheckedChanged);
            // 
            // tabPageGps
            // 
            this.tabPageGps.Controls.Add(this.panel2);
            this.tabPageGps.Location = new System.Drawing.Point(4, 22);
            this.tabPageGps.Name = "tabPageGps";
            this.tabPageGps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGps.Size = new System.Drawing.Size(421, 462);
            this.tabPageGps.TabIndex = 9;
            this.tabPageGps.Tag = 2;
            this.tabPageGps.Text = "GPS";
            this.tabPageGps.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.exifGpsView1);
            this.panel2.Controls.Add(this.chkGpsViewGoToNext);
            this.panel2.Controls.Add(this.buttonGpsViewSave);
            this.panel2.Controls.Add(this.chkGpsViewSubdirs);
            this.panel2.Controls.Add(this.buttonGpsViewSaveAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 456);
            this.panel2.TabIndex = 24;
            // 
            // exifGpsView1
            // 
            this.exifGpsView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exifGpsView1.Location = new System.Drawing.Point(3, 3);
            this.exifGpsView1.Name = "exifGpsView1";
            this.exifGpsView1.Size = new System.Drawing.Size(409, 421);
            this.exifGpsView1.TabIndex = 22;
            // 
            // chkGpsViewGoToNext
            // 
            this.chkGpsViewGoToNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGpsViewGoToNext.AutoSize = true;
            this.chkGpsViewGoToNext.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceIptcGpsController, "GoToNextFileAfterSave", true));
            this.chkGpsViewGoToNext.Location = new System.Drawing.Point(43, 434);
            this.chkGpsViewGoToNext.Name = "chkGpsViewGoToNext";
            this.chkGpsViewGoToNext.Size = new System.Drawing.Size(73, 17);
            this.chkGpsViewGoToNext.TabIndex = 21;
            this.chkGpsViewGoToNext.Text = "go to next";
            this.chkGpsViewGoToNext.UseVisualStyleBackColor = true;
            this.chkGpsViewGoToNext.CheckedChanged += new System.EventHandler(this.chkGoToNext_CheckedChanged);
            // 
            // buttonGpsViewSave
            // 
            this.buttonGpsViewSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGpsViewSave.Location = new System.Drawing.Point(372, 430);
            this.buttonGpsViewSave.Name = "buttonGpsViewSave";
            this.buttonGpsViewSave.Size = new System.Drawing.Size(40, 23);
            this.buttonGpsViewSave.TabIndex = 18;
            this.buttonGpsViewSave.Text = "Save";
            this.buttonGpsViewSave.UseVisualStyleBackColor = true;
            // 
            // chkGpsViewSubdirs
            // 
            this.chkGpsViewSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGpsViewSubdirs.AutoSize = true;
            this.chkGpsViewSubdirs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceIptcGpsController, "ProcessFilesInSubdirectories", true));
            this.chkGpsViewSubdirs.Location = new System.Drawing.Point(122, 434);
            this.chkGpsViewSubdirs.Name = "chkGpsViewSubdirs";
            this.chkGpsViewSubdirs.Size = new System.Drawing.Size(163, 17);
            this.chkGpsViewSubdirs.TabIndex = 20;
            this.chkGpsViewSubdirs.Text = "process files in subdirectories";
            this.chkGpsViewSubdirs.UseVisualStyleBackColor = true;
            this.chkGpsViewSubdirs.CheckedChanged += new System.EventHandler(this.chkSubdirs_CheckedChanged);
            // 
            // buttonGpsViewSaveAll
            // 
            this.buttonGpsViewSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGpsViewSaveAll.Location = new System.Drawing.Point(291, 430);
            this.buttonGpsViewSaveAll.Name = "buttonGpsViewSaveAll";
            this.buttonGpsViewSaveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonGpsViewSaveAll.TabIndex = 19;
            this.buttonGpsViewSaveAll.Text = "Save to all";
            this.buttonGpsViewSaveAll.UseVisualStyleBackColor = true;
            // 
            // tabPageEXIF
            // 
            this.tabPageEXIF.Controls.Add(this.exifDisplay1);
            this.tabPageEXIF.Location = new System.Drawing.Point(4, 22);
            this.tabPageEXIF.Name = "tabPageEXIF";
            this.tabPageEXIF.Size = new System.Drawing.Size(421, 462);
            this.tabPageEXIF.TabIndex = 2;
            this.tabPageEXIF.Tag = 3;
            this.tabPageEXIF.Text = "EXIF";
            this.tabPageEXIF.UseVisualStyleBackColor = true;
            // 
            // exifDisplay1
            // 
            this.exifDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exifDisplay1.Location = new System.Drawing.Point(0, 0);
            this.exifDisplay1.Name = "exifDisplay1";
            this.exifDisplay1.Size = new System.Drawing.Size(421, 462);
            this.exifDisplay1.TabIndex = 0;
            // 
            // tabPageExifDates
            // 
            this.tabPageExifDates.Controls.Add(this.panel6);
            this.tabPageExifDates.Location = new System.Drawing.Point(4, 22);
            this.tabPageExifDates.Name = "tabPageExifDates";
            this.tabPageExifDates.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExifDates.Size = new System.Drawing.Size(421, 462);
            this.tabPageExifDates.TabIndex = 14;
            this.tabPageExifDates.Tag = 4;
            this.tabPageExifDates.Text = "EXIF Dates";
            this.tabPageExifDates.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.buttonExifDateViewSave);
            this.panel6.Controls.Add(this.exifDateView1);
            this.panel6.Controls.Add(this.chkExifDateViewGoToNext);
            this.panel6.Controls.Add(this.chkExifDateViewSubdirs);
            this.panel6.Controls.Add(this.buttonExifDateViewSaveAll);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(415, 456);
            this.panel6.TabIndex = 14;
            // 
            // buttonExifDateViewSave
            // 
            this.buttonExifDateViewSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExifDateViewSave.Location = new System.Drawing.Point(372, 430);
            this.buttonExifDateViewSave.Name = "buttonExifDateViewSave";
            this.buttonExifDateViewSave.Size = new System.Drawing.Size(40, 23);
            this.buttonExifDateViewSave.TabIndex = 8;
            this.buttonExifDateViewSave.Text = "Save";
            this.buttonExifDateViewSave.UseVisualStyleBackColor = true;
            // 
            // exifDateView1
            // 
            this.exifDateView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.exifDateView1.Location = new System.Drawing.Point(3, 3);
            this.exifDateView1.Name = "exifDateView1";
            this.exifDateView1.Size = new System.Drawing.Size(407, 421);
            this.exifDateView1.TabIndex = 0;
            // 
            // chkExifDateViewGoToNext
            // 
            this.chkExifDateViewGoToNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExifDateViewGoToNext.AutoSize = true;
            this.chkExifDateViewGoToNext.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceExifDateController, "GoToNextFileAfterSave", true));
            this.chkExifDateViewGoToNext.Location = new System.Drawing.Point(43, 434);
            this.chkExifDateViewGoToNext.Name = "chkExifDateViewGoToNext";
            this.chkExifDateViewGoToNext.Size = new System.Drawing.Size(73, 17);
            this.chkExifDateViewGoToNext.TabIndex = 11;
            this.chkExifDateViewGoToNext.Text = "go to next";
            this.chkExifDateViewGoToNext.UseVisualStyleBackColor = true;
            // 
            // bindingSourceExifDateController
            // 
            this.bindingSourceExifDateController.DataSource = typeof(Schroeter.PhotoTagStudio.ExifDateController);
            // 
            // chkExifDateViewSubdirs
            // 
            this.chkExifDateViewSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExifDateViewSubdirs.AutoSize = true;
            this.chkExifDateViewSubdirs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceExifDateController, "ProcessFilesInSubdirectories", true));
            this.chkExifDateViewSubdirs.Location = new System.Drawing.Point(122, 434);
            this.chkExifDateViewSubdirs.Name = "chkExifDateViewSubdirs";
            this.chkExifDateViewSubdirs.Size = new System.Drawing.Size(163, 17);
            this.chkExifDateViewSubdirs.TabIndex = 10;
            this.chkExifDateViewSubdirs.Text = "process files in subdirectories";
            this.chkExifDateViewSubdirs.UseVisualStyleBackColor = true;
            // 
            // buttonExifDateViewSaveAll
            // 
            this.buttonExifDateViewSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExifDateViewSaveAll.Location = new System.Drawing.Point(291, 430);
            this.buttonExifDateViewSaveAll.Name = "buttonExifDateViewSaveAll";
            this.buttonExifDateViewSaveAll.Size = new System.Drawing.Size(75, 23);
            this.buttonExifDateViewSaveAll.TabIndex = 9;
            this.buttonExifDateViewSaveAll.Text = "Save to all";
            this.buttonExifDateViewSaveAll.UseVisualStyleBackColor = true;
            // 
            // tabPageJPEG
            // 
            this.tabPageJPEG.Controls.Add(this.imageDisplay1);
            this.tabPageJPEG.Location = new System.Drawing.Point(4, 22);
            this.tabPageJPEG.Name = "tabPageJPEG";
            this.tabPageJPEG.Size = new System.Drawing.Size(421, 462);
            this.tabPageJPEG.TabIndex = 3;
            this.tabPageJPEG.Tag = 5;
            this.tabPageJPEG.Text = "JPEG";
            this.tabPageJPEG.UseVisualStyleBackColor = true;
            // 
            // imageDisplay1
            // 
            this.imageDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageDisplay1.Location = new System.Drawing.Point(0, 0);
            this.imageDisplay1.Name = "imageDisplay1";
            this.imageDisplay1.Size = new System.Drawing.Size(421, 462);
            this.imageDisplay1.TabIndex = 0;
            // 
            // tabPageAll
            // 
            this.tabPageAll.Controls.Add(this.completeTagList1);
            this.tabPageAll.Location = new System.Drawing.Point(4, 22);
            this.tabPageAll.Name = "tabPageAll";
            this.tabPageAll.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAll.Size = new System.Drawing.Size(421, 462);
            this.tabPageAll.TabIndex = 0;
            this.tabPageAll.Tag = 6;
            this.tabPageAll.Text = "all";
            this.tabPageAll.UseVisualStyleBackColor = true;
            // 
            // completeTagList1
            // 
            this.completeTagList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.completeTagList1.Location = new System.Drawing.Point(3, 3);
            this.completeTagList1.Name = "completeTagList1";
            this.completeTagList1.Size = new System.Drawing.Size(415, 456);
            this.completeTagList1.TabIndex = 0;
            // 
            // tabPageRename
            // 
            this.tabPageRename.Controls.Add(this.panel4);
            this.tabPageRename.Location = new System.Drawing.Point(4, 22);
            this.tabPageRename.Name = "tabPageRename";
            this.tabPageRename.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRename.Size = new System.Drawing.Size(421, 462);
            this.tabPageRename.TabIndex = 11;
            this.tabPageRename.Tag = 7;
            this.tabPageRename.Text = "Rename";
            this.tabPageRename.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.renameView1);
            this.panel4.Controls.Add(this.chkRenameSubdirs);
            this.panel4.Controls.Add(this.buttonRename);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 456);
            this.panel4.TabIndex = 0;
            // 
            // renameView1
            // 
            this.renameView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.renameView1.Location = new System.Drawing.Point(3, 3);
            this.renameView1.Name = "renameView1";
            this.renameView1.Size = new System.Drawing.Size(409, 420);
            this.renameView1.TabIndex = 10;
            // 
            // chkRenameSubdirs
            // 
            this.chkRenameSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRenameSubdirs.AutoSize = true;
            this.chkRenameSubdirs.Checked = global::Schroeter.PhotoTagStudio.Properties.Settings.Default.RenameUseSubdirectories;
            this.chkRenameSubdirs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Schroeter.PhotoTagStudio.Properties.Settings.Default, "RenameUseSubdirectories", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkRenameSubdirs.Location = new System.Drawing.Point(168, 434);
            this.chkRenameSubdirs.Name = "chkRenameSubdirs";
            this.chkRenameSubdirs.Size = new System.Drawing.Size(163, 17);
            this.chkRenameSubdirs.TabIndex = 9;
            this.chkRenameSubdirs.Text = "process files in subdirectories";
            this.chkRenameSubdirs.UseVisualStyleBackColor = true;
            this.chkRenameSubdirs.CheckedChanged += new System.EventHandler(this.chkRenameSubdirs_CheckedChanged);
            // 
            // buttonRename
            // 
            this.buttonRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRename.Location = new System.Drawing.Point(337, 429);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(75, 24);
            this.buttonRename.TabIndex = 8;
            this.buttonRename.Text = "Rename all";
            this.buttonRename.UseVisualStyleBackColor = true;
            // 
            // tabPagePlugins
            // 
            this.tabPagePlugins.Controls.Add(this.panel5);
            this.tabPagePlugins.Location = new System.Drawing.Point(4, 22);
            this.tabPagePlugins.Name = "tabPagePlugins";
            this.tabPagePlugins.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlugins.Size = new System.Drawing.Size(421, 462);
            this.tabPagePlugins.TabIndex = 12;
            this.tabPagePlugins.Tag = 8;
            this.tabPagePlugins.Text = "Plugins";
            this.tabPagePlugins.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonPluginRun);
            this.panel5.Controls.Add(this.buttonPluginRunAll);
            this.panel5.Controls.Add(this.chkPluginSubdirs);
            this.panel5.Controls.Add(this.pluginView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(415, 456);
            this.panel5.TabIndex = 0;
            // 
            // buttonPluginRun
            // 
            this.buttonPluginRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPluginRun.Location = new System.Drawing.Point(372, 430);
            this.buttonPluginRun.Name = "buttonPluginRun";
            this.buttonPluginRun.Size = new System.Drawing.Size(40, 23);
            this.buttonPluginRun.TabIndex = 7;
            this.buttonPluginRun.Text = "Run";
            this.buttonPluginRun.UseVisualStyleBackColor = true;
            // 
            // buttonPluginRunAll
            // 
            this.buttonPluginRunAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPluginRunAll.Location = new System.Drawing.Point(291, 430);
            this.buttonPluginRunAll.Name = "buttonPluginRunAll";
            this.buttonPluginRunAll.Size = new System.Drawing.Size(75, 23);
            this.buttonPluginRunAll.TabIndex = 8;
            this.buttonPluginRunAll.Text = "Run for all";
            this.buttonPluginRunAll.UseVisualStyleBackColor = true;
            // 
            // chkPluginSubdirs
            // 
            this.chkPluginSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPluginSubdirs.AutoSize = true;
            this.chkPluginSubdirs.Location = new System.Drawing.Point(122, 434);
            this.chkPluginSubdirs.Name = "chkPluginSubdirs";
            this.chkPluginSubdirs.Size = new System.Drawing.Size(163, 17);
            this.chkPluginSubdirs.TabIndex = 9;
            this.chkPluginSubdirs.Text = "process files in subdirectories";
            this.chkPluginSubdirs.UseVisualStyleBackColor = true;
            this.chkPluginSubdirs.CheckedChanged += new System.EventHandler(this.chkPluginSubdirs_CheckedChanged);
            // 
            // pluginView1
            // 
            this.pluginView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pluginView1.Location = new System.Drawing.Point(3, 3);
            this.pluginView1.Name = "pluginView1";
            this.pluginView1.Size = new System.Drawing.Size(409, 421);
            this.pluginView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "PhotoTagStudio";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SaveSettings);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageIptc.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceIptcGpsController)).EndInit();
            this.tabPageGps.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPageEXIF.ResumeLayout(false);
            this.tabPageExifDates.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExifDateController)).EndInit();
            this.tabPageJPEG.ResumeLayout(false);
            this.tabPageAll.ResumeLayout(false);
            this.tabPageRename.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPagePlugins.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpenDirectory;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuViewPreview;
        private System.Windows.Forms.ToolStripMenuItem menuViewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuViewSettings;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuExtrasMassTagging;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Raccoom.Windows.Forms.TreeViewFolderBrowser directoryTree;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkSelectAllFiles;
        private Schroeter.Windows.Forms.ThreeStateTreeView fileList;
        private System.Windows.Forms.TabPage tabPageEXIF;
        private ExifDisplay exifDisplay1;
        private System.Windows.Forms.TabPage tabPageJPEG;
        private ImageDisplay imageDisplay1;
        private System.Windows.Forms.TabPage tabPageAll;
        private CompleteTagList completeTagList1;
        private System.Windows.Forms.ToolStripButton buttonOpenDirectory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonViewFolderTree;
        private System.Windows.Forms.ToolStripButton buttonViewPreview;
        private System.Windows.Forms.ToolStripMenuItem MenuHelpLicense;
        public PictureDisplay pictureDisplay;
        private System.Windows.Forms.Label labFileCount;
        private System.Windows.Forms.ToolStripMenuItem copyPhotosToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSourceIptcGpsController;
        private System.Windows.Forms.TabPage tabPageGps;
        private System.Windows.Forms.Panel panel2;
        private ExifGpsView exifGpsView1;
        private System.Windows.Forms.CheckBox chkGpsViewGoToNext;
        private System.Windows.Forms.Button buttonGpsViewSave;
        private System.Windows.Forms.CheckBox chkGpsViewSubdirs;
        private System.Windows.Forms.Button buttonGpsViewSaveAll;
        private System.Windows.Forms.TabPage tabPageIptc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonIptcViewSave;
        private IptcView iptcView1;
        private System.Windows.Forms.CheckBox chkIptcViewGoToNext;
        private System.Windows.Forms.Button buttonIptcViewSaveAll;
        private System.Windows.Forms.CheckBox chkIptcViewSubdirs;
        private System.Windows.Forms.TabPage tabPageRename;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonRename;
        private RenameView renameView1;
        private System.Windows.Forms.CheckBox chkRenameSubdirs;
        private System.Windows.Forms.ToolStripMenuItem macrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuSeperatorMacros;
        private System.Windows.Forms.TabPage tabPagePlugins;
        private System.Windows.Forms.Panel panel5;
        private PluginView pluginView1;
        private System.Windows.Forms.Button buttonPluginRun;
        private System.Windows.Forms.Button buttonPluginRunAll;
        private System.Windows.Forms.CheckBox chkPluginSubdirs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.BindingSource bindingSourceExifDateController;
        private System.Windows.Forms.TabPage tabPageExifDates;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonExifDateViewSave;
        private ExifDateView exifDateView1;
        private System.Windows.Forms.CheckBox chkExifDateViewGoToNext;
        private System.Windows.Forms.CheckBox chkExifDateViewSubdirs;
        private System.Windows.Forms.Button buttonExifDateViewSaveAll;
        public Schroeter.Windows.Forms.TabControlWithHiddenTab tabControl;

    }
}

