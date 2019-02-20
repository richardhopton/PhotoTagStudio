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
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Gui;

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    public partial class CopyMoveForm : FormWithStatusDisplay
    {
        public CopyMoveForm()
        {
            InitializeComponent();

            this.copyMoveView1.PreInit();
        }

        private void btnCopyRename_Click(object sender, EventArgs e)
        {
            this.btnCopyRename.Enabled = false;
            this.btnClose.Enabled = false;

            CopyMoveController c = new CopyMoveController(this.copyMoveView1.GetModel(),this);
            
            bool result = c.Work();

            if (result)
            {
                this.DialogResult = DialogResult.OK;
                this.copyMoveView1.SaveLastModel();
                this.Close();
            }

            this.btnCopyRename.Enabled = true;
            this.btnClose.Enabled = true;
        }
    }
}