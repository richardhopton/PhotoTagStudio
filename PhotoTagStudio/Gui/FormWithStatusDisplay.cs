#region Copyright (C) 2005-2008 Benjamin Schröter <benjamin@irgendwie.net>
//
// This file is part of PhotoTagStudio
//
// PhotoTagStudio is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// PhotoTagStudio is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with PhotoTagStudio; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, 5th Floor, Boston, MA 02110-1301 USA.
#endregion

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui
{
    public class FormWithStatusDisplay : Form, IStatusDisplay
    {
        protected  StatusStrip statusStrip;
        private ToolStripProgressBar toolStripProgressBar;
        private ToolStripStatusLabel toolStripStatusLabel;
        
        private StatusDisplay mainStatusDisplay;

        protected FormWithStatusDisplay()
        {
            InitializeComponent();

            mainStatusDisplay = new StatusDisplay(this.toolStripProgressBar, this.toolStripStatusLabel);
        }

        public void WorkProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if ( e.ProgressPercentage == 0 )
                WaitCursor(true);

            mainStatusDisplay.WorkProgressChanged(sender,e);
        }

        public void WorkFinished()
        {
            mainStatusDisplay.WorkFinished();
            WaitCursor(false);
        }

        public void WaitCursor(bool on)
        {
            this.Cursor = on ? Cursors.WaitCursor : Cursors.Default;
        }

        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 242);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // FormWithStatusDisplay
            // 
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.statusStrip);
            this.Name = "FormWithStatusDisplay";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}