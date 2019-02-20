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
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui.Setting
{
    public partial class KmzAndGps : UserControl
    {
        public KmzAndGps()
        {
            InitializeComponent();
        }

        private void KmzAndGps_Load(object sender, EventArgs e)
        {
            this.numHeading.Value = Settings.Default.KmzHeading;
            this.numTilt.Value = Settings.Default.KmzTilt;
            this.numRange.Value = Settings.Default.KmzRange;
            this.numPicSize.Value = Settings.Default.KmzPictureSize;
            this.numLineWidth.Value = Settings.Default.KmzLineWidth;
            this.panel1.BackColor = Settings.Default.KmzLineColor;
        }

        private void numRange_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.KmzRange = (int) this.numRange.Value;
        }

        private void numTilt_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.KmzTilt = (int) this.numTilt.Value;
        }

        private void numHeading_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.KmzHeading = (int) this.numHeading.Value;
        }

        private void numPicSize_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.KmzPictureSize = (int) this.numPicSize.Value;
        }

        private void numLineWidth_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.KmzLineWidth = (int) this.numLineWidth.Value;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            d.Color = this.panel1.BackColor;
            if (d.ShowDialog(this.FindForm()) == DialogResult.OK)
            {
                this.panel1.BackColor = d.Color;
                Settings.Default.KmzLineColor = d.Color;
            }
        }
    }
}

