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
using System.Reflection;
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui
{
    partial class StandAloneMacroExecutionForm : Form , IStatusDisplay
    {
        private const string FORM_TITLE = "PhotoTagStudio";
        private const string FORM_TITLE_WITH_PERCENT = "{0}% - PhotoTagStudio";

        private Macro macro;
        private string startDirectory;
        private bool askBeforeExecutionWhenDirectoryIsGivenFromFirstItem;

        public StandAloneMacroExecutionForm(Macro macro, string startDirectory, bool askBeforeExecutionWhenDirectoryIsGivenFromFirstItem)
        {
            this.Icon = Resources.PTS;

            this.macro = macro;
            this.startDirectory = startDirectory;
            this.askBeforeExecutionWhenDirectoryIsGivenFromFirstItem = askBeforeExecutionWhenDirectoryIsGivenFromFirstItem;

            InitializeComponent();

            this.labelName.Text = macro.Name;
            this.textDescription.Text = macro.Description;
            this.textDescription.Focus();
        }

        private void StandAloneMacroExecutionForm_Shown(object sender, EventArgs e)
        {
            bool running = Macros.ExecuteMacro(macro, startDirectory, askBeforeExecutionWhenDirectoryIsGivenFromFirstItem, this, this);
            if (!running)
                this.Close();
        }

        // mostly the same code as in StatusDisplay
        #region IStatusDisplay
        public void WorkProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0 )
            {
                progressBar1.Maximum = 100;
                if (statusLabel != null)
                    statusLabel.Text = "";
                this.Text = FORM_TITLE;

            }
            else
            {
                if (statusLabel != null)
                    statusLabel.Text = "(" + e.ProgressPercentage + "%)";
                this.Text = String.Format(FORM_TITLE_WITH_PERCENT, e.ProgressPercentage);
            }
            
            progressBar1.Value = e.ProgressPercentage;

            this.Refresh();
        }

        public void WorkFinished()
        {
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            if (statusLabel != null)
                statusLabel.Text = "";

            this.Text = FORM_TITLE;

            this.Refresh();

            this.Close();
        }
        #endregion
    }
}