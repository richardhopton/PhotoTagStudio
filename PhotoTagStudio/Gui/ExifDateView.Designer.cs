namespace Schroeter.PhotoTagStudio.Gui
{
    partial class ExifDateView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExifDateView));
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listSource = new Schroeter.Windows.Forms.ListViewHoldSelection();
            this.listTarget = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.offsetDays = new System.Windows.Forms.NumericUpDown();
            this.radPlus = new System.Windows.Forms.RadioButton();
            this.radMinus = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labTargetPreview = new System.Windows.Forms.Label();
            this.customDateTime = new System.Windows.Forms.DateTimePicker();
            this.labSourcePreview = new System.Windows.Forms.Label();
            this.timeOffset = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetDays)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Schroeter.PhotoTagStudio.Data.ExifDateModel);
            this.bindingSource.CurrentItemChanged += new System.EventHandler(this.bindingSource_CurrentItemChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listSource, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listTarget, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labTargetPreview, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.customDateTime, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labSourcePreview, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.timeOffset, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listSource
            // 
            this.listSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.listSource.Location = new System.Drawing.Point(47, 62);
            this.listSource.MultiSelect = false;
            this.listSource.Name = "listSource";
            this.tableLayoutPanel1.SetRowSpan(this.listSource, 2);
            this.listSource.Size = new System.Drawing.Size(154, 94);
            this.listSource.TabIndex = 2;
            this.listSource.UseCompatibleStateImageBehavior = false;
            this.listSource.View = System.Windows.Forms.View.List;
            this.listSource.SelectedIndexChanged += new System.EventHandler(this.listSource_SelectedIndexChanged);
            // 
            // listTarget
            // 
            this.listTarget.CheckBoxes = true;
            this.listTarget.Dock = System.Windows.Forms.DockStyle.Left;
            this.listTarget.Location = new System.Drawing.Point(47, 198);
            this.listTarget.Name = "listTarget";
            this.listTarget.Size = new System.Drawing.Size(154, 94);
            this.listTarget.TabIndex = 9;
            this.listTarget.UseCompatibleStateImageBehavior = false;
            this.listTarget.View = System.Windows.Forms.View.List;
            this.listTarget.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listTarget_ItemChecked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.offsetDays);
            this.panel1.Controls.Add(this.radPlus);
            this.panel1.Controls.Add(this.radMinus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(47, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(154, 30);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "d";
            // 
            // offsetDays
            // 
            this.offsetDays.Location = new System.Drawing.Point(74, 7);
            this.offsetDays.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.offsetDays.Name = "offsetDays";
            this.offsetDays.Size = new System.Drawing.Size(57, 20);
            this.offsetDays.TabIndex = 2;
            this.offsetDays.ValueChanged += new System.EventHandler(this.timeOffset_ValueChanged);
            // 
            // radPlus
            // 
            this.radPlus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radPlus.AutoSize = true;
            this.radPlus.Checked = true;
            this.radPlus.Location = new System.Drawing.Point(3, 9);
            this.radPlus.Name = "radPlus";
            this.radPlus.Size = new System.Drawing.Size(31, 17);
            this.radPlus.TabIndex = 0;
            this.radPlus.TabStop = true;
            this.radPlus.Text = "+";
            this.radPlus.UseVisualStyleBackColor = true;
            // 
            // radMinus
            // 
            this.radMinus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radMinus.AutoSize = true;
            this.radMinus.Location = new System.Drawing.Point(40, 9);
            this.radMinus.Name = "radMinus";
            this.radMinus.Size = new System.Drawing.Size(28, 17);
            this.radMinus.TabIndex = 1;
            this.radMinus.Text = "-";
            this.radMinus.UseVisualStyleBackColor = true;
            this.radMinus.CheckedChanged += new System.EventHandler(this.timeOffset_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 65);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 172);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 13, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Offset:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 95);
            this.label3.TabIndex = 8;
            this.label3.Text = "To:";
            // 
            // labTargetPreview
            // 
            this.labTargetPreview.AutoSize = true;
            this.labTargetPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labTargetPreview.Location = new System.Drawing.Point(207, 195);
            this.labTargetPreview.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.labTargetPreview.Name = "labTargetPreview";
            this.labTargetPreview.Size = new System.Drawing.Size(144, 95);
            this.labTargetPreview.TabIndex = 10;
            this.labTargetPreview.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // customDateTime
            // 
            this.customDateTime.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "CustomSource", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.customDateTime.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.customDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.customDateTime.Location = new System.Drawing.Point(207, 136);
            this.customDateTime.Name = "customDateTime";
            this.customDateTime.Size = new System.Drawing.Size(144, 20);
            this.customDateTime.TabIndex = 4;
            this.customDateTime.Value = new System.DateTime(2008, 3, 8, 14, 1, 38, 836);
            // 
            // labSourcePreview
            // 
            this.labSourcePreview.AutoSize = true;
            this.labSourcePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSourcePreview.Location = new System.Drawing.Point(207, 64);
            this.labSourcePreview.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.labSourcePreview.Name = "labSourcePreview";
            this.labSourcePreview.Size = new System.Drawing.Size(144, 65);
            this.labSourcePreview.TabIndex = 3;
            // 
            // timeOffset
            // 
            this.timeOffset.Dock = System.Windows.Forms.DockStyle.Left;
            this.timeOffset.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeOffset.Location = new System.Drawing.Point(207, 168);
            this.timeOffset.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.timeOffset.Name = "timeOffset";
            this.timeOffset.ShowUpDown = true;
            this.timeOffset.Size = new System.Drawing.Size(81, 20);
            this.timeOffset.TabIndex = 7;
            this.timeOffset.ValueChanged += new System.EventHandler(this.timeOffset_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label5, 4);
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(400, 39);
            this.label5.TabIndex = 0;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // ExifDateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExifDateView";
            this.Size = new System.Drawing.Size(406, 406);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetDays)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker customDateTime;
        private Schroeter.Windows.Forms.ListViewHoldSelection listSource;
        private System.Windows.Forms.ListView listTarget;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radPlus;
        private System.Windows.Forms.RadioButton radMinus;
        private System.Windows.Forms.DateTimePicker timeOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label labTargetPreview;
        public System.Windows.Forms.Label labSourcePreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown offsetDays;
        private System.Windows.Forms.Label label5;
    }
}
