namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    partial class SettingsMain
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.chkBackgroundThumbnails = new System.Windows.Forms.CheckBox();
            this.chkRotate = new System.Windows.Forms.CheckBox();
            this.chkCollapseKeywordGroups = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(218, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Open configuration directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkBackgroundThumbnails
            // 
            this.chkBackgroundThumbnails.AutoSize = true;
            this.chkBackgroundThumbnails.Checked = true;
            this.chkBackgroundThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBackgroundThumbnails.Location = new System.Drawing.Point(3, 27);
            this.chkBackgroundThumbnails.Name = "chkBackgroundThumbnails";
            this.chkBackgroundThumbnails.Size = new System.Drawing.Size(187, 17);
            this.chkBackgroundThumbnails.TabIndex = 7;
            this.chkBackgroundThumbnails.Text = "Load all thumbnails in background";
            this.chkBackgroundThumbnails.UseVisualStyleBackColor = true;
            this.chkBackgroundThumbnails.CheckedChanged += new System.EventHandler(this.chkBackgroundThumbnails_CheckedChanged);
            // 
            // chkRotate
            // 
            this.chkRotate.AutoSize = true;
            this.chkRotate.Checked = true;
            this.chkRotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRotate.Location = new System.Drawing.Point(3, 3);
            this.chkRotate.Name = "chkRotate";
            this.chkRotate.Size = new System.Drawing.Size(257, 17);
            this.chkRotate.TabIndex = 6;
            this.chkRotate.Text = "Rotate preview as specified in exif orientation tag";
            this.chkRotate.UseVisualStyleBackColor = true;
            this.chkRotate.CheckedChanged += new System.EventHandler(this.chkRotate_CheckedChanged);
            // 
            // chkCollapseKeywordGroups
            // 
            this.chkCollapseKeywordGroups.AutoSize = true;
            this.chkCollapseKeywordGroups.Location = new System.Drawing.Point(3, 50);
            this.chkCollapseKeywordGroups.Name = "chkCollapseKeywordGroups";
            this.chkCollapseKeywordGroups.Size = new System.Drawing.Size(218, 17);
            this.chkCollapseKeywordGroups.TabIndex = 8;
            this.chkCollapseKeywordGroups.Text = "Collapse IPTC keyword groups at startup";
            this.chkCollapseKeywordGroups.UseVisualStyleBackColor = true;
            this.chkCollapseKeywordGroups.CheckedChanged += new System.EventHandler(this.chkCollapseKeywordGroups_CheckedChanged);
            // 
            // SettingsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkCollapseKeywordGroups);
            this.Controls.Add(this.chkBackgroundThumbnails);
            this.Controls.Add(this.chkRotate);
            this.Controls.Add(this.button1);
            this.Name = "SettingsMain";
            this.Size = new System.Drawing.Size(410, 355);
            this.Load += new System.EventHandler(this.SettingsMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkRotate;
        private System.Windows.Forms.CheckBox chkBackgroundThumbnails;
        private System.Windows.Forms.CheckBox chkCollapseKeywordGroups;
    }
}
