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

using System.ComponentModel;
using System.Windows.Forms;

namespace Schroeter.PhotoTagStudio
{
    public class StatusDisplay : IStatusDisplay
    {
        private ToolStripProgressBar progressBar;
        private ToolStripStatusLabel statusLabel;

        public StatusDisplay(ToolStripProgressBar progressBar) : this(progressBar, null)
        {
            
        }        
        
        public StatusDisplay(ToolStripProgressBar progressBar, ToolStripStatusLabel statusLabel)
        {
            this.progressBar = progressBar;
            this.statusLabel = statusLabel;
        }

        // mostly the same code as in StandAloneMacroExecutionForm
        #region IStatusDisplay
        public void WorkProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage ==0 )
            {
                progressBar.Visible = true;
                progressBar.Maximum = 100; // 100%  //TODO da die sich nie ändern können wir uns das hier auch sparen (das geliche gibst nochmal wonaders)

                if (statusLabel != null)
                    statusLabel.Text = "";
            }
            else
            {
                if (statusLabel != null)
                    statusLabel.Text = "(" + e.ProgressPercentage + "%)";                
            }

            progressBar.Value = e.ProgressPercentage;

            this.progressBar.Owner.Refresh();
        }

        public void WorkFinished()
        {
            progressBar.Visible = false;
            progressBar.Value = 0;
            if (statusLabel != null)
                statusLabel.Text = "";

            this.progressBar.Owner.Refresh();
        }
        #endregion
    }
}