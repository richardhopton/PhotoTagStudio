namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    partial class KmzAndGps
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numHeading = new System.Windows.Forms.NumericUpDown();
            this.numTilt = new System.Windows.Forms.NumericUpDown();
            this.numRange = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numPicSize = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numHeading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPicSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Heading:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tilt:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Range:";
            // 
            // numHeading
            // 
            this.numHeading.Location = new System.Drawing.Point(188, 55);
            this.numHeading.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numHeading.Name = "numHeading";
            this.numHeading.Size = new System.Drawing.Size(120, 20);
            this.numHeading.TabIndex = 20;
            this.numHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numHeading.ValueChanged += new System.EventHandler(this.numHeading_ValueChanged);
            // 
            // numTilt
            // 
            this.numTilt.Location = new System.Drawing.Point(188, 29);
            this.numTilt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTilt.Name = "numTilt";
            this.numTilt.Size = new System.Drawing.Size(120, 20);
            this.numTilt.TabIndex = 18;
            this.numTilt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTilt.ValueChanged += new System.EventHandler(this.numTilt_ValueChanged);
            // 
            // numRange
            // 
            this.numRange.Location = new System.Drawing.Point(188, 3);
            this.numRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRange.Name = "numRange";
            this.numRange.Size = new System.Drawing.Size(120, 20);
            this.numRange.TabIndex = 16;
            this.numRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRange.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numRange.ValueChanged += new System.EventHandler(this.numRange_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Maximum picture size for kmz export:";
            // 
            // numPicSize
            // 
            this.numPicSize.Location = new System.Drawing.Point(188, 81);
            this.numPicSize.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numPicSize.Name = "numPicSize";
            this.numPicSize.Size = new System.Drawing.Size(120, 20);
            this.numPicSize.TabIndex = 22;
            this.numPicSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPicSize.ValueChanged += new System.EventHandler(this.numPicSize_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Line width:";
            // 
            // numLineWidth
            // 
            this.numLineWidth.Location = new System.Drawing.Point(188, 107);
            this.numLineWidth.Name = "numLineWidth";
            this.numLineWidth.Size = new System.Drawing.Size(120, 20);
            this.numLineWidth.TabIndex = 24;
            this.numLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numLineWidth.ValueChanged += new System.EventHandler(this.numLineWidth_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Line color:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(188, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 25);
            this.panel1.TabIndex = 26;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // KmzAndGps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numLineWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPicSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numHeading);
            this.Controls.Add(this.numTilt);
            this.Controls.Add(this.numRange);
            this.Name = "KmzAndGps";
            this.Size = new System.Drawing.Size(351, 201);
            this.Load += new System.EventHandler(this.KmzAndGps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numHeading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPicSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numHeading;
        private System.Windows.Forms.NumericUpDown numTilt;
        private System.Windows.Forms.NumericUpDown numRange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPicSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLineWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}

