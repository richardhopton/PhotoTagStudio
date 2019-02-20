namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    partial class CopyMoveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyMoveForm));
            this.btnCopyRename = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.copyMoveView1 = new Schroeter.PhotoTagStudio.Features.Renamer.CopyMoveView();
            this.SuspendLayout();
            // 
            // btnCopyRename
            // 
            this.btnCopyRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyRename.Location = new System.Drawing.Point(320, 250);
            this.btnCopyRename.Name = "btnCopyRename";
            this.btnCopyRename.Size = new System.Drawing.Size(75, 23);
            this.btnCopyRename.TabIndex = 1;
            this.btnCopyRename.Text = "OK";
            this.btnCopyRename.UseVisualStyleBackColor = true;
            this.btnCopyRename.Click += new System.EventHandler(this.btnCopyRename_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(401, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // copyMoveView1
            // 
            this.copyMoveView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.copyMoveView1.Location = new System.Drawing.Point(12, 12);
            this.copyMoveView1.Name = "copyMoveView1";
            this.copyMoveView1.Size = new System.Drawing.Size(464, 232);
            this.copyMoveView1.TabIndex = 0;
            // 
            // CopyMoveForm
            // 
            this.AcceptButton = this.btnCopyRename;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(488, 298);
            this.Controls.Add(this.copyMoveView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCopyRename);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CopyMoveForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copy and move files";
            this.Controls.SetChildIndex(this.btnCopyRename, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.copyMoveView1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CopyMoveView copyMoveView1;
        private System.Windows.Forms.Button btnCopyRename;
        private System.Windows.Forms.Button btnClose;
    }
}