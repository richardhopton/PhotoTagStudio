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
using System.Drawing;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class PictureDisplay : PictureDetailControlBase
    {
        private bool dataChanged = false;
        private bool wasResized = false;
        private ThumbnailCache thumbnails;

        private bool rotatePreview;
        private bool thumbnailsCacheActive;
                
        public PictureDisplay(  )
            : base()
        {
            InitializeComponent();

            this.thumbnailsCacheActive = Settings.Default.LoadThumbnailsInBackground;
            this.rotatePreview = Settings.Default.RotatePreview;

            this.thumbnails = new ThumbnailCache();

            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LoadThumbnailsInBackground")
            {
                if (this.thumbnailsCacheActive == Settings.Default.LoadThumbnailsInBackground)
                    return;

                this.thumbnailsCacheActive = Settings.Default.LoadThumbnailsInBackground;
                
                if ( !this.thumbnailsCacheActive )
                {
                    thumbnails.Cancel();
                    thumbnails.Clear();
                }
                else
                {
                    thumbnails.ReCreateAllThumbnails();
                }
            }

            if (e.PropertyName == "RotatePreview")
                rotatePreview = Settings.Default.RotatePreview;
        }

        public void SetStatusDisplay(IStatusDisplay statusDisplay)
        {
            thumbnails.SetStatusDisplay(statusDisplay);
        }
        
        protected override void ClearMyData()
        {
            this.pictureBox1.Image = null;
            this.dataChanged = false; 
        }

        protected override void RefreshMyData()
        {
            if (this.currentPicture == null)
            {
                ClearData();
                return;
            }

            if ( this.wasResized )
            {
                this.wasResized = false;
                if ( thumbnailsCacheActive )
                    thumbnails.CreateAllThumbnails();
            }
            
            DisplayPicture();
            this.dataChanged = false; 
        }

        public override void UpdateDirectory(string path)
        {
            base.UpdateDirectory(path);
            
            wasResized = false;
            if (thumbnailsCacheActive)
                thumbnails.CreateAllThumbnails(currentDirectory);
            else
                thumbnails.CurrentPath = currentDirectory;
        }
        
        public void ReCreateAllThumbnails()
        {
            if (thumbnailsCacheActive)
                thumbnails.ReCreateAllThumbnails();
        }

        private void DisplayPicture()
        {
            if ( thumbnailsCacheActive )
                thumbnails.GetThumbnail(currentPicture.Filename, this.ShowThumbnail);
            else
            {
                Image i = currentPicture.Image;
                ShowThumbnail(currentPicture.Filename,i);
            }
        }

        private void ShowThumbnail(string name, Image thumbnail)
        {
            if ( currentPicture.Filename == name )
            {
                this.pictureBox1.Image = thumbnail;

                if (rotatePreview && thumbnailsCacheActive)
                {
                    RotateFlipType flip = currentPicture.GetRotationFlipTypeFromExif();
                    if (flip != RotateFlipType.RotateNoneFlipNone)
                    {
                        Image i = (Image)thumbnail.Clone();
                        this.pictureBox1.Image = i;
                        this.pictureBox1.Image.RotateFlip(flip); 
                    }
                }
            }
        }

        public void DisplayPicture(PictureMetaData picture)
        {
            this.pictureBox1.Image = picture.Image;
            this.toolStrip1.Visible = false;
        }

        #region rotation
        private void RotateLeft(object sender, EventArgs e)
        {
            if ( this.pictureBox1.Image == null )
                return;

            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.pictureBox1.Refresh();

            this.currentPicture.ExifImageOrientation = getNextOrientation(this.currentPicture.ExifImageOrientation, false);
            this.dataChanged = true;
        }
        private void RotateRight(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image == null)
                return;

            this.pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pictureBox1.Refresh();

            this.currentPicture.ExifImageOrientation = getNextOrientation(this.currentPicture.ExifImageOrientation, true);
            this.dataChanged = true; 
        }
        private static readonly int[] exifOrientations = { 1, 6, 3, 8, 1, 0, 2, 7, 4, 5, 2 };
        private static int getNextOrientation(int currentOrientation, bool right)
        {
            int pos = -100;

            if (right)
            {
                for (int i = 0; i < exifOrientations.Length; i++)
                    if (exifOrientations[i] == currentOrientation)
                    {
                        pos = i;
                        break;
                    }

                pos++;
            }
            else
            {
                for (int i = exifOrientations.Length - 1; i >= 0; i--)
                    if (exifOrientations[i] == currentOrientation)
                    {
                        pos = i;
                        break;
                    }

                pos--;
            }

            if (pos > 0)
                return exifOrientations[pos];
            else
                return 1;
        }
        #endregion

        #region navigation and delete
        private void DeletePicture(object sender, EventArgs e)
        {
            FireNavigateFiles(NavigateFileOperation.Delete);
        }

        private void NextPicture(object sender, EventArgs e)
        {
            FireNavigateFiles(NavigateFileOperation.Next);           
        }

        private void PrevPicture(object sender, EventArgs e)
        {
            FireNavigateFiles(NavigateFileOperation.Previous);
        }
        #endregion

        public override RequestFileChangeResult RequestFileChange()
        {
            if ( this.currentPicture != null && this.dataChanged)
                return RequestFileChangeResult.CloseAndSave;
            else
                return RequestFileChangeResult.Close;
        }
        
        public bool StopAllWork()
        {
            return thumbnails.Cancel();
        }

        private void toolStrip1_Resize(object sender, EventArgs e)
        {
            Padding p = this.toolStrip1.Padding;
            p.Left = (this.toolStrip1.Width - this.toolStripButton1.Width*3 - 4) / 2;
            this.toolStrip1.Padding = p;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.currentPicture != null)
            {
                if (this.currentPicture.SaveChanges())
                {
                    this.dataChanged = false;
                    System.Diagnostics.Process.Start(this.currentPicture.Filename);
                }
                else
                    this.ShowFileVanishedMsg(this.currentPicture.Filename);
            }
        }

        private void PictureDisplay_Resize(object sender, EventArgs e)
        {
            thumbnails.ThumbnailSize = this.pictureBox1.Size;
            wasResized = true;
            if (currentPicture != null)
                DisplayPicture();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
    }
}