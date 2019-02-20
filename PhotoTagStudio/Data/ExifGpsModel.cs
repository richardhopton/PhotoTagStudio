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
using System.Text;
using System.Xml.Serialization;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Data
{
    [MacroEnabled("GPS",typeof(ExifGpsView), typeof(ExifGpsWorker))]
    public class ExifGpsModel : ModelBase
    {
        private string latitudeRef = "";
        private GpsCoordinate latitude = null;
        private string longitudeRef = "";
        private GpsCoordinate longitude = null;
        private string altitudeRef = "";
        private decimal altitude = 0;
        private string speedRef = "";
        private decimal speed = 0;
        private string trackRef = "";
        private decimal track = 0;
        private string imageDirectionRef = "";
        private decimal imageDirection = 0;

        private DateTime date = DateTime.MinValue;

        private bool latitudeChecked = false;
        private bool longitudeChecked = false;
        private bool altitudeChecked = false;
        private bool speedChecked = false;
        private bool trackChecked = false;
        private bool imageDirectionChecked = false;
        private bool dateChecked = false;

        public ExifGpsModel()
        {
        }

        public ExifGpsModel(PictureMetaData pmd)
        {
            if (pmd == null)
                return;

            this.latitudeRef = Util.unNull(pmd.GpsLatitudeRef);
            this.longitudeRef = Util.unNull(pmd.GpsLongitudeRef);
            this.altitudeRef = Util.unNull(pmd.GpsAltitudeRef);
            this.speedRef = Util.unNull(pmd.GpsSpeedRef);
            this.trackRef = Util.unNull(pmd.GpsTrackRef);
            this.imageDirectionRef = Util.unNull(pmd.GpsImgDirectionRef);

            this.latitude = pmd.GpsLatitude;
            this.longitude = pmd.GpsLongitude;
            this.altitude = pmd.GpsAltitude.GetValueOrDefault();
            this.speed = pmd.GpsSpeed.GetValueOrDefault();
            this.track = pmd.GpsTrack.GetValueOrDefault();
            this.imageDirection = pmd.GpsImgDirection.GetValueOrDefault();

            if (pmd.GpsDateTimeStamp.HasValue)
                this.date = pmd.GpsDateTimeStamp.Value;
            else
                this.date = DateTime.MinValue;
        }

        #region Properties

        public string LatitudeRef
        {
            get { return latitudeRef; }
            set
            {
                SetDirty();
                latitudeRef = value;
                if (enableSpecialUpdateLogic)
                    LatitudeChecked = true;
            }
        }

        public GpsCoordinate Latitude
        {
            get { return latitude; }
            set
            {
                SetDirty();
                latitude = value;
                if (enableSpecialUpdateLogic)
                {
                    LatitudeChecked = true;
                    if (latitudeRef == "")
                        latitudeRef = "N";
                }
            }
        }

        public string LongitudeRef
        {
            get { return longitudeRef; }
            set
            {
                SetDirty();
                longitudeRef = value;
                if (enableSpecialUpdateLogic)
                    LongitudeChecked = true;
            }
        }

        public GpsCoordinate Longitude
        {
            get { return longitude; }
            set
            {
                SetDirty();
                longitude = value;
                if (enableSpecialUpdateLogic)
                {
                    LongitudeChecked = true;
                    if (longitudeRef == "")
                        longitudeRef = "E";
                }
            }
        }

        public string AltitudeRef
        {
            get { return altitudeRef; }
            set
            {
                SetDirty();
                altitudeRef = value;
                if (enableSpecialUpdateLogic)
                    AltitudeChecked = true;
            }
        }

        public decimal Altitude
        {
            get { return altitude; }
            set
            {
                SetDirty();
                altitude = value;
                if (enableSpecialUpdateLogic)
                {
                    AltitudeChecked = true;
                    if (altitudeRef == "")
                        altitudeRef = "0";
                }
                
            }
        }

        public string SpeedRef
        {
            get { return speedRef; }
            set
            {
                SetDirty();
                speedRef = value;
                if (enableSpecialUpdateLogic)
                    SpeedChecked = true;
            }
        }

        public decimal Speed
        {
            get { return speed; }
            set
            {
                SetDirty();
                speed = value;
                if (enableSpecialUpdateLogic)
                {
                    SpeedChecked = true;
                    if (speedRef == "")
                        speedRef = "K";
                }
            }
        }

        public string TrackRef
        {
            get { return trackRef; }
            set
            {
                SetDirty();
                trackRef = value;
                if (enableSpecialUpdateLogic)
                    TrackChecked = true;
            }
        }

        public decimal Track
        {
            get { return track; }
            set
            {
                SetDirty();
                track = value;
                if (enableSpecialUpdateLogic)
                {
                    TrackChecked = true;
                    if (trackRef == "")
                        trackRef = "M";
                }
            }
        }

        public string ImageDirectionRef
        {
            get { return imageDirectionRef; }
            set
            {
                SetDirty();
                imageDirectionRef = value;
                if (enableSpecialUpdateLogic)
                    ImageDirectionChecked = true;
            }
        }

        public decimal ImageDirection
        {
            get { return imageDirection; }
            set
            {
                SetDirty();
                imageDirection = value;
                if (enableSpecialUpdateLogic)
                {
                    ImageDirectionChecked = true;
                    if (imageDirectionRef == "")
                        imageDirectionRef = "M";
                }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                SetDirty();
                date = value;
                if (enableSpecialUpdateLogic)
                    DateChecked = true;
            }
        }

        public bool LatitudeChecked
        {
            get { return latitudeChecked; }
            set { SetDirty(); latitudeChecked = value; }
        }

        public bool LongitudeChecked
        {
            get { return longitudeChecked; }
            set { SetDirty(); longitudeChecked = value; }
        }

        public bool AltitudeChecked
        {
            get { return altitudeChecked; }
            set { SetDirty(); altitudeChecked = value; }
        }

        public bool SpeedChecked
        {
            get { return speedChecked; }
            set { SetDirty(); speedChecked = value; }
        }

        public bool TrackChecked
        {
            get { return trackChecked; }
            set { SetDirty(); trackChecked = value; }
        }

        public bool ImageDirectionChecked
        {
            get { return imageDirectionChecked; }
            set { SetDirty(); imageDirectionChecked = value; }
        }

        public bool DateChecked
        {
            get { return dateChecked; }
            set { SetDirty(); dateChecked = value; }
        }

        #endregion

        [XmlIgnore]
        public bool PendingUpdates
        {
            get
            {
                return latitudeChecked ||
                       longitudeChecked ||
                       altitudeChecked ||
                       speedChecked ||
                       trackChecked ||
                       imageDirectionChecked ||
                       dateChecked;
            }
        }

        public void UpdatePicture(PictureMetaData pic)
        {
            if (latitudeChecked)
            {
                if (latitudeRef != "")
                {
                    pic.GpsLatitudeRef = latitudeRef;
                    pic.GpsLatitude = latitude.Clone();
                }
                else
                {
                    pic.GpsLatitude = null;
                    pic.GpsLatitudeRef = "";
                }
            }

            if (longitudeChecked)
            {
                if (longitudeRef != "")
                {
                    pic.GpsLongitudeRef = longitudeRef;
                    pic.GpsLongitude = longitude.Clone();
                }
                else
                {
                    pic.GpsLongitude = null;
                    pic.GpsLongitudeRef = "";
                }
            }

            if (altitudeChecked)
            {
                if (altitudeRef != "")
                {
                    pic.GpsAltitudeRef = altitudeRef;
                    pic.GpsAltitude = altitude;
                }
                else
                {
                    pic.GpsAltitudeRef = "";
                    pic.GpsAltitude = null;
                }
            }

            if (speedChecked)
            {
                if (speedRef != "")
                {
                    pic.GpsSpeedRef = speedRef;
                    pic.GpsSpeed = speed;
                }
                else
                {
                    pic.GpsSpeedRef = "";
                    pic.GpsSpeed = null;
                }
            }

            if (trackChecked)
            {
                if (trackRef != "")
                {
                    pic.GpsTrackRef = trackRef;
                    pic.GpsTrack = track;
                }
                else
                {
                    pic.GpsTrackRef = "";
                    pic.GpsTrack = null;
                }
            }

            if (imageDirectionChecked)
            {
                if (imageDirectionRef != "")
                {
                    pic.GpsImgDirectionRef = imageDirectionRef;
                    pic.GpsImgDirection = imageDirection;
                }
                else
                {
                    pic.GpsImgDirectionRef = "";
                    pic.GpsImgDirection = null;
                }
            }

            if (dateChecked)
            {
                if (date != DateTime.MinValue)
                    pic.GpsDateTimeStamp = date;
                else
                    pic.GpsDateTimeStamp = null;
            }

            if (pic.GpsLongitude == null && pic.GpsLatitude == null && !pic.GpsAltitude.HasValue &&
                !pic.GpsSpeed.HasValue && !pic.GpsTrack.HasValue && !pic.GpsImgDirection.HasValue)
            {
                pic.GpsDateTimeStamp = null;
                pic.GpsVersionIdRemove();
            }
            else
                pic.GpsVersioIdInit();
        }
    }
}