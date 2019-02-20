namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    partial class SettingsForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Caption");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Object names");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Writer");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Authors (byline)");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Copyrights");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Contacts");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Location");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Keywords");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Headlines");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("ITPC defaults", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Filename formats");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Directoryname formats");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Renaming defaults", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Defaults for kmz-files");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Visible Tabs");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Settings", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13,
            treeNode14,
            treeNode15});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "NodeCaption";
            treeNode1.Tag = "TagList.Captions";
            treeNode1.Text = "Caption";
            treeNode2.Name = "NodeObjectNames";
            treeNode2.Tag = "TagList.Objectnames";
            treeNode2.Text = "Object names";
            treeNode3.Name = "Node5";
            treeNode3.Tag = "TagList.Writers";
            treeNode3.Text = "Writer";
            treeNode4.Name = "Node6";
            treeNode4.Tag = "TagList.Authors";
            treeNode4.Text = "Authors (byline)";
            treeNode5.Name = "Node7";
            treeNode5.Tag = "TagList.Copyrights";
            treeNode5.Text = "Copyrights";
            treeNode6.Name = "Node8";
            treeNode6.Tag = "TagList.Contacts";
            treeNode6.Text = "Contacts";
            treeNode7.Name = "Node9";
            treeNode7.Tag = "LocationList";
            treeNode7.Text = "Location";
            treeNode8.Name = "NodeKeywords";
            treeNode8.Tag = "TagList.KeywordsG";
            treeNode8.Text = "Keywords";
            treeNode9.Name = "Node12";
            treeNode9.Tag = "TagList.Headlines";
            treeNode9.Text = "Headlines";
            treeNode10.Name = "Node1";
            treeNode10.Tag = "ITPC";
            treeNode10.Text = "ITPC defaults";
            treeNode11.Name = "Node14";
            treeNode11.Tag = "TagList.FilenameFormats";
            treeNode11.Text = "Filename formats";
            treeNode12.Name = "Node15";
            treeNode12.Tag = "TagList.DirectorynameFormats";
            treeNode12.Text = "Directoryname formats";
            treeNode13.Name = "Node2";
            treeNode13.Text = "Renaming defaults";
            treeNode14.Name = "Node0";
            treeNode14.Tag = "kmz";
            treeNode14.Text = "Defaults for kmz-files";
            treeNode15.Name = "Node0";
            treeNode15.Tag = "tabs";
            treeNode15.Text = "Visible Tabs";
            treeNode16.Name = "Node0";
            treeNode16.Tag = "root";
            treeNode16.Text = "Settings";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16});
            this.treeView1.Size = new System.Drawing.Size(203, 420);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.Location = new System.Drawing.Point(221, 12);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(455, 391);
            this.MainPanel.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(601, 409);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 444);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.treeView1);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btnClose;
    }
}