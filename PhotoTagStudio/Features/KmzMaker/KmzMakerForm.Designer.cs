namespace Schroeter.PhotoTagStudio.Features.KmzMaker
{
    partial class KmzMakerForm
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
            this.radOneFile = new System.Windows.Forms.RadioButton();
            this.radSelected = new System.Windows.Forms.RadioButton();
            this.radSubdirs = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKmzFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkRoute = new System.Windows.Forms.CheckBox();
            this.txtRouteFile = new System.Windows.Forms.TextBox();
            this.btnSelectRouteFile = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.radNone = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radOneFile
            // 
            this.radOneFile.AutoSize = true;
            this.radOneFile.Location = new System.Drawing.Point(128, 12);
            this.radOneFile.Name = "radOneFile";
            this.radOneFile.Size = new System.Drawing.Size(59, 17);
            this.radOneFile.TabIndex = 1;
            this.radOneFile.TabStop = true;
            this.radOneFile.Text = "one file";
            this.radOneFile.UseVisualStyleBackColor = true;
            // 
            // radSelected
            // 
            this.radSelected.AutoSize = true;
            this.radSelected.Location = new System.Drawing.Point(193, 12);
            this.radSelected.Name = "radSelected";
            this.radSelected.Size = new System.Drawing.Size(140, 17);
            this.radSelected.TabIndex = 2;
            this.radSelected.TabStop = true;
            this.radSelected.Text = "selected files in directory";
            this.radSelected.UseVisualStyleBackColor = true;
            // 
            // radSubdirs
            // 
            this.radSubdirs.AutoSize = true;
            this.radSubdirs.Location = new System.Drawing.Point(339, 12);
            this.radSubdirs.Name = "radSubdirs";
            this.radSubdirs.Size = new System.Drawing.Size(154, 17);
            this.radSubdirs.TabIndex = 3;
            this.radSubdirs.TabStop = true;
            this.radSubdirs.Text = "directory and subdirectories";
            this.radSubdirs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filename:";
            // 
            // txtKmzFile
            // 
            this.txtKmzFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKmzFile.Location = new System.Drawing.Point(72, 62);
            this.txtKmzFile.Name = "txtKmzFile";
            this.txtKmzFile.Size = new System.Drawing.Size(409, 20);
            this.txtKmzFile.TabIndex = 7;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile.Location = new System.Drawing.Point(487, 60);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(27, 23);
            this.btnSelectFile.TabIndex = 8;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(439, 125);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(356, 125);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 16;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // chkOpen
            // 
            this.chkOpen.AutoSize = true;
            this.chkOpen.Location = new System.Drawing.Point(70, 119);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(153, 17);
            this.chkOpen.TabIndex = 15;
            this.chkOpen.Text = "open file with Google Earth";
            this.chkOpen.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(72, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(442, 20);
            this.txtName.TabIndex = 5;
            // 
            // chkRoute
            // 
            this.chkRoute.AutoSize = true;
            this.chkRoute.Location = new System.Drawing.Point(70, 90);
            this.chkRoute.Name = "chkRoute";
            this.chkRoute.Size = new System.Drawing.Size(112, 17);
            this.chkRoute.TabIndex = 18;
            this.chkRoute.Text = "include GPS route";
            this.chkRoute.UseVisualStyleBackColor = true;
            this.chkRoute.CheckedChanged += new System.EventHandler(this.chkRoute_CheckedChanged);
            // 
            // txtRouteFile
            // 
            this.txtRouteFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRouteFile.Enabled = false;
            this.txtRouteFile.Location = new System.Drawing.Point(188, 88);
            this.txtRouteFile.Name = "txtRouteFile";
            this.txtRouteFile.Size = new System.Drawing.Size(293, 20);
            this.txtRouteFile.TabIndex = 19;
            // 
            // btnSelectRouteFile
            // 
            this.btnSelectRouteFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectRouteFile.Enabled = false;
            this.btnSelectRouteFile.Location = new System.Drawing.Point(487, 86);
            this.btnSelectRouteFile.Name = "btnSelectRouteFile";
            this.btnSelectRouteFile.Size = new System.Drawing.Size(27, 23);
            this.btnSelectRouteFile.TabIndex = 8;
            this.btnSelectRouteFile.Text = "...";
            this.btnSelectRouteFile.UseVisualStyleBackColor = true;
            this.btnSelectRouteFile.Click += new System.EventHandler(this.btnSelectRouteFile_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(487, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // radNone
            // 
            this.radNone.AutoSize = true;
            this.radNone.Location = new System.Drawing.Point(73, 12);
            this.radNone.Name = "radNone";
            this.radNone.Size = new System.Drawing.Size(49, 17);
            this.radNone.TabIndex = 20;
            this.radNone.TabStop = true;
            this.radNone.Text = "none";
            this.radNone.UseVisualStyleBackColor = true;
            // 
            // KmzMakerForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(526, 158);
            this.Controls.Add(this.radNone);
            this.Controls.Add(this.txtRouteFile);
            this.Controls.Add(this.chkRoute);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkOpen);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.btnSelectRouteFile);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtKmzFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radSubdirs);
            this.Controls.Add(this.radSelected);
            this.Controls.Add(this.radOneFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KmzMakerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate kmz file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radOneFile;
        private System.Windows.Forms.RadioButton radSelected;
        private System.Windows.Forms.RadioButton radSubdirs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKmzFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox chkOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkRoute;
        private System.Windows.Forms.TextBox txtRouteFile;
        private System.Windows.Forms.Button btnSelectRouteFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radNone;
    }
}