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
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Schroeter.Windows.Forms
{
    public class ListViewHoldSelection : ListView
    {
        protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e)
        {
            e.Item.BackColor = SystemColors.ControlLightLight;
            e.Item.ForeColor = SystemColors.ControlText;

            if (e.Item.Selected)
            {
                e.Item.BackColor = SystemColors.ControlDark;
                e.Item.ForeColor = SystemColors.HighlightText;
            }
            
            base.OnItemSelectionChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            foreach (ListViewItem lvi in this.Items)
            {
                lvi.BackColor = SystemColors.ControlLightLight;
                lvi.ForeColor = SystemColors.ControlText;
            }

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            foreach (ListViewItem lvi in this.Items)
                if (lvi.Selected)
                {
                    lvi.BackColor = SystemColors.ControlDark;
                    lvi.ForeColor = SystemColors.HighlightText;
                }

            base.OnLostFocus(e);
        }
    }
}
