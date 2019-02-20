namespace Schroeter.PhotoTagStudio.Features.MassTagging
{
    partial class MassTaggingForm
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
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnOpenDirectory = new System.Windows.Forms.Button();
            this.chkSubdirs = new System.Windows.Forms.CheckBox();
            this.cmbField = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCaching = new System.Windows.Forms.CheckBox();
            this.btnReadFiles = new System.Windows.Forms.Button();
            this.btnWriteFiles = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNewText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTags2Settings = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDirectory
            // 
            this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectory.Location = new System.Drawing.Point(70, 12);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(187, 20);
            this.txtDirectory.TabIndex = 0;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // btnOpenDirectory
            // 
            this.btnOpenDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenDirectory.Location = new System.Drawing.Point(360, 10);
            this.btnOpenDirectory.Name = "btnOpenDirectory";
            this.btnOpenDirectory.Size = new System.Drawing.Size(84, 23);
            this.btnOpenDirectory.TabIndex = 1;
            this.btnOpenDirectory.Text = "open directory";
            this.btnOpenDirectory.UseVisualStyleBackColor = true;
            this.btnOpenDirectory.Click += new System.EventHandler(this.btnOpenDirectory_Click);
            // 
            // chkSubdirs
            // 
            this.chkSubdirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSubdirs.AutoSize = true;
            this.chkSubdirs.Checked = true;
            this.chkSubdirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSubdirs.Location = new System.Drawing.Point(263, 14);
            this.chkSubdirs.Name = "chkSubdirs";
            this.chkSubdirs.Size = new System.Drawing.Size(91, 17);
            this.chkSubdirs.TabIndex = 2;
            this.chkSubdirs.Text = "subdirectories";
            this.chkSubdirs.UseVisualStyleBackColor = true;
            this.chkSubdirs.CheckedChanged += new System.EventHandler(this.chkSubdirs_CheckedChanged);
            // 
            // cmbField
            // 
            this.cmbField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbField.FormattingEnabled = true;
            this.cmbField.Location = new System.Drawing.Point(70, 38);
            this.cmbField.MaxDropDownItems = 20;
            this.cmbField.Name = "cmbField";
            this.cmbField.Size = new System.Drawing.Size(187, 21);
            this.cmbField.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Field:";
            // 
            // chkCaching
            // 
            this.chkCaching.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCaching.AutoSize = true;
            this.chkCaching.Checked = true;
            this.chkCaching.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCaching.Location = new System.Drawing.Point(263, 40);
            this.chkCaching.Name = "chkCaching";
            this.chkCaching.Size = new System.Drawing.Size(84, 17);
            this.chkCaching.TabIndex = 6;
            this.chkCaching.Text = "use caching";
            this.chkCaching.UseVisualStyleBackColor = true;
            this.chkCaching.CheckedChanged += new System.EventHandler(this.chkCaching_CheckedChanged);
            // 
            // btnReadFiles
            // 
            this.btnReadFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadFiles.Location = new System.Drawing.Point(360, 36);
            this.btnReadFiles.Name = "btnReadFiles";
            this.btnReadFiles.Size = new System.Drawing.Size(84, 23);
            this.btnReadFiles.TabIndex = 7;
            this.btnReadFiles.Text = "read files";
            this.btnReadFiles.UseVisualStyleBackColor = true;
            this.btnReadFiles.Click += new System.EventHandler(this.btnReadFiles_Click);
            // 
            // btnWriteFiles
            // 
            this.btnWriteFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWriteFiles.Location = new System.Drawing.Point(360, 439);
            this.btnWriteFiles.Name = "btnWriteFiles";
            this.btnWriteFiles.Size = new System.Drawing.Size(84, 23);
            this.btnWriteFiles.TabIndex = 8;
            this.btnWriteFiles.Text = "write files";
            this.btnWriteFiles.UseVisualStyleBackColor = true;
            this.btnWriteFiles.Click += new System.EventHandler(this.btnWriteFiles_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(456, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSelected,
            this.ColumnText,
            this.ColumnNewText,
            this.ColumnCount});
            this.dataGridView1.Location = new System.Drawing.Point(15, 65);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 42;
            this.dataGridView1.Size = new System.Drawing.Size(429, 368);
            this.dataGridView1.TabIndex = 10;
            // 
            // ColumnSelected
            // 
            this.ColumnSelected.DataPropertyName = "Selected";
            this.ColumnSelected.HeaderText = "Selected";
            this.ColumnSelected.Name = "ColumnSelected";
            // 
            // ColumnText
            // 
            this.ColumnText.DataPropertyName = "Text";
            this.ColumnText.HeaderText = "Text";
            this.ColumnText.Name = "ColumnText";
            this.ColumnText.ReadOnly = true;
            // 
            // ColumnNewText
            // 
            this.ColumnNewText.DataPropertyName = "NewText";
            this.ColumnNewText.HeaderText = "new Text";
            this.ColumnNewText.Name = "ColumnNewText";
            // 
            // ColumnCount
            // 
            this.ColumnCount.DataPropertyName = "FileCount";
            this.ColumnCount.HeaderText = "Count";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            // 
            // btnTags2Settings
            // 
            this.btnTags2Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTags2Settings.Location = new System.Drawing.Point(193, 439);
            this.btnTags2Settings.Name = "btnTags2Settings";
            this.btnTags2Settings.Size = new System.Drawing.Size(161, 23);
            this.btnTags2Settings.TabIndex = 11;
            this.btnTags2Settings.Text = "selected tags to my settings";
            this.btnTags2Settings.UseVisualStyleBackColor = true;
            this.btnTags2Settings.Click += new System.EventHandler(this.btnTags2Settings_Click);
            // 
            // MassTaggingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 487);
            this.Controls.Add(this.btnTags2Settings);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnWriteFiles);
            this.Controls.Add(this.btnReadFiles);
            this.Controls.Add(this.chkCaching);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbField);
            this.Controls.Add(this.chkSubdirs);
            this.Controls.Add(this.btnOpenDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Name = "MassTaggingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mass tagging";
            this.Load += new System.EventHandler(this.MassTaggingForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MassTaggingForm_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnOpenDirectory;
        private System.Windows.Forms.CheckBox chkSubdirs;
        private System.Windows.Forms.ComboBox cmbField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCaching;
        private System.Windows.Forms.Button btnReadFiles;
        private System.Windows.Forms.Button btnWriteFiles;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNewText;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.Button btnTags2Settings;
    }
}