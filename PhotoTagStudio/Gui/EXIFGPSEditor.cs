#region Copyright (C) 2005-2007 Benjamin Schröter <benjamin@irgendwie.net>
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
using Schroeter.PhotoTagStudio.Features.KmzMaker;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class EXIFGPSEditor : Schroeter.PhotoTagStudio.Gui.PictureDetailControlBase
    {
        private bool askForFileSave;
        private string lastGpsFile;

        //view
        public EXIFGPSEditor() : base()
        {
            InitializeComponent();

            this.txtLatitude.Mask = GpsCoordinate.InputMask;
            this.txtLongitude.Mask = GpsCoordinate.InputMask;
        }

        //view
        protected override void ClearMyData()
        {
            this.txtLatitudeRef.Text = "";
            this.txtLongitudeRef.Text = "";
            this.txtAltitudeRef.Text = "";
            this.txtSpeedRef.Text = "";
            this.txtTrackRef.Text = "";
            this.txtImgDirectionRef.Text = "";

            this.txtLatitude.Text = "";
            this.txtLongitude.Text = "";

            this.numAltitude.Value = 0;
            this.numSpeed.Value = 0;
            this.numTrack.Value = 0;
            this.numImgDirection.Value = 0;

            this.dateGPSDate.Value = DateTime.Now;
            this.dateGPSTime.Value = DateTime.Now;

            this.updateAltitude.Checked = false;
            this.updateDateTime.Checked = false;
            this.updateImgDirection.Checked = false;
            this.updateLatitude.Checked = false;
            this.updateLongitude.Checked = false;
            this.updateSpeed.Checked = false;
            this.updateTrack.Checked = false;

            this.buttonSave.Enabled = false;
            this.buttonGetGpsData.Enabled = false;
        }
        //view
        protected override void RefreshMyData()
        {
            if (currentPicture == null)
            {
                this.ClearMyData();
                return;
            }

            this.txtLatitudeRef.Text = currentPicture.GpsLatitudeRef;
            this.txtLongitudeRef.Text = currentPicture.GpsLongitudeRef;
            this.txtAltitudeRef.Text = currentPicture.GpsAltitudeRef;
            this.txtSpeedRef.Text = currentPicture.GpsSpeedRef;
            this.txtTrackRef.Text = currentPicture.GpsTrackRef;
            this.txtImgDirectionRef.Text = currentPicture.GpsImgDirectionRef;

            if (currentPicture.GpsLatitude != null)
                this.txtLatitude.Text = currentPicture.GpsLatitude.ToString();
            else
                this.txtLatitude.Text = "";

            if (currentPicture.GpsLongitude != null)
                this.txtLongitude.Text = currentPicture.GpsLongitude.ToString();
            else
                this.txtLongitude.Text = "";

            this.numAltitude.Value = currentPicture.GpsAltitude.GetValueOrDefault();
            this.numSpeed.Value = currentPicture.GpsSpeed.GetValueOrDefault();
            this.numTrack.Value = currentPicture.GpsTrack.GetValueOrDefault();
            this.numImgDirection.Value = currentPicture.GpsImgDirection.GetValueOrDefault();

            if ( currentPicture.GpsDateTimeStamp.HasValue )
            {
                DateTime x = currentPicture.GpsDateTimeStamp.Value;
                this.dateGPSDate.Value = x;
                this.dateGPSTime.Value = x;
            }
            else
            {
                this.dateGPSDate.Value = DateTime.Now;
                this.dateGPSTime.Value = DateTime.Now;
            }
            
            this.updateAltitude.Checked = false;
            this.updateDateTime.Checked = false;
            this.updateImgDirection.Checked = false;
            this.updateLatitude.Checked = false;
            this.updateLongitude.Checked = false;
            this.updateSpeed.Checked = false;
            this.updateTrack.Checked = false;

            this.buttonSave.Enabled = true;
            this.buttonGetGpsData.Enabled = true;

            askForFileSave = true;
        }
        //model
        private bool AnythingToDo()
        {
            return updateAltitude.Checked ||
                   updateLatitude.Checked ||
                   updateLongitude.Checked ||
                   updateSpeed.Checked ||
                   updateTrack.Checked ||
                   updateImgDirection.Checked ||
                   updateDateTime.Checked;
        }
        //controller
        public override RequestFileChangeResult RequestFileChange()
        {
            if (!askForFileSave)
                return RequestFileChangeResult.Close;
            if (this.currentPicture == null)
                return RequestFileChangeResult.Close;
            if (!this.currentPicture.ExistFile)
                return RequestFileChangeResult.Close;      
            if (!AnythingToDo())
                return RequestFileChangeResult.Close;
            if (!isDataLoaded)
                return RequestFileChangeResult.Close;

            DialogResult r = MessageBox.Show("Save changes to this picture?", "GPS-Editor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (r == DialogResult.Cancel)
                return RequestFileChangeResult.DoNotClose;

            if (r == DialogResult.Yes)
            {
                MainForm f = (MainForm)this.FindForm();
                f.WaitCursor(true);
                SaveToPicture(currentPicture, false);
                f.WaitCursor(false);
                return RequestFileChangeResult.CloseAndSave;
            }

            askForFileSave = false;
            return RequestFileChangeResult.Close;
        }
        //controler
        private void buttonSave_Click(object sender, EventArgs e)
        {
            MainForm f = (MainForm)this.FindForm();
            f.WaitCursor(true);

            SaveToPicture(currentPicture, true);
            askForFileSave = false;
            FireDataChanged();

            f.WaitCursor(false);

        }
        //model
        private bool SaveToPicture(PictureMetaData pic, bool commit)
        {
            if ( this.updateLatitude.Checked )
            {
                if (this.txtLatitudeRef.Text != "")
                {
                    pic.GpsLatitudeRef = this.txtLatitudeRef.Text;
                    GpsCoordinate c = new GpsCoordinate();
                    c.FromString(this.txtLatitude.Text);
                    pic.GpsLatitude = c;
                }
                else
                {
                    pic.GpsLatitude = null;
                    pic.GpsLatitudeRef = "";
                }
            }

            if (this.updateLongitude.Checked)
            {
                if (this.txtLongitudeRef.Text != "")
                {
                    pic.GpsLongitudeRef = this.txtLongitudeRef.Text;
                    GpsCoordinate c = new GpsCoordinate();
                    c.FromString(this.txtLongitude.Text);
                    pic.GpsLongitude = c;
                }
                else
                {
                    pic.GpsLongitude = null;
                    pic.GpsLongitudeRef = "";
                }
            }

            if (this.updateAltitude.Checked)
            {
                if (this.txtAltitudeRef.Text != "")
                {
                    pic.GpsAltitudeRef = this.txtAltitudeRef.Text;
                    pic.GpsAltitude = this.numAltitude.Value;
                }
                else
                {
                    pic.GpsAltitudeRef = "";
                    pic.GpsAltitude = null;
                }
            }

            if (this.updateSpeed.Checked)
            {
                if (this.txtSpeedRef.Text != "")
                {
                    pic.GpsSpeedRef = this.txtSpeedRef.Text;
                    pic.GpsSpeed = this.numSpeed.Value;
                }
                else
                {
                    pic.GpsSpeedRef = "";
                    pic.GpsSpeed = null;                    
                }
            }

            if (this.updateTrack.Checked)
            {
                if (this.txtTrackRef.Text != "")
                {
                    pic.GpsTrackRef = this.txtTrackRef.Text;
                    pic.GpsTrack = this.numTrack.Value;
                }
                else
                {
                    pic.GpsTrackRef = "";
                    pic.GpsTrack = null;
                }
            }

            if (this.updateImgDirection.Checked)
            {
                if (this.txtImgDirectionRef.Text != "")
                {
                    pic.GpsImgDirectionRef = this.txtImgDirectionRef.Text;
                    pic.GpsImgDirection = this.numImgDirection.Value;
                }
                else
                {
                    pic.GpsImgDirectionRef = "";
                    pic.GpsImgDirection = null;
                }
            }
            
            if ( this.updateDateTime.Checked )
            {
                DateTime datePart = this.dateGPSDate.Value;
                DateTime timePart = this.dateGPSTime.Value;

                datePart = datePart.AddHours(-datePart.Hour);
                datePart = datePart.AddMinutes(-datePart.Minute);
                datePart = datePart.AddSeconds(-datePart.Second);

                datePart = datePart.AddHours(timePart.Hour);
                datePart = datePart.AddMinutes(timePart.Minute);
                datePart = datePart.AddSeconds(timePart.Second);

                pic.GpsDateTimeStamp = datePart;
            }

            if ( pic.GpsLongitude == null && pic.GpsLatitude == null && !pic.GpsAltitude.HasValue && !pic.GpsSpeed.HasValue && !pic.GpsTrack.HasValue && !pic.GpsImgDirection.HasValue )
            {
                pic.GpsDateTimeStamp = null;
                pic.GpsVersionIdRemove();
            }
            else
                pic.GpsVersioIdInit();
            
            if (commit)
                if (!pic.SaveChanges())
                    return this.ShowFileVanishedMsg(pic.Filename);

            return true;
        }
        //view
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

            this.updateSpeed.Checked = true;
        }

        //model
        #region set update checkboxes 
        private void txtLatitude_TextChanged(object sender, EventArgs e)
        {
            this.updateLatitude.Checked = true;
        }

        private void txtLongitude_TextChanged(object sender, EventArgs e)
        {
            this.updateLongitude.Checked = true;
        }

        private void numAltitude_ValueChanged(object sender, EventArgs e)
        {
            this.updateAltitude.Checked = true;
        }

        private void numSpeed_ValueChanged(object sender, EventArgs e)
        {
            this.updateSpeed.Checked = true;
        }

        private void numTrack_ValueChanged(object sender, EventArgs e)
        {
            this.updateTrack.Checked = true;
        }

        private void numImgDirection_ValueChanged(object sender, EventArgs e)
        {
            this.updateImgDirection.Checked = true;
        }

        private void dateGPSDate_ValueChanged(object sender, EventArgs e)
        {
            this.updateDateTime.Checked = true;
        }
        #endregion

        private void buttonKmzMaker_Click(object sender, EventArgs e)
        {
            KmzMakerForm f = new KmzMakerForm(currentPicture, currentDirectory, new GetAllFilesDelegate(this.GetAllFileList));
            f.GpsRouteFile = lastGpsFile;
            if (f.ShowDialog(this) == DialogResult.OK)
                if (f.GpsRouteFile != "")
                    lastGpsFile = f.GpsRouteFile;
        }
        private void buttonGetGpsData_Click(object sender, EventArgs e)
        {
            // a picture is need for the offset dialog
            if (this.currentPicture == null)
                return;
            
            // the filename of the gps log
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open gps nmea file";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog(this) != DialogResult.OK)
                return;

            this.lastGpsFile = ofd.FileName;
            
            // read the gps log
            GpsLog log = GpsLogFactory.FromFile(ofd.FileName);

            // empty log -> exit
            if (log.Count == 0)
                return;
            
            // ask for gps time offset
            PictureGpsOffsetDialog d = new PictureGpsOffsetDialog(currentPicture, log.FirstTime.Value, log.LastTime.Value);
            d.Offset = Settings.Default.GPSTimeOffset;
            if (d.ShowDialog(this) != DialogResult.OK)
                return;
            
            // set offset to gps log
            Settings.Default.GPSTimeOffset = d.Offset;
            log.Offset = d.Offset;

            IStatusDisplay statusDisplay = (IStatusDisplay)this.FindForm();
            
            List<string> filenames = this.GetAllFileList(false);
            statusDisplay.WorkStart( filenames.Count );

            // compute the timespan of all pictures
            DateTime firstPicture = new DateTime(4000, 1, 1);
            DateTime lastPicture = new DateTime(1,1,1);
            List<PictureMetaData> pictures = new List<PictureMetaData>();
            foreach (string filename in filenames)
            {
                PictureMetaData pmd;
                if (this.currentPicture != null
                    && this.currentPicture.Filename == filename)
                    pmd = currentPicture;
                else
                    pmd = new PictureMetaData(filename);

                if ( pmd.ExifOriginalDateTime.HasValue )
                {
                    DateTime time = pmd.ExifOriginalDateTime.Value;
                    
                    if (time > lastPicture)
                        lastPicture = time;
                    if (time < firstPicture)
                        firstPicture = time;

                    pictures.Add(pmd);
                }
                statusDisplay.WorkNextPart();
            }
            statusDisplay.WorkFinished();
            
            // ask the user: do it now?
            string text =
                String.Format(
                    "The GPS time is between {0} and {1}.\nThe picture time is between {2} and {3} ({4} and {5}).\n\nContinue?",
                    log.FirstTime,
                    log.LastTime,
                    firstPicture.Add(log.Offset),
                    lastPicture.Add(log.Offset),
                    firstPicture, 
                    lastPicture);
            if ( MessageBox.Show(text, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes )
            {
                statusDisplay.WorkStart(pictures.Count);
                foreach (PictureMetaData pmd in pictures)
                {
                    UpdateGpsData(pmd, log);

                    if (pmd != currentPicture)
                        pmd.Close();
                    statusDisplay.WorkNextPart();
                }
                    
                FireDataChanged();
                statusDisplay.WorkFinished();
            }   
            else
            {
                foreach (PictureMetaData pmd in pictures)
                    if (pmd != currentPicture)
                        pmd.Close();
            }
        }
        private void UpdateGpsData(PictureMetaData picture, GpsLog log)
        {
            if (picture.ExifOriginalDateTime.HasValue)
            {
                GpsLogEntry entry = log.GetNearestEntry(picture.ExifOriginalDateTime.Value);
                if (entry != null)
                {
                    picture.GpsLatitude = new GpsCoordinate(entry.Latitude);
                    picture.GpsLongitude = new GpsCoordinate(entry.Longitude);
                    picture.GpsLatitudeRef = entry.Latitude >= 0 ? "N" : "S";
                    picture.GpsLongitudeRef = entry.Longitude >= 0 ? "E" : "W";
                    picture.GpsDateTimeStamp = entry.Time;
                    
                    picture.SaveChanges();
                }
            }
        }
        
        
        //controller
        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            IStatusDisplay statusDisplay = (IStatusDisplay)this.FindForm();
            List<string> filenames = this.GetAllFileList(this.chkSubdirs.Checked);

            PauseOtherWorker();

            statusDisplay.WorkStart(filenames.Count);

            foreach (string filename in filenames)
            {
                PictureMetaData pmd;
                if (this.currentPicture != null
                    && this.currentPicture.Filename == filename)
                    pmd = currentPicture;
                else
                {
                    if (File.Exists(filename))
                        pmd = new PictureMetaData(filename);
                    else
                        continue;
                }

                bool breakForeach = SaveToPicture(pmd, true) == false;

                if (pmd != currentPicture)
                    pmd.Close();

                if (breakForeach)
                    break;

                statusDisplay.WorkNextPart();
            }

            FireDataChanged();

            statusDisplay.WorkFinished();

            RestartOtherWorker();
        }
    }
}