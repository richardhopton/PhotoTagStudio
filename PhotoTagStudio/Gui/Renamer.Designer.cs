namespace Schroeter.PhotoTagStudio.Gui
{
    partial class Renamer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.ComboBox();
            this.labFilenameExample = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDirectory = new System.Windows.Forms.CheckBox();
            this.txtDirectoryname = new System.Windows.Forms.ComboBox();
            this.labDirectoryExample = new System.Windows.Forms.Label();
            this.chkFilename = new System.Windows.Forms.CheckBox();
            this.chkSubdirs = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRename, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtFilename, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labFilenameExample, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkDirectory, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtDirectoryname, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labDirectoryExample, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkFilename, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkSubdirs, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(347, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Filename:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRename
            // 
            this.btnRename.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRename.Location = new System.Drawing.Point(269, 379);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 24);
            this.btnRename.TabIndex = 7;
            this.btnRename.Text = "Rename all";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // txtFilename
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtFilename, 2);
            this.txtFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilename.FormattingEnabled = true;
            this.txtFilename.Location = new System.Drawing.Point(108, 3);
            this.txtFilename.MaxDropDownItems = 16;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(236, 21);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // labFilenameExample
            // 
            this.labFilenameExample.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labFilenameExample, 3);
            this.labFilenameExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFilenameExample.Location = new System.Drawing.Point(87, 27);
            this.labFilenameExample.Name = "labFilenameExample";
            this.labFilenameExample.Size = new System.Drawing.Size(257, 20);
            this.labFilenameExample.TabIndex = 3;
            this.labFilenameExample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Directoryname:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDirectory
            // 
            this.chkDirectory.AutoSize = true;
            this.chkDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkDirectory.Location = new System.Drawing.Point(87, 50);
            this.chkDirectory.Name = "chkDirectory";
            this.chkDirectory.Size = new System.Drawing.Size(15, 21);
            this.chkDirectory.TabIndex = 9;
            this.chkDirectory.UseVisualStyleBackColor = true;
            // 
            // txtDirectoryname
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDirectoryname, 2);
            this.txtDirectoryname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDirectoryname.FormattingEnabled = true;
            this.txtDirectoryname.Location = new System.Drawing.Point(108, 50);
            this.txtDirectoryname.MaxDropDownItems = 16;
            this.txtDirectoryname.Name = "txtDirectoryname";
            this.txtDirectoryname.Size = new System.Drawing.Size(236, 21);
            this.txtDirectoryname.TabIndex = 4;
            this.txtDirectoryname.TextChanged += new System.EventHandler(this.txtDirectoryname_TextChanged);
            // 
            // labDirectoryExample
            // 
            this.labDirectoryExample.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labDirectoryExample, 3);
            this.labDirectoryExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labDirectoryExample.Location = new System.Drawing.Point(87, 74);
            this.labDirectoryExample.Name = "labDirectoryExample";
            this.labDirectoryExample.Size = new System.Drawing.Size(257, 20);
            this.labDirectoryExample.TabIndex = 5;
            this.labDirectoryExample.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkFilename
            // 
            this.chkFilename.AutoSize = true;
            this.chkFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkFilename.Location = new System.Drawing.Point(87, 3);
            this.chkFilename.Name = "chkFilename";
            this.chkFilename.Size = new System.Drawing.Size(15, 21);
            this.chkFilename.TabIndex = 8;
            this.chkFilename.UseVisualStyleBackColor = true;
            // 
            // chkSubdirs
            // 
            this.chkSubdirs.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkSubdirs, 2);
            this.chkSubdirs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSubdirs.Location = new System.Drawing.Point(87, 379);
            this.chkSubdirs.Name = "chkSubdirs";
            this.chkSubdirs.Size = new System.Drawing.Size(176, 24);
            this.chkSubdirs.TabIndex = 6;
            this.chkSubdirs.Text = "process files in subdirectories";
            this.chkSubdirs.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBox1, 3);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(87, 97);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(257, 276);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // Renamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Renamer";
            this.Size = new System.Drawing.Size(347, 406);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtFilename;
        private System.Windows.Forms.Label labFilenameExample;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.CheckBox chkSubdirs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDirectory;
        private System.Windows.Forms.ComboBox txtDirectoryname;
        private System.Windows.Forms.Label labDirectoryExample;
        private System.Windows.Forms.CheckBox chkFilename;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}
