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

using System.Windows.Forms;
using Schroeter.Photo;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class ExifDisplay : PictureDetailControlBase
    {
        public ExifDisplay()
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

            AddExifImageTags();

            AddExifPhotoTags();

            this.listView1.EndUpdate();
        }

        private void AddExifPhotoTags()
        {
            AddToList(Exif.Photo.EXPOSURETIME);
            AddToList(Exif.Photo.FNUMBER);
            AddToList(Exif.Photo.EXPOSUREPROGRAM);
            AddToList(Exif.Photo.ISOSPEEDRATINGS);
            AddToList(Exif.Photo.DATETIMEORIGINAL);
            AddToList(Exif.Photo.DATETIMEDIGITIZED);
            AddToList(Exif.Photo.COMPONENTSCONFIGURATION);
            AddToList(Exif.Photo.COMPRESSEDBITSPERPIXEL);
            AddToList(Exif.Photo.BRIGHTNESSVALUE);
            AddToList(Exif.Photo.EXPOSUREBIASVALUE);
            AddToList(Exif.Photo.MAXAPERTUREVALUE);
            AddToList(Exif.Photo.METERINGMODE);
            AddToList(Exif.Photo.LIGHTSOURCE);
            AddToList(Exif.Photo.FLASH);
            AddToList(Exif.Photo.FOCALLENGTH);
            AddToList(Exif.Photo.COLORSPACE);
            AddToList(Exif.Photo.PIXELXDIMENSION);
            AddToList(Exif.Photo.PIXELYDIMENSION);
            AddToList(Exif.Photo.SCENETYPE);
            AddToList(Exif.Photo.SUBJECTAREA);
            AddToList(Exif.Photo.CUSTOMRENDERED);
            AddToList(Exif.Photo.EXPOSUREMODE);
            AddToList(Exif.Photo.WHITEBALANCE);
            AddToList(Exif.Photo.DIGITALZOOMRATIO);
            AddToList(Exif.Photo.FOCALLENGTHIN35MMFILM);
            AddToList(Exif.Photo.SCENECAPTURETYPE);
            AddToList(Exif.Photo.GAINCONTROL);
            AddToList(Exif.Photo.CONTRAST);
            AddToList(Exif.Photo.SATURATION);
            AddToList(Exif.Photo.SHARPNESS);
            AddToList(Exif.Photo.SUBJECTDISTANCERANGE);
        }

        private void AddExifImageTags()
        {
            AddToList(Exif.Image.MAKE);
            AddToList(Exif.Image.MODEL);
            AddToList(Exif.Image.ORIENTATION);
            AddToList(Exif.Image.XRESOLUTION);
            AddToList(Exif.Image.YRESOLUTION);
            AddToList(Exif.Image.RESOLUTIONUNIT);
            AddToList(Exif.Image.SOFTWARE);
            AddToList(Exif.Image.DATETIME);
            AddToList(Exif.Image.YCBCRPOSITIONING);            
            AddToList(Exif.Image.IMAGEDESCRIPTION);
        }

        private void AddToList(string tag)
        {
            TagDescription td = Const.GetTagDescription(tag);

            ListViewItem lvi = new ListViewItem();

            if (td != null)
            {
                // formated
                lvi.Text = td.Description;
                lvi.SubItems.Add(this.currentPicture[td]);
            }
            else
            {
                // unformated
                lvi.Text = tag;
                lvi.SubItems.Add(this.currentPicture[tag]);
            }
            
            this.listView1.Items.Add(lvi);
        }
   }
}