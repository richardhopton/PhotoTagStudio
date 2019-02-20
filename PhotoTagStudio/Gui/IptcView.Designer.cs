
namespace Schroeter.PhotoTagStudio.Gui
{
    partial class IptcView
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
            this.txtProvinceState = new System.Windows.Forms.TextBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtContryName = new System.Windows.Forms.TextBox();
            this.labelObjectName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelProvinceState = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCountryName = new System.Windows.Forms.Label();
            this.txtContryCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelHeadline = new System.Windows.Forms.Label();
            this.labelCaption = new System.Windows.Forms.Label();
            this.updateHeadline = new System.Windows.Forms.CheckBox();
            this.updateCaption = new System.Windows.Forms.CheckBox();
            this.updateObjectName = new System.Windows.Forms.CheckBox();
            this.updateWriter = new System.Windows.Forms.CheckBox();
            this.updateAuthor = new System.Windows.Forms.CheckBox();
            this.updateCopyright = new System.Windows.Forms.CheckBox();
            this.updateCity = new System.Windows.Forms.CheckBox();
            this.updateSublocation = new System.Windows.Forms.CheckBox();
            this.updateState = new System.Windows.Forms.CheckBox();
            this.updateCountryName = new System.Windows.Forms.CheckBox();
            this.updateCountryCode = new System.Windows.Forms.CheckBox();
            this.updateDateCreated = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.updateContact = new System.Windows.Forms.CheckBox();
            this.txtHeadline = new System.Windows.Forms.ComboBox();
            this.txtCaption = new System.Windows.Forms.ComboBox();
            this.txtObjectName = new System.Windows.Forms.ComboBox();
            this.txtWriter = new System.Windows.Forms.ComboBox();
            this.txtAuthorByline = new System.Windows.Forms.ComboBox();
            this.txtCopyright = new System.Windows.Forms.ComboBox();
            this.txtContact = new System.Windows.Forms.ComboBox();
            this.txtCity = new System.Windows.Forms.ComboBox();
            this.txtSublocation = new System.Windows.Forms.TextBox();
            this.chkSelectAllKeywords = new System.Windows.Forms.CheckBox();
            this.treeKeywords = new Schroeter.Windows.Forms.ThreeStateTreeView();
            this.labelKeywords = new System.Windows.Forms.Label();
            this.updateKeywords = new System.Windows.Forms.CheckBox();
            this.btnAddKeyword = new System.Windows.Forms.Button();
            this.chkCreatedFromExif = new System.Windows.Forms.CheckBox();
            this.nullableDateTimePicker1 = new Schroeter.Windows.Forms.NullableDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProvinceState
            // 
            this.txtProvinceState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvinceState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ProvinceState", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtProvinceState.Location = new System.Drawing.Point(110, 245);
            this.txtProvinceState.Name = "txtProvinceState";
            this.txtProvinceState.Size = new System.Drawing.Size(153, 20);
            this.txtProvinceState.TabIndex = 29;
            this.txtProvinceState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtProvinceState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Schroeter.PhotoTagStudio.Data.IptcModel);
            // 
            // txtContryName
            // 
            this.txtContryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContryName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CountryName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtContryName.Location = new System.Drawing.Point(110, 271);
            this.txtContryName.Name = "txtContryName";
            this.txtContryName.Size = new System.Drawing.Size(153, 20);
            this.txtContryName.TabIndex = 32;
            this.txtContryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtContryName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // labelObjectName
            // 
            this.labelObjectName.AutoSize = true;
            this.labelObjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelObjectName.Location = new System.Drawing.Point(3, 54);
            this.labelObjectName.Name = "labelObjectName";
            this.labelObjectName.Size = new System.Drawing.Size(80, 27);
            this.labelObjectName.TabIndex = 6;
            this.labelObjectName.Text = "Object name:";
            this.labelObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "Sublocation:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 27);
            this.label5.TabIndex = 15;
            this.label5.Text = "Copyright:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelProvinceState
            // 
            this.labelProvinceState.AutoSize = true;
            this.labelProvinceState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProvinceState.Location = new System.Drawing.Point(3, 242);
            this.labelProvinceState.Name = "labelProvinceState";
            this.labelProvinceState.Size = new System.Drawing.Size(80, 26);
            this.labelProvinceState.TabIndex = 27;
            this.labelProvinceState.Text = "Province/state:";
            this.labelProvinceState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 27);
            this.label7.TabIndex = 9;
            this.label7.Text = "Writer:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCity.Location = new System.Drawing.Point(3, 189);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(80, 27);
            this.labelCity.TabIndex = 21;
            this.labelCity.Text = "City:";
            this.labelCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 27);
            this.label9.TabIndex = 12;
            this.label9.Text = "Author (byline):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCountryName
            // 
            this.labelCountryName.AutoSize = true;
            this.labelCountryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCountryName.Location = new System.Drawing.Point(3, 268);
            this.labelCountryName.Name = "labelCountryName";
            this.labelCountryName.Size = new System.Drawing.Size(80, 26);
            this.labelCountryName.TabIndex = 30;
            this.labelCountryName.Text = "Country name:";
            this.labelCountryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContryCode
            // 
            this.txtContryCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContryCode.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "CountryCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtContryCode.Location = new System.Drawing.Point(110, 297);
            this.txtContryCode.Name = "txtContryCode";
            this.txtContryCode.Size = new System.Drawing.Size(153, 20);
            this.txtContryCode.TabIndex = 35;
            this.txtContryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtContryCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 26);
            this.label11.TabIndex = 33;
            this.label11.Text = "Country code:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 320);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 26);
            this.label13.TabIndex = 36;
            this.label13.Text = "Created:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.labelHeadline, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCaption, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelObjectName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtContryCode, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtContryName, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtProvinceState, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelCity, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelCountryName, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelProvinceState, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.updateHeadline, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateCaption, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.updateObjectName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.updateWriter, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.updateAuthor, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.updateCopyright, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.updateCity, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.updateSublocation, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.updateState, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.updateCountryName, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.updateCountryCode, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.updateDateCreated, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.updateContact, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtHeadline, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCaption, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtObjectName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtWriter, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAuthorByline, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCopyright, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtContact, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtCity, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtSublocation, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.chkSelectAllKeywords, 3, 15);
            this.tableLayoutPanel1.Controls.Add(this.treeKeywords, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelKeywords, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.updateKeywords, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddKeyword, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkCreatedFromExif, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.nullableDateTimePicker1, 2, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 476);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelHeadline
            // 
            this.labelHeadline.AutoSize = true;
            this.labelHeadline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeadline.Location = new System.Drawing.Point(3, 0);
            this.labelHeadline.Name = "labelHeadline";
            this.labelHeadline.Size = new System.Drawing.Size(80, 27);
            this.labelHeadline.TabIndex = 0;
            this.labelHeadline.Text = "Headline:";
            this.labelHeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
            this.labelCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCaption.Location = new System.Drawing.Point(3, 27);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(80, 27);
            this.labelCaption.TabIndex = 3;
            this.labelCaption.Text = "Caption:";
            this.labelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateHeadline
            // 
            this.updateHeadline.AutoSize = true;
            this.updateHeadline.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "HeadlineChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateHeadline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateHeadline.Location = new System.Drawing.Point(89, 3);
            this.updateHeadline.Name = "updateHeadline";
            this.updateHeadline.Size = new System.Drawing.Size(15, 21);
            this.updateHeadline.TabIndex = 1;
            this.updateHeadline.UseVisualStyleBackColor = true;
            this.updateHeadline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateHeadline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateCaption
            // 
            this.updateCaption.AutoSize = true;
            this.updateCaption.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CaptionChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateCaption.Location = new System.Drawing.Point(89, 30);
            this.updateCaption.Name = "updateCaption";
            this.updateCaption.Size = new System.Drawing.Size(15, 21);
            this.updateCaption.TabIndex = 4;
            this.updateCaption.UseVisualStyleBackColor = true;
            this.updateCaption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateCaption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateObjectName
            // 
            this.updateObjectName.AutoSize = true;
            this.updateObjectName.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "ObjectNameChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateObjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateObjectName.Location = new System.Drawing.Point(89, 57);
            this.updateObjectName.Name = "updateObjectName";
            this.updateObjectName.Size = new System.Drawing.Size(15, 21);
            this.updateObjectName.TabIndex = 7;
            this.updateObjectName.UseVisualStyleBackColor = true;
            this.updateObjectName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateObjectName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateWriter
            // 
            this.updateWriter.AutoSize = true;
            this.updateWriter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "WriteChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateWriter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateWriter.Location = new System.Drawing.Point(89, 84);
            this.updateWriter.Name = "updateWriter";
            this.updateWriter.Size = new System.Drawing.Size(15, 21);
            this.updateWriter.TabIndex = 10;
            this.updateWriter.UseVisualStyleBackColor = true;
            this.updateWriter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateWriter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateAuthor
            // 
            this.updateAuthor.AutoSize = true;
            this.updateAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "AuthorChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateAuthor.Location = new System.Drawing.Point(89, 111);
            this.updateAuthor.Name = "updateAuthor";
            this.updateAuthor.Size = new System.Drawing.Size(15, 21);
            this.updateAuthor.TabIndex = 13;
            this.updateAuthor.UseVisualStyleBackColor = true;
            this.updateAuthor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateCopyright
            // 
            this.updateCopyright.AutoSize = true;
            this.updateCopyright.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CopyrightChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateCopyright.Location = new System.Drawing.Point(89, 138);
            this.updateCopyright.Name = "updateCopyright";
            this.updateCopyright.Size = new System.Drawing.Size(15, 21);
            this.updateCopyright.TabIndex = 16;
            this.updateCopyright.UseVisualStyleBackColor = true;
            this.updateCopyright.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateCopyright.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateCity
            // 
            this.updateCity.AutoSize = true;
            this.updateCity.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CityChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateCity.Location = new System.Drawing.Point(89, 192);
            this.updateCity.Name = "updateCity";
            this.updateCity.Size = new System.Drawing.Size(15, 21);
            this.updateCity.TabIndex = 22;
            this.updateCity.UseVisualStyleBackColor = true;
            this.updateCity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateSublocation
            // 
            this.updateSublocation.AutoSize = true;
            this.updateSublocation.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "SublocationChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateSublocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateSublocation.Location = new System.Drawing.Point(89, 219);
            this.updateSublocation.Name = "updateSublocation";
            this.updateSublocation.Size = new System.Drawing.Size(15, 20);
            this.updateSublocation.TabIndex = 25;
            this.updateSublocation.UseVisualStyleBackColor = true;
            this.updateSublocation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateSublocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateState
            // 
            this.updateState.AutoSize = true;
            this.updateState.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "ProvinceStateChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateState.Location = new System.Drawing.Point(89, 245);
            this.updateState.Name = "updateState";
            this.updateState.Size = new System.Drawing.Size(15, 20);
            this.updateState.TabIndex = 28;
            this.updateState.UseVisualStyleBackColor = true;
            this.updateState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateState.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateCountryName
            // 
            this.updateCountryName.AutoSize = true;
            this.updateCountryName.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CountryNameChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateCountryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateCountryName.Location = new System.Drawing.Point(89, 271);
            this.updateCountryName.Name = "updateCountryName";
            this.updateCountryName.Size = new System.Drawing.Size(15, 20);
            this.updateCountryName.TabIndex = 31;
            this.updateCountryName.UseVisualStyleBackColor = true;
            this.updateCountryName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateCountryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateCountryCode
            // 
            this.updateCountryCode.AutoSize = true;
            this.updateCountryCode.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CountryCodeChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateCountryCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateCountryCode.Location = new System.Drawing.Point(89, 297);
            this.updateCountryCode.Name = "updateCountryCode";
            this.updateCountryCode.Size = new System.Drawing.Size(15, 20);
            this.updateCountryCode.TabIndex = 34;
            this.updateCountryCode.UseVisualStyleBackColor = true;
            this.updateCountryCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateCountryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // updateDateCreated
            // 
            this.updateDateCreated.AutoSize = true;
            this.updateDateCreated.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.updateDateCreated.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "CreatedChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateDateCreated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateDateCreated.Location = new System.Drawing.Point(89, 323);
            this.updateDateCreated.Name = "updateDateCreated";
            this.updateDateCreated.Size = new System.Drawing.Size(15, 20);
            this.updateDateCreated.TabIndex = 37;
            this.updateDateCreated.UseVisualStyleBackColor = true;
            this.updateDateCreated.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateDateCreated.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 27);
            this.label14.TabIndex = 18;
            this.label14.Text = "Contact:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateContact
            // 
            this.updateContact.AutoSize = true;
            this.updateContact.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "ContactChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateContact.Location = new System.Drawing.Point(89, 165);
            this.updateContact.Name = "updateContact";
            this.updateContact.Size = new System.Drawing.Size(15, 14);
            this.updateContact.TabIndex = 19;
            this.updateContact.UseVisualStyleBackColor = true;
            this.updateContact.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtHeadline
            // 
            this.txtHeadline.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Headline", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHeadline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHeadline.FormattingEnabled = true;
            this.txtHeadline.Location = new System.Drawing.Point(110, 3);
            this.txtHeadline.MaxDropDownItems = 16;
            this.txtHeadline.Name = "txtHeadline";
            this.txtHeadline.Size = new System.Drawing.Size(153, 21);
            this.txtHeadline.TabIndex = 2;
            this.txtHeadline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtHeadline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtCaption
            // 
            this.txtCaption.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Caption", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCaption.FormattingEnabled = true;
            this.txtCaption.Location = new System.Drawing.Point(110, 30);
            this.txtCaption.MaxDropDownItems = 16;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(153, 21);
            this.txtCaption.TabIndex = 5;
            this.txtCaption.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtCaption.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtObjectName
            // 
            this.txtObjectName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "ObjectName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtObjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtObjectName.FormattingEnabled = true;
            this.txtObjectName.Location = new System.Drawing.Point(110, 57);
            this.txtObjectName.MaxDropDownItems = 16;
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(153, 21);
            this.txtObjectName.TabIndex = 8;
            this.txtObjectName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtObjectName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtWriter
            // 
            this.txtWriter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Writer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtWriter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWriter.FormattingEnabled = true;
            this.txtWriter.Location = new System.Drawing.Point(110, 84);
            this.txtWriter.MaxDropDownItems = 16;
            this.txtWriter.Name = "txtWriter";
            this.txtWriter.Size = new System.Drawing.Size(153, 21);
            this.txtWriter.TabIndex = 11;
            this.txtWriter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtWriter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtAuthorByline
            // 
            this.txtAuthorByline.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Author", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtAuthorByline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAuthorByline.FormattingEnabled = true;
            this.txtAuthorByline.Location = new System.Drawing.Point(110, 111);
            this.txtAuthorByline.MaxDropDownItems = 16;
            this.txtAuthorByline.Name = "txtAuthorByline";
            this.txtAuthorByline.Size = new System.Drawing.Size(153, 21);
            this.txtAuthorByline.TabIndex = 14;
            this.txtAuthorByline.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtAuthorByline.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtCopyright
            // 
            this.txtCopyright.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Copyright", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCopyright.FormattingEnabled = true;
            this.txtCopyright.Location = new System.Drawing.Point(110, 138);
            this.txtCopyright.MaxDropDownItems = 16;
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.Size = new System.Drawing.Size(153, 21);
            this.txtCopyright.TabIndex = 17;
            this.txtCopyright.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtCopyright.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtContact
            // 
            this.txtContact.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Contact", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContact.FormattingEnabled = true;
            this.txtContact.Location = new System.Drawing.Point(110, 165);
            this.txtContact.MaxDropDownItems = 16;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(153, 21);
            this.txtContact.TabIndex = 20;
            this.txtContact.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtContact.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // txtCity
            // 
            this.txtCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtCity.DropDownWidth = 250;
            this.txtCity.FormattingEnabled = true;
            this.txtCity.Location = new System.Drawing.Point(110, 192);
            this.txtCity.MaxDropDownItems = 16;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(153, 21);
            this.txtCity.TabIndex = 23;
            this.txtCity.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.txtCity_DrawItem);
            this.txtCity.SelectedIndexChanged += new System.EventHandler(this.txtCity_SelectedIndexChanged);
            this.txtCity.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.txtCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtCity.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.txtCity_Format);
            // 
            // txtSublocation
            // 
            this.txtSublocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Sublocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSublocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSublocation.Location = new System.Drawing.Point(110, 219);
            this.txtSublocation.Name = "txtSublocation";
            this.txtSublocation.Size = new System.Drawing.Size(153, 20);
            this.txtSublocation.TabIndex = 26;
            this.txtSublocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txtSublocation.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            // 
            // chkSelectAllKeywords
            // 
            this.chkSelectAllKeywords.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkSelectAllKeywords, 3);
            this.chkSelectAllKeywords.Location = new System.Drawing.Point(269, 456);
            this.chkSelectAllKeywords.Name = "chkSelectAllKeywords";
            this.chkSelectAllKeywords.Size = new System.Drawing.Size(67, 17);
            this.chkSelectAllKeywords.TabIndex = 43;
            this.chkSelectAllKeywords.Text = "select all";
            this.chkSelectAllKeywords.ThreeState = true;
            this.chkSelectAllKeywords.UseVisualStyleBackColor = true;
            this.chkSelectAllKeywords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.chkSelectAllKeywords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // treeKeywords
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.treeKeywords, 3);
            this.treeKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeKeywords.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeKeywords.FullRowSelect = true;
            this.treeKeywords.IntegralHeight = true;
            this.treeKeywords.Location = new System.Drawing.Point(269, 30);
            this.treeKeywords.Name = "treeKeywords";
            this.treeKeywords.ReverseCheckStateOrder = true;
            this.tableLayoutPanel1.SetRowSpan(this.treeKeywords, 14);
            this.treeKeywords.ShowLines = false;
            this.treeKeywords.ShowRootLines = false;
            this.treeKeywords.Size = new System.Drawing.Size(182, 419);
            this.treeKeywords.SpecialSelectMode = false;
            this.treeKeywords.TabIndex = 42;
            this.treeKeywords.ThreeState = true;
            this.treeKeywords.AfterCheckStateChanged += new System.Windows.Forms.TreeViewEventHandler(this.treeKeywords_AfterCheckStateChanged);
            this.treeKeywords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.treeKeywords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // labelKeywords
            // 
            this.labelKeywords.AutoSize = true;
            this.labelKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelKeywords.Location = new System.Drawing.Point(269, 0);
            this.labelKeywords.Name = "labelKeywords";
            this.labelKeywords.Size = new System.Drawing.Size(56, 27);
            this.labelKeywords.TabIndex = 40;
            this.labelKeywords.Text = "Keywords:";
            this.labelKeywords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateKeywords
            // 
            this.updateKeywords.AutoSize = true;
            this.updateKeywords.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "KeywordChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.updateKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateKeywords.Location = new System.Drawing.Point(331, 3);
            this.updateKeywords.Name = "updateKeywords";
            this.updateKeywords.Size = new System.Drawing.Size(14, 21);
            this.updateKeywords.TabIndex = 41;
            this.updateKeywords.UseVisualStyleBackColor = true;
            this.updateKeywords.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.updateKeywords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // btnAddKeyword
            // 
            this.btnAddKeyword.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddKeyword.Location = new System.Drawing.Point(435, 3);
            this.btnAddKeyword.Name = "btnAddKeyword";
            this.btnAddKeyword.Size = new System.Drawing.Size(16, 21);
            this.btnAddKeyword.TabIndex = 44;
            this.btnAddKeyword.Text = "+";
            this.btnAddKeyword.UseVisualStyleBackColor = true;
            this.btnAddKeyword.Click += new System.EventHandler(this.btnAddKeyword_Click);
            // 
            // chkCreatedFromExif
            // 
            this.chkCreatedFromExif.AutoSize = true;
            this.chkCreatedFromExif.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCreatedFromExif.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "GetDateFromExifChecked", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCreatedFromExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCreatedFromExif.Location = new System.Drawing.Point(110, 349);
            this.chkCreatedFromExif.Name = "chkCreatedFromExif";
            this.chkCreatedFromExif.Size = new System.Drawing.Size(153, 17);
            this.chkCreatedFromExif.TabIndex = 39;
            this.chkCreatedFromExif.Text = "from EXIF";
            this.chkCreatedFromExif.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCreatedFromExif.UseVisualStyleBackColor = true;
            this.chkCreatedFromExif.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.chkCreatedFromExif.CheckedChanged += new System.EventHandler(this.chkCreatedFromExif_CheckedChanged);
            this.chkCreatedFromExif.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // nullableDateTimePicker1
            // 
            this.nullableDateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "Created", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nullableDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.nullableDateTimePicker1.Location = new System.Drawing.Point(110, 323);
            this.nullableDateTimePicker1.Name = "nullableDateTimePicker1";
            this.nullableDateTimePicker1.Size = new System.Drawing.Size(153, 20);
            this.nullableDateTimePicker1.TabIndex = 38;
            this.nullableDateTimePicker1.Value = new System.DateTime(2008, 3, 6, 19, 48, 12, 206);
            this.nullableDateTimePicker1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.nullableDateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // IptcView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "IptcView";
            this.Size = new System.Drawing.Size(454, 476);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProvinceState;
        private System.Windows.Forms.TextBox txtContryName;
        private System.Windows.Forms.Label labelObjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelProvinceState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelCountryName;
        private System.Windows.Forms.TextBox txtContryCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelHeadline;
        private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.CheckBox updateHeadline;
        private System.Windows.Forms.CheckBox updateCaption;
        private System.Windows.Forms.CheckBox updateObjectName;
        private System.Windows.Forms.CheckBox updateWriter;
        private System.Windows.Forms.CheckBox updateAuthor;
        private System.Windows.Forms.CheckBox updateCopyright;
        private System.Windows.Forms.CheckBox updateCity;
        private System.Windows.Forms.CheckBox updateSublocation;
        private System.Windows.Forms.CheckBox updateState;
        private System.Windows.Forms.CheckBox updateCountryName;
        private System.Windows.Forms.CheckBox updateCountryCode;
        private System.Windows.Forms.CheckBox updateDateCreated;
        private System.Windows.Forms.Label labelKeywords;
        private System.Windows.Forms.CheckBox updateKeywords;
        private System.Windows.Forms.CheckBox chkCreatedFromExif;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox updateContact;
        private System.Windows.Forms.ComboBox txtHeadline;
        private System.Windows.Forms.ComboBox txtCaption;
        private System.Windows.Forms.ComboBox txtObjectName;
        private System.Windows.Forms.ComboBox txtWriter;
        private System.Windows.Forms.ComboBox txtAuthorByline;
        private System.Windows.Forms.ComboBox txtCopyright;
        private System.Windows.Forms.ComboBox txtContact;
        private System.Windows.Forms.Button btnAddKeyword;
        private System.Windows.Forms.ComboBox txtCity;
        private System.Windows.Forms.TextBox txtSublocation;
        private System.Windows.Forms.CheckBox chkSelectAllKeywords;
        private Schroeter.Windows.Forms.ThreeStateTreeView treeKeywords;
        private System.Windows.Forms.BindingSource bindingSource;
        private Schroeter.Windows.Forms.NullableDateTimePicker nullableDateTimePicker1;



    }
}
