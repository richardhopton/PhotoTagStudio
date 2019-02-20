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
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    public partial class VisibleTabs : UserControl
    {
        public VisibleTabs()
        {
            InitializeComponent();            
        }
        public VisibleTabs(MainForm mainform) : this()
        {
            if (mainform == null)
                return;

            foreach (TabPage page in mainform.tabControl.AllTabPages)
                this.listBox.Items.Add(page.Text);

            foreach (string tab in Properties.Settings.Default.VisibleTabs)
            {
                int i = this.listBox.Items.IndexOf(tab);
                if ( i != -1 )
                    this.listBox.SetItemChecked(i,true);
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( this.listBox.CheckedItems.Count == 0)
                this.listBox.SetItemChecked(0, true);

            StringCollection col = new StringCollection();
            foreach (string o in this.listBox.CheckedItems)
                col.Add(o);
            
            Properties.Settings.Default.VisibleTabs = col;
        }
    }
}
