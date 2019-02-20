namespace Schroeter.PhotoTagStudio.Features.KmzMaker
{
    partial class PictureGpsOffsetDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PictureGpsOffsetDialog));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timeExif = new System.Windows.Forms.DateTimePicker();
            this.timeOffset = new System.Windows.Forms.DateTimePicker();
            this.timeGps = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.radMinus = new System.Windows.Forms.RadioButton();
            this.radPlus = new System.Windows.Forms.RadioButton();
            this.labGpsLogInfo = new System.Windows.Forms.Label();
            this.pictureDisplay1 = new Schroeter.PhotoTagStudio.Gui.PictureDisplay();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 367);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "UTC Time of GPS:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Offset:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Camera time (EXIF):";
            // 
            // timeExif
            // 
            this.timeExif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeExif.Enabled = false;
            this.timeExif.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeExif.Location = new System.Drawing.Point(123, 311);
            this.timeExif.Name = "timeExif";
            this.timeExif.ShowUpDown = true;
            this.timeExif.Size = new System.Drawing.Size(94, 20);
            this.timeExif.TabIndex = 5;
            // 
            // timeOffset
            // 
            this.timeOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeOffset.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeOffset.Location = new System.Drawing.Point(123, 337);
            this.timeOffset.Name = "timeOffset";
            this.timeOffset.ShowUpDown = true;
            this.timeOffset.Size = new System.Drawing.Size(94, 20);
            this.timeOffset.TabIndex = 6;
            this.timeOffset.ValueChanged += new System.EventHandler(this.timeOffset_ValueChanged);
            // 
            // timeGps
            // 
            this.timeGps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeGps.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeGps.Location = new System.Drawing.Point(123, 363);
            this.timeGps.Name = "timeGps";
            this.timeGps.ShowUpDown = true;
            this.timeGps.Size = new System.Drawing.Size(94, 20);
            this.timeGps.TabIndex = 7;
            this.timeGps.ValueChanged += new System.EventHandler(this.timeGps_ValueChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(289, 362);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(370, 363);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radMinus
            // 
            this.radMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radMinus.AutoSize = true;
            this.radMinus.Location = new System.Drawing.Point(89, 339);
            this.radMinus.Name = "radMinus";
            this.radMinus.Size = new System.Drawing.Size(28, 17);
            this.radMinus.TabIndex = 10;
            this.radMinus.Text = "-";
            this.radMinus.UseVisualStyleBackColor = true;
            // 
            // radPlus
            // 
            this.radPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radPlus.AutoSize = true;
            this.radPlus.Checked = true;
            this.radPlus.Location = new System.Drawing.Point(52, 339);
            this.radPlus.Name = "radPlus";
            this.radPlus.Size = new System.Drawing.Size(31, 17);
            this.radPlus.TabIndex = 11;
            this.radPlus.TabStop = true;
            this.radPlus.Text = "+";
            this.radPlus.UseVisualStyleBackColor = true;
            this.radPlus.CheckedChanged += new System.EventHandler(this.timeOffset_ValueChanged);
            // 
            // labGpsLogInfo
            // 
            this.labGpsLogInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labGpsLogInfo.AutoSize = true;
            this.labGpsLogInfo.Location = new System.Drawing.Point(8, 286);
            this.labGpsLogInfo.Name = "labGpsLogInfo";
            this.labGpsLogInfo.Size = new System.Drawing.Size(195, 13);
            this.labGpsLogInfo.TabIndex = 12;
            this.labGpsLogInfo.Text = "The GPS data are between {0} and {1}.";
            // 
            // pictureDisplay1
            // 
            this.pictureDisplay1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureDisplay1.Location = new System.Drawing.Point(12, 12);
            this.pictureDisplay1.Name = "pictureDisplay1";
            this.pictureDisplay1.Size = new System.Drawing.Size(433, 271);
            this.pictureDisplay1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(433, 271);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PictureGpsOffsetDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 393);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labGpsLogInfo);
            this.Controls.Add(this.radPlus);
            this.Controls.Add(this.radMinus);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.timeGps);
            this.Controls.Add(this.timeOffset);
            this.Controls.Add(this.timeExif);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureDisplay1);
            this.Name = "PictureGpsOffsetDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Please select the offset of GPS end EXIF time";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Schroeter.PhotoTagStudio.Gui.PictureDisplay pictureDisplay1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker timeExif;
        private System.Windows.Forms.DateTimePicker timeOffset;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DateTimePicker timeGps;
        private System.Windows.Forms.RadioButton radMinus;
        private System.Windows.Forms.RadioButton radPlus;
        private System.Windows.Forms.Label labGpsLogInfo;
        private System.Windows.Forms.TextBox textBox1;

    }
}