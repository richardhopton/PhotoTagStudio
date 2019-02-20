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
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    public partial class LocationListEditor : UserControl
    {
        private LocationList value;

        public LocationListEditor()
        {
            InitializeComponent();
        }

        public LocationList Value
        {
            get
            { 
                return this.value; 
            }
            set
            {
                this.value = value;
                if (value != null)
                {
                    UpdateListView();
                    this.checkBox1.Checked = this.value.CanGrow;
                }
                else
                {
                    this.listView1.Items.Clear();
                    this.checkBox1.Checked = false;
                }
            }
        }

        private void UpdateListView()
        {
            this.listView1.BeginUpdate();

            this.listView1.Items.Clear();

            foreach (Location l in this.value.Data)
                AddLocationToList(l);

            this.listView1.EndUpdate();
        }

        private void AddLocationToList(Location l)
        {
            ListViewItem lvi = new ListViewItem(l.City);
            lvi.SubItems.Add(l.Sublocation);
            lvi.SubItems.Add(l.State);
            lvi.SubItems.Add(l.CountryName);
            lvi.SubItems.Add(l.CountryCode);
            lvi.Tag = l;
            this.listView1.Items.Add(lvi);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.value.CanGrow = this.checkBox1.Checked;
        }

        private void textCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.textSublocation.Focus();
        }

        private void textSublocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.textState.Focus();
        }

        private void textState_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.textCountryName.Focus();           
        }

        private void textCountryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                this.textCountryCode.Focus();
        }

        private void textCountryCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Location l = new Location();
                l.City = this.textCity.Text;
                l.CountryCode = this.textCountryCode.Text;
                l.CountryName = this.textCountryName.Text;
                l.State = this.textState.Text;
                l.Sublocation = this.textSublocation.Text;

                if (this.value.Add(l)) 
                    AddLocationToList(l);

                this.textCity.Text = "";
                this.textCountryCode.Text = "";
                this.textCountryName.Text = "";
                this.textState.Text = "";
                this.textSublocation.Text = "";
                
                this.textCity.Focus();
            }

        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
                if ( this.listView1.SelectedItems.Count > 0 )
                {
                    Location l = (Location)this.listView1.SelectedItems[0].Tag;

                    this.value.Data.Remove(l);

                    this.listView1.SelectedItems[0].Remove();
                }
        }

        //private void listBox1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyValue == 46)
        //    {
        //        string s = (string) this.listBox1.SelectedItem;

        //        if (s != null)
        //        {
        //            this.value.Data.Remove(s);

        //            this.listBox1.DataSource = null;
        //            this.listBox1.DataSource = this.value.Data;
        //        }
        //    }
        //}

    }
}