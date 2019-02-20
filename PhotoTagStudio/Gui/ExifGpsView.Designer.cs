
namespace Schroeter.PhotoTagStudio.Gui
{
    partial class ExifGpsView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.updateLatitude = new System.Windows.Forms.CheckBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.updateLongitude = new System.Windows.Forms.CheckBox();
            this.updateAltitude = new System.Windows.Forms.CheckBox();
            this.updateSpeed = new System.Windows.Forms.CheckBox();
            this.updateTrack = new System.Windows.Forms.CheckBox();
            this.updateImgDirection = new System.Windows.Forms.CheckBox();
            this.updateDateTime = new System.Windows.Forms.CheckBox();
            this.txtLatitudeRef = new System.Windows.Forms.ComboBox();
            this.txtLongitudeRef = new System.Windows.Forms.ComboBox();
            this.txtAltitudeRef = new System.Windows.Forms.ComboBox();
            this.txtSpeedRef = new System.Windows.Forms.ComboBox();
            this.txtTrackRef = new System.Windows.Forms.ComboBox();
            this.txtImgDirectionRef = new System.Windows.Forms.ComboBox();
            this.numAltitude = new Schroeter.Windows.Forms.NumericUpDownReplacement();
            this.numSpeed = new Schroeter.Windows.Forms.NumericUpDownReplacement();
            this.numTrack = new Schroeter.Windows.Forms.NumericUpDownReplacement();
            this.numImgDirection = new Schroeter.Windows.Forms.NumericUpDownReplacement();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labSpeedUnit = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLatitude = new System.Windows.Forms.MaskedTextBox();
            this.txtLongitude = new System.Windows.Forms.MaskedTextBox();
            this.buttonKmzMaker = new System.Windows.Forms.Button();
            this.buttonGetGpsData = new System.Windows.Forms.Button();
            this.nullableDateTimePicker1 = new Schroeter.Windows.Forms.NullableDateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImgDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.updateLatitude, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateLongitude, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.updateAltitude, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.updateSpeed, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.updateTrack, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.updateImgDirection, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.updateDateTime, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtLatitudeRef, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLongitudeRef, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAltitudeRef, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSpeedRef, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTrackRef, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtImgDirectionRef, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.numAltitude, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.numSpeed, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.numTrack, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.numImgDirection, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.labSpeedUnit, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLatitude, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLongitude, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonKmzMaker, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.buttonGetGpsData, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.nullableDateTimePicker1, 3, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 379);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Latitude:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Longitude:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 27);
            this.label3.TabIndex = 8;
            this.label3.Text = "Altitude:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 13;
            this.label5.Text = "Speed:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 27);
            this.label6.TabIndex = 18;
            this.label6.Text = "Track:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 27);
            this.label8.TabIndex = 23;
            this.label8.Text = "Image direction:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 26);
            this.label10.TabIndex = 28;
            this.label10.Text = "GPS Date / Time:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateLatitude
            // 
            this.updateLatitude.AutoSize = true;
            this.updateLatitude.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "LatitudeChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateLatitude.Location = new System.Drawing.Point(101, 3);
            this.updateLatitude.Name = "updateLatitude";
            this.updateLatitude.Size = new System.Drawing.Size(15, 21);
            this.updateLatitude.TabIndex = 1;
            this.updateLatitude.UseVisualStyleBackColor = true;
            this.updateLatitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateLatitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Schroeter.PhotoTagStudio.Data.ExifGpsModel);
            // 
            // updateLongitude
            // 
            this.updateLongitude.AutoSize = true;
            this.updateLongitude.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "LongitudeChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateLongitude.Location = new System.Drawing.Point(101, 30);
            this.updateLongitude.Name = "updateLongitude";
            this.updateLongitude.Size = new System.Drawing.Size(15, 21);
            this.updateLongitude.TabIndex = 5;
            this.updateLongitude.UseVisualStyleBackColor = true;
            this.updateLongitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateLongitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateAltitude
            // 
            this.updateAltitude.AutoSize = true;
            this.updateAltitude.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "AltitudeChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateAltitude.Location = new System.Drawing.Point(101, 57);
            this.updateAltitude.Name = "updateAltitude";
            this.updateAltitude.Size = new System.Drawing.Size(15, 21);
            this.updateAltitude.TabIndex = 9;
            this.updateAltitude.UseVisualStyleBackColor = true;
            this.updateAltitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateAltitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateSpeed
            // 
            this.updateSpeed.AutoSize = true;
            this.updateSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "SpeedChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateSpeed.Location = new System.Drawing.Point(101, 94);
            this.updateSpeed.Name = "updateSpeed";
            this.updateSpeed.Size = new System.Drawing.Size(15, 21);
            this.updateSpeed.TabIndex = 14;
            this.updateSpeed.UseVisualStyleBackColor = true;
            this.updateSpeed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateTrack
            // 
            this.updateTrack.AutoSize = true;
            this.updateTrack.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "TrackChecked", true));
            this.updateTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateTrack.Location = new System.Drawing.Point(101, 121);
            this.updateTrack.Name = "updateTrack";
            this.updateTrack.Size = new System.Drawing.Size(15, 21);
            this.updateTrack.TabIndex = 19;
            this.updateTrack.UseVisualStyleBackColor = true;
            this.updateTrack.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateTrack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateImgDirection
            // 
            this.updateImgDirection.AutoSize = true;
            this.updateImgDirection.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "ImageDirectionChecked", true));
            this.updateImgDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateImgDirection.Location = new System.Drawing.Point(101, 158);
            this.updateImgDirection.Name = "updateImgDirection";
            this.updateImgDirection.Size = new System.Drawing.Size(15, 21);
            this.updateImgDirection.TabIndex = 24;
            this.updateImgDirection.UseVisualStyleBackColor = true;
            this.updateImgDirection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateImgDirection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateDateTime
            // 
            this.updateDateTime.AutoSize = true;
            this.updateDateTime.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.updateDateTime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "DateChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateDateTime.Location = new System.Drawing.Point(101, 195);
            this.updateDateTime.Name = "updateDateTime";
            this.updateDateTime.Size = new System.Drawing.Size(15, 20);
            this.updateDateTime.TabIndex = 29;
            this.updateDateTime.UseVisualStyleBackColor = true;
            this.updateDateTime.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateDateTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtLatitudeRef
            // 
            this.txtLatitudeRef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LatitudeRef", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLatitudeRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLatitudeRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLatitudeRef.FormattingEnabled = true;
            this.txtLatitudeRef.Items.AddRange(new object[] {
            "",
            "N",
            "S"});
            this.txtLatitudeRef.Location = new System.Drawing.Point(122, 3);
            this.txtLatitudeRef.Name = "txtLatitudeRef";
            this.txtLatitudeRef.Size = new System.Drawing.Size(44, 21);
            this.txtLatitudeRef.TabIndex = 2;
            this.txtLatitudeRef.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtLatitudeRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtLongitudeRef
            // 
            this.txtLongitudeRef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "LongitudeRef", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLongitudeRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLongitudeRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLongitudeRef.FormattingEnabled = true;
            this.txtLongitudeRef.Items.AddRange(new object[] {
            "",
            "E",
            "W"});
            this.txtLongitudeRef.Location = new System.Drawing.Point(122, 30);
            this.txtLongitudeRef.Name = "txtLongitudeRef";
            this.txtLongitudeRef.Size = new System.Drawing.Size(44, 21);
            this.txtLongitudeRef.TabIndex = 6;
            this.txtLongitudeRef.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtLongitudeRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtAltitudeRef
            // 
            this.txtAltitudeRef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "AltitudeRef", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAltitudeRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAltitudeRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtAltitudeRef.FormattingEnabled = true;
            this.txtAltitudeRef.Items.AddRange(new object[] {
            "",
            "0",
            "1"});
            this.txtAltitudeRef.Location = new System.Drawing.Point(122, 57);
            this.txtAltitudeRef.Name = "txtAltitudeRef";
            this.txtAltitudeRef.Size = new System.Drawing.Size(44, 21);
            this.txtAltitudeRef.TabIndex = 10;
            this.txtAltitudeRef.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtAltitudeRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtSpeedRef
            // 
            this.txtSpeedRef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "SpeedRef", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSpeedRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpeedRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSpeedRef.FormattingEnabled = true;
            this.txtSpeedRef.Items.AddRange(new object[] {
            "",
            "K",
            "M",
            "N"});
            this.txtSpeedRef.Location = new System.Drawing.Point(122, 94);
            this.txtSpeedRef.Name = "txtSpeedRef";
            this.txtSpeedRef.Size = new System.Drawing.Size(44, 21);
            this.txtSpeedRef.TabIndex = 15;
            this.txtSpeedRef.SelectedIndexChanged += new System.EventHandler(this.txtSpeedRef_SelectedIndexChanged);
            this.txtSpeedRef.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtSpeedRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtTrackRef
            // 
            this.txtTrackRef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TrackRef", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTrackRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrackRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtTrackRef.FormattingEnabled = true;
            this.txtTrackRef.Items.AddRange(new object[] {
            "",
            "T",
            "M"});
            this.txtTrackRef.Location = new System.Drawing.Point(122, 121);
            this.txtTrackRef.Name = "txtTrackRef";
            this.txtTrackRef.Size = new System.Drawing.Size(44, 21);
            this.txtTrackRef.TabIndex = 20;
            this.txtTrackRef.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtTrackRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtImgDirectionRef
            // 
            this.txtImgDirectionRef.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ImageDirectionRef", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtImgDirectionRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImgDirectionRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtImgDirectionRef.FormattingEnabled = true;
            this.txtImgDirectionRef.Items.AddRange(new object[] {
            "",
            "T",
            "M"});
            this.txtImgDirectionRef.Location = new System.Drawing.Point(122, 158);
            this.txtImgDirectionRef.Name = "txtImgDirectionRef";
            this.txtImgDirectionRef.Size = new System.Drawing.Size(44, 21);
            this.txtImgDirectionRef.TabIndex = 25;
            this.txtImgDirectionRef.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtImgDirectionRef.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // numAltitude
            // 
            this.numAltitude.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Altitude", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numAltitude.DecimalPlaces = 1;
            this.numAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numAltitude.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAltitude.Location = new System.Drawing.Point(172, 57);
            this.numAltitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAltitude.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numAltitude.Name = "numAltitude";
            this.numAltitude.Size = new System.Drawing.Size(123, 20);
            this.numAltitude.TabIndex = 11;
            this.numAltitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numAltitude.ThousandsSeparator = true;
            this.numAltitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.numAltitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // numSpeed
            // 
            this.numSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Speed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numSpeed.DecimalPlaces = 1;
            this.numSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSpeed.Location = new System.Drawing.Point(172, 94);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(123, 20);
            this.numSpeed.TabIndex = 16;
            this.numSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSpeed.ThousandsSeparator = true;
            this.numSpeed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.numSpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // numTrack
            // 
            this.numTrack.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Track", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numTrack.DecimalPlaces = 2;
            this.numTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numTrack.Location = new System.Drawing.Point(172, 121);
            this.numTrack.Maximum = new decimal(new int[] {
            35999,
            0,
            0,
            131072});
            this.numTrack.Name = "numTrack";
            this.numTrack.Size = new System.Drawing.Size(123, 20);
            this.numTrack.TabIndex = 21;
            this.numTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTrack.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.numTrack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // numImgDirection
            // 
            this.numImgDirection.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ImageDirection", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numImgDirection.DecimalPlaces = 2;
            this.numImgDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numImgDirection.Location = new System.Drawing.Point(172, 158);
            this.numImgDirection.Maximum = new decimal(new int[] {
            35999,
            0,
            0,
            131072});
            this.numImgDirection.Name = "numImgDirection";
            this.numImgDirection.Size = new System.Drawing.Size(123, 20);
            this.numImgDirection.TabIndex = 26;
            this.numImgDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numImgDirection.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.numImgDirection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(301, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 27);
            this.label4.TabIndex = 22;
            this.label4.Text = "°";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(301, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 27);
            this.label7.TabIndex = 27;
            this.label7.Text = "°";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labSpeedUnit
            // 
            this.labSpeedUnit.AutoSize = true;
            this.labSpeedUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labSpeedUnit.Location = new System.Drawing.Point(301, 91);
            this.labSpeedUnit.Name = "labSpeedUnit";
            this.labSpeedUnit.Size = new System.Drawing.Size(32, 27);
            this.labSpeedUnit.TabIndex = 17;
            this.labSpeedUnit.Text = "km/h";
            this.labSpeedUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(301, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 27);
            this.label11.TabIndex = 12;
            this.label11.Text = "m";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLatitude
            // 
            this.txtLatitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Latitude", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLatitude.Location = new System.Drawing.Point(172, 3);
            this.txtLatitude.Name = "txtLatitude";
            this.txtLatitude.Size = new System.Drawing.Size(123, 20);
            this.txtLatitude.TabIndex = 3;
            this.txtLatitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLatitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtLatitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // txtLongitude
            // 
            this.txtLongitude.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Longitude", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLongitude.Location = new System.Drawing.Point(172, 30);
            this.txtLongitude.Name = "txtLongitude";
            this.txtLongitude.Size = new System.Drawing.Size(123, 20);
            this.txtLongitude.TabIndex = 7;
            this.txtLongitude.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLongitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtLongitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // buttonKmzMaker
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonKmzMaker, 2);
            this.buttonKmzMaker.Location = new System.Drawing.Point(122, 260);
            this.buttonKmzMaker.Name = "buttonKmzMaker";
            this.buttonKmzMaker.Size = new System.Drawing.Size(108, 23);
            this.buttonKmzMaker.TabIndex = 32;
            this.buttonKmzMaker.Text = "Create kmz";
            this.buttonKmzMaker.UseVisualStyleBackColor = true;
            this.buttonKmzMaker.Click += new System.EventHandler(this.buttonKmzMaker_Click);
            // 
            // buttonGetGpsData
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonGetGpsData, 2);
            this.buttonGetGpsData.Location = new System.Drawing.Point(122, 231);
            this.buttonGetGpsData.Name = "buttonGetGpsData";
            this.buttonGetGpsData.Size = new System.Drawing.Size(108, 23);
            this.buttonGetGpsData.TabIndex = 31;
            this.buttonGetGpsData.Text = "Tag from gps log";
            this.buttonGetGpsData.UseVisualStyleBackColor = true;
            this.buttonGetGpsData.Click += new System.EventHandler(this.buttonGetGpsData_Click);
            // 
            // nullableDateTimePicker1
            // 
            this.nullableDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nullableDateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nullableDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nullableDateTimePicker1.Location = new System.Drawing.Point(172, 195);
            this.nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            this.nullableDateTimePicker1.Size = new System.Drawing.Size(123, 20);
            this.nullableDateTimePicker1.TabIndex = 30;
            this.nullableDateTimePicker1.Value = new System.DateTime(2008, 3, 6, 20, 42, 12, 496);
            this.nullableDateTimePicker1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.nullableDateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // ExifGpsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExifGpsView";
            this.Size = new System.Drawing.Size(336, 379);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImgDirection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox updateLatitude;
        private System.Windows.Forms.CheckBox updateLongitude;
        private System.Windows.Forms.CheckBox updateAltitude;
        private System.Windows.Forms.CheckBox updateSpeed;
        private System.Windows.Forms.CheckBox updateTrack;
        private System.Windows.Forms.CheckBox updateImgDirection;
        private System.Windows.Forms.CheckBox updateDateTime;
        private System.Windows.Forms.ComboBox txtLatitudeRef;
        private System.Windows.Forms.ComboBox txtLongitudeRef;
        private System.Windows.Forms.ComboBox txtAltitudeRef;
        private System.Windows.Forms.ComboBox txtSpeedRef;
        private System.Windows.Forms.ComboBox txtTrackRef;
        private System.Windows.Forms.ComboBox txtImgDirectionRef;
        private Schroeter.Windows.Forms.NumericUpDownReplacement numAltitude;
        private Schroeter.Windows.Forms.NumericUpDownReplacement numSpeed;
        private Schroeter.Windows.Forms.NumericUpDownReplacement numTrack;
        private Schroeter.Windows.Forms.NumericUpDownReplacement numImgDirection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labSpeedUnit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtLatitude;
        private System.Windows.Forms.MaskedTextBox txtLongitude;
        private System.Windows.Forms.Button buttonKmzMaker;
        private System.Windows.Forms.Button buttonGetGpsData;
        private System.Windows.Forms.BindingSource bindingSource;
        private Schroeter.Windows.Forms.NullableDateTimePicker nullableDateTimePicker1;
    }
}
