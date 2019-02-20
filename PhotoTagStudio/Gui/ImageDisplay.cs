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

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class ImageDisplay : PictureDetailControlBase
    {
        public ImageDisplay()
            : base()
        {
            InitializeComponent();
        }

        protected override void ClearMyData()
        {
            this.listView1.Items.Clear();
        }

        protected override void RefreshMyData()
        {
            if (this.currentPicture == null)
            {
                ClearData();
                return;
            }

            this.listView1.BeginUpdate();

            this.listView1.Items.Clear();

            AddToList("Filename", this.currentPicture.Filename);
            AddToList("Height", this.currentPicture.Size.Height.ToString());
            AddToList("Width", this.currentPicture.Size.Width.ToString());
            AddToList("Horizontal resolution", this.currentPicture.HorizontalResolution.ToString() + " dpi");
            AddToList("Vertical resolution", this.currentPicture.VerticalResolution.ToString() + " dpi");
            AddToList("Filesize", FormatSize( this.currentPicture.Filesize, 1 ));

            this.listView1.EndUpdate();
        }

        private void AddToList(string name, string val)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = name;
            lvi.SubItems.Add( val );

            this.listView1.Items.Add(lvi);
        }

        public string FormatSize(long amt, int rounding)
        {
            if (amt >= Math.Pow(2, 80)) return Math.Round(amt / Math.Pow(2, 80), rounding).ToString() + " YB"; //yettabyte
            if (amt >= Math.Pow(2, 70)) return Math.Round(amt / Math.Pow(2, 70), rounding).ToString() + " ZB"; //zettabyte
            if (amt >= Math.Pow(2, 60)) return Math.Round(amt / Math.Pow(2, 60), rounding).ToString() + " EB"; //exabyte
            if (amt >= Math.Pow(2, 50)) return Math.Round(amt / Math.Pow(2, 50), rounding).ToString() + " PB"; //petabyte
            if (amt >= Math.Pow(2, 40)) return Math.Round(amt / Math.Pow(2, 40), rounding).ToString() + " TB"; //terabyte
            if (amt >= Math.Pow(2, 30)) return Math.Round(amt / Math.Pow(2, 30), rounding).ToString() + " GB"; //gigabyte
            if (amt >= Math.Pow(2, 20)) return Math.Round(amt / Math.Pow(2, 20), rounding).ToString() + " MB"; //megabyte
            if (amt >= Math.Pow(2, 10)) return Math.Round(amt / Math.Pow(2, 10), rounding).ToString() + " KB"; //kilobyte

            return amt.ToString() + " Bytes"; //byte
        }    
   }
}