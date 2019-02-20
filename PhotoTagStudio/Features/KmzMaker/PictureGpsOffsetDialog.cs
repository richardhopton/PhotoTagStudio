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
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Features.KmzMaker
{
    public partial class PictureGpsOffsetDialog : Form
    {
        private bool dontUpdate = false;

        public PictureGpsOffsetDialog(PictureMetaData picture, DateTime firstTime, DateTime lastTime)
        {
            InitializeComponent();

            this.Icon = Resources.PTS;

            if ( picture != null)
            {
                this.pictureDisplay1.DisplayPicture(picture);
                this.timeExif.Value = picture.ExifOriginalDateTime.GetValueOrDefault();
                this.timeGps.Value = this.timeExif.Value;
                this.textBox1.Visible = false;
            }
            else
            {
                this.timeExif.Enabled = this.timeGps.Enabled = false;
                dontUpdate = true;

                this.textBox1.Visible = true;
                this.pictureDisplay1.Visible = false;
                //TODO: text ausgeben
            }

            this.labGpsLogInfo.Text = string.Format(this.labGpsLogInfo.Text, firstTime, lastTime);
        }

        private void timeOffset_ValueChanged(object sender, EventArgs e)
        {
            if (dontUpdate)
                return;
            dontUpdate = true; 
            
            if (this.radPlus.Checked)
                this.timeGps.Value = this.timeExif.Value.Add(this.timeOffset.Value.TimeOfDay);
            else
                this.timeGps.Value = this.timeExif.Value.Subtract(this.timeOffset.Value.TimeOfDay);

            dontUpdate = false;
        }

        private void timeGps_ValueChanged(object sender, EventArgs e)
        {
            if (dontUpdate)
                return;
            dontUpdate = true;
            
            TimeSpan diff = this.timeGps.Value.TimeOfDay.Subtract(this.timeExif.Value.TimeOfDay);

            this.timeOffset.Value = new DateTime(Math.Abs(diff.Ticks)).AddYears(2000);

            if (diff.Ticks >= 0)
                this.radPlus.Checked = true;
            else
                this.radMinus.Checked = true;

            dontUpdate = false;
        }
        
        public TimeSpan Offset
        {
            get
            {
                if (this.radMinus.Checked)
                    return this.timeOffset.Value.TimeOfDay.Negate();
                else
                    return this.timeOffset.Value.TimeOfDay;
            }
            set
            {

                DateTime x = new DateTime(2001, 1, 1);
                if (value.Ticks >= 0)
                    x = x.Add(value);
                else
                    x = x.Add(value.Negate());

                this.timeOffset.Value = x;
                this.radMinus.Checked = (value.Ticks < 0);
            }
        }
    }
}