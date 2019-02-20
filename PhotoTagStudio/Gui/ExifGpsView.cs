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
using System.IO;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Features.KmzMaker;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class ExifGpsView : PresetableViewForExifGpsModel
    {
        public event EventHandler CreateKmzClick;
        public event EventHandler TagFromGpsLogClick;

        public ExifGpsView()
            : base()
        {
            InitializeComponent();

            this.txtLatitude.Mask = GpsCoordinate.InputMask;
            this.txtLongitude.Mask = GpsCoordinate.InputMask;

            this.nullableDateTimePicker1.CustomFormat = GuiUtils.GetShortDateLongTimeFormatPattern();

            this.txtLatitude.DataBindings[0].Format += new ConvertEventHandler(ExifGpsView_Format);
            this.txtLatitude.DataBindings[0].Parse += new ConvertEventHandler(ExifGpsView_Parse);
            this.txtLongitude.DataBindings[0].Format += new ConvertEventHandler(ExifGpsView_Format);
            this.txtLongitude.DataBindings[0].Parse += new ConvertEventHandler(ExifGpsView_Parse);
        }

        public override void PreInit()
        {
            this.buttonGetGpsData.Visible = !this.RunningInMacroMode;
            this.buttonKmzMaker.Visible = !this.RunningInMacroMode;
        }

        private void ExifGpsView_Parse(object sender, ConvertEventArgs e)
        {
            GpsCoordinate c = new GpsCoordinate();
            c.FromString(e.Value.ToString());
            e.Value = c;
        }

        private void ExifGpsView_Format(object sender, ConvertEventArgs e)
        {
            GpsCoordinate c = e.Value as GpsCoordinate;
            if (c != null)
                e.Value = c.ToString();
            else
                e.Value = "";
        }

        public override void SetModel(ExifGpsModel m)
        {
            base.SetModel(m);

            this.bindingSource.DataSource = this.model;
        }
              
        private void txtSpeedRef_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch( this.txtSpeedRef.Text )
            {
                case "K":
                    this.labSpeedUnit.Text = "km/h";
                    break;
                case "M":
                    this.labSpeedUnit.Text = "miles/h";
                    break;
                case "N":
                    this.labSpeedUnit.Text = "knots";
                    break;
            }
        }

        private void buttonKmzMaker_Click(object sender, EventArgs e)
        {
            if (CreateKmzClick != null)
                CreateKmzClick(sender, e);
        }

        private void buttonGetGpsData_Click(object sender, EventArgs e)
        {
            if (TagFromGpsLogClick != null)
                TagFromGpsLogClick(sender, e);
        }

        #region workaround for the vs2005 designer
        // the form designer didn't like it to call eventhandlers in the base classes
        protected override void txt_KeyDown(object sender, KeyEventArgs e)
        {
            base.txt_KeyDown(sender, e);
        }

        protected override void txt_KeyUp(object sender, KeyEventArgs e)
        {
            base.txt_KeyUp(sender, e);
        }
        #endregion
    }

    // workaround, the visual studio (2005 and orcas beta 2) cannot design 
    // a control deriverd from PresetableView<ExifGpsModel> :-(
    // but PresetableViewForExifGpsModel is fine :-)
    public class PresetableViewForExifGpsModel : KeyboardInteractionPresetableView<ExifGpsModel>
    {
    }
}