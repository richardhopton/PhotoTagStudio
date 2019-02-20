namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    partial class LocationListEditor
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textCity = new System.Windows.Forms.TextBox();
            this.textSublocation = new System.Windows.Forms.TextBox();
            this.textState = new System.Windows.Forms.TextBox();
            this.textCountryName = new System.Windows.Forms.TextBox();
            this.textCountryCode = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 241);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(165, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "add new values automatically";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "City && Sublocation:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Province/state:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Country name && code:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textCity
            // 
            this.textCity.AcceptsReturn = true;
            this.textCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCity.Location = new System.Drawing.Point(120, 3);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(87, 20);
            this.textCity.TabIndex = 1;
            this.textCity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCity_KeyPress);
            // 
            // textSublocation
            // 
            this.textSublocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSublocation.Location = new System.Drawing.Point(213, 3);
            this.textSublocation.Name = "textSublocation";
            this.textSublocation.Size = new System.Drawing.Size(87, 20);
            this.textSublocation.TabIndex = 2;
            this.textSublocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSublocation_KeyPress);
            // 
            // textState
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textState, 2);
            this.textState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textState.Location = new System.Drawing.Point(120, 29);
            this.textState.Name = "textState";
            this.textState.Size = new System.Drawing.Size(180, 20);
            this.textState.TabIndex = 4;
            this.textState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textState_KeyPress);
            // 
            // textCountryName
            // 
            this.textCountryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCountryName.Location = new System.Drawing.Point(120, 55);
            this.textCountryName.Name = "textCountryName";
            this.textCountryName.Size = new System.Drawing.Size(87, 20);
            this.textCountryName.TabIndex = 6;
            this.textCountryName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCountryName_KeyPress);
            // 
            // textCountryCode
            // 
            this.textCountryCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCountryCode.Location = new System.Drawing.Point(213, 55);
            this.textCountryCode.Name = "textCountryCode";
            this.textCountryCode.Size = new System.Drawing.Size(87, 20);
            this.textCountryCode.TabIndex = 7;
            this.textCountryCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCountryCode_KeyPress);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                           | System.Windows.Forms.AnchorStyles.Left)
                                                                          | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.columnHeader1,
                                                                                        this.columnHeader2,
                                                                                        this.columnHeader3,
                                                                                        this.columnHeader4,
                                                                                        this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(6, 84);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(300, 151);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "City";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sublocation";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "State";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Country name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Country code";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                  | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textCountryCode, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textCountryName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textCity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textState, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textSublocation, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(303, 79);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // LocationListEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.checkBox1);
            this.Name = "LocationListEditor";
            this.Size = new System.Drawing.Size(309, 267);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textCity;
        private System.Windows.Forms.TextBox textSublocation;
        private System.Windows.Forms.TextBox textState;
        private System.Windows.Forms.TextBox textCountryName;
        private System.Windows.Forms.TextBox textCountryCode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
