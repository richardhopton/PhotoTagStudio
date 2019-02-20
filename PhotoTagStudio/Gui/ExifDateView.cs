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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class ExifDateView : PresetableViewForExifDateModel
    {
        public event EventHandler SelectionChanged;

        public ExifDateView()
        {
            InitializeComponent();

            this.customDateTime.CustomFormat = GuiUtils.GetShortDateLongTimeFormatPattern();

            AddItemToSourceList(this.listSource, "EXIF camera", ExifDateFields.ExifImageDateTime);
            AddItemToSourceList(this.listSource, "EXIF original created", ExifDateFields.ExifPhotoDateTimeOriginal);
            AddItemToSourceList(this.listSource, "EXIF digitized", ExifDateFields.ExifPhotoDateTimeDigitized);
            AddItemToSourceList(this.listSource, "IPTC created", ExifDateFields.IptcCreated);
            AddItemToSourceList(this.listSource, "User", ExifDateFields.None);
            this.listSource.SelectedIndices.Add(0);

            AddItemToSourceList(this.listTarget, "EXIF camera", ExifDateFields.ExifImageDateTime);
            AddItemToSourceList(this.listTarget, "EXIF original created", ExifDateFields.ExifPhotoDateTimeOriginal);
            AddItemToSourceList(this.listTarget, "EXIF digitized", ExifDateFields.ExifPhotoDateTimeDigitized);
            AddItemToSourceList(this.listTarget, "IPTC created", ExifDateFields.IptcCreated);

            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);
            HighlightlickrNames();
        }

        private static void AddItemToSourceList(ListView list, string text, ExifDateFields value)
        {
            ListViewItem lvi = new ListViewItem(text);
            lvi.Tag = value;
            list.Items.Add(lvi);
        }

        public override void SetModel(ExifDateModel m)
        {
            base.SetModel(m);

            this.bindingSource.DataSource = this.model;
        }

        private void listSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( this.listSource.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = this.listSource.SelectedItems[0];
            ExifDateFields selectedField = (ExifDateFields) lvi.Tag;

            this.model.SourceField = selectedField;

            this.customDateTime.Visible = selectedField == ExifDateFields.None;
            if (selectedField == ExifDateFields.None)
            {
                model.Offset = new TimeSpan(0);
                Offset_Changed();
            }
            this.radMinus.Enabled = this.radPlus.Enabled = this.timeOffset.Enabled = this.offsetDays.Enabled = this.label4.Enabled = selectedField != ExifDateFields.None;

            FireSelectionChanged();
        }
        private void listTarget_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ExifDateFields all = ExifDateFields.None;

            foreach (ListViewItem lvi in this.listTarget.Items)
                if ( lvi.Checked )
                {
                    ExifDateFields field = (ExifDateFields)lvi.Tag;
                    all |= field;
                }

            this.model.TargetFields = all;
        }
        private void timeOffset_ValueChanged(object sender, EventArgs e)
        {
            if (this.radMinus.Checked)
            {
                TimeSpan span = this.timeOffset.Value.TimeOfDay.Negate();
                span = span.Subtract(new TimeSpan((int) this.offsetDays.Value, 0, 0, 0));
                this.model.Offset = span;
            }
            else
            {
                TimeSpan span = this.timeOffset.Value.TimeOfDay;
                span = span.Add(new TimeSpan((int)this.offsetDays.Value, 0, 0, 0));
                this.model.Offset = span;
            }

            FireSelectionChanged();
        }

        private void bindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            // list source
            this.listSource.SelectedItems.Clear();
            foreach (ListViewItem lvi in this.listSource.Items)
                if (this.model.SourceField == (ExifDateFields) lvi.Tag)
                {
                    lvi.Selected = true;
                    break;
                }

            // list target
            ExifDateFields targetFields = this.model.TargetFields;
            foreach (ListViewItem lvi in this.listTarget.Items)
            {
                ExifDateFields field = (ExifDateFields) lvi.Tag;
                lvi.Checked = ((targetFields & field) == field);
            }

            // offset
            Offset_Changed();
        }

        private void Offset_Changed()
        {
            DateTime x = new DateTime(2001, 1, 1);
            TimeSpan offset = this.model.Offset;
            if (offset.Ticks >= 0)
                x = x.Add(offset);
            else
                x = x.Add(offset.Negate());
            this.timeOffset.Value = x;

            this.offsetDays.Value = Math.Abs(offset.Days);

            this.radMinus.Checked = (offset.Ticks < 0);
            this.radPlus.Checked = !this.radMinus.Checked;
        }

        #region highlight flickr names
        private void HighlightlickrNames()
        {
            bool doHighlight = Settings.Default.DisplayIPTCTagsWithFlickrNames;

            foreach (ListViewItem lvi in this.listSource.Items)
                if ( lvi.Tag is ExifDateFields && (((ExifDateFields)lvi.Tag) & ExifDateFields.FlickrDateTime) >0 )
                    lvi.Font = new Font(lvi.Font, doHighlight?FontStyle.Bold : FontStyle.Regular );

            foreach (ListViewItem lvi in this.listTarget.Items)
                if (lvi.Tag is ExifDateFields && (((ExifDateFields)lvi.Tag) & ExifDateFields.FlickrDateTime) > 0)
                    lvi.Font = new Font(lvi.Font, doHighlight ? FontStyle.Bold : FontStyle.Regular);
        }

        private void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            HighlightlickrNames();
        }
        #endregion

        #region events
        private void FireSelectionChanged()
        {
            if (SelectionChanged != null)
                SelectionChanged(this, new EventArgs());
        }
        #endregion
    }

    // workaround, the visual studio (2005 and orcas beta 2) cannot design 
    // a control deriverd from PresetableView<CopyMoveModel> :-(
    // but PresetableViewForCopyMoveModel is fine :-)
    public class PresetableViewForExifDateModel : KeyboardInteractionPresetableView<ExifDateModel>
    {
    }
}
