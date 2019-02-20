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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using PSAUtils;

namespace Schroeter.Photo
{
    public class PictureMetaData : IEnumerable< KeyValuePair<string,string> >
    {
        public static bool RotateAsExifOrientation = false;

        private MetaData                            data;
        private Image                               image;
        
        private Dictionary<string, List<string>>    tags;
        private bool                                tagsListUpToDate;
        private string                              filename;

        private Semaphore sema;

        public PictureMetaData(string filename)
        {
            this.tags = new Dictionary<string, List<string>>();
            this.filename = filename;
            this.data = new MetaData(this.filename);
            this.tagsListUpToDate = false;
            this.image = null;

            this.sema = new Semaphore(1, 1);
        }

        ~PictureMetaData() 
        {
            Debug.Assert(data == null, "PictureMetaData was not closed!");
            this.Close();        
        }

        public void Close()
        {
            if ( data != null )
            {
                data.Close();
                data = null;
            }
        }

        public bool SaveChanges()
        {
            if (ExistFile)
            {
                data.SaveChanges();
                return true;
            }
            else
                return false;
        }

        private void UpdateTagList()
        {
            if (!this.tagsListUpToDate)
            {
                this.tags = new Dictionary<string, List<string>>();
                this.data.EnumMeta(this.enumCallback, null);
            }

            this.tagsListUpToDate = true;
        }
        private bool enumCallback(string key, string val, Object user)
        {
            if (!tags.ContainsKey(key))
                tags.Add(key, new List<string>());

            tags[key].Add(val);

            return true;
        }

        public string this[string name]
        {
            get { return this.getStringAttribute(name); }
        }

        public string this[TagDescription desc]
        {
            get
            {
                string unformated = this[desc.Fullname];
                return desc.FormatMethod(unformated);
            }
        }

        #region properties
        public string Filename
        {
            get { return filename; }
        }
        public bool ExistFile
        {
            get
            {
                return File.Exists(filename);
            }
        }
        public Image Image
        {
            get
            {              
                if (this.image == null)
                {
                    sema.WaitOne();
                    MemoryStream s = new MemoryStream(data.ImageData());
                    this.image = Image.FromStream(s);

                    if ( RotateAsExifOrientation )
                        this.image.RotateFlip(GetRotationFlipTypeFromExif());

                    s.Close();
                    s.Dispose();
                    sema.Release();
                }

                return this.image;
            }
        }

        public RotateFlipType GetRotationFlipTypeFromExif()
        {
            // see: http://sylvana.net/jpegcrop/exif_orientation.html
            switch ( this.ExifImageOrientation )
            {
                case 1: // top left
                    return RotateFlipType.RotateNoneFlipNone;

                case 2: // top right
                    return RotateFlipType.RotateNoneFlipX;
                case 3: // bottom right
                    return RotateFlipType.Rotate180FlipNone;
                case 4: // botton left
                    return RotateFlipType.RotateNoneFlipY;
                case 5: // left top
                    return RotateFlipType.Rotate270FlipX; 
                case 6: // right top
                    return RotateFlipType.Rotate90FlipNone;
                case 7: // right bottom
                    return RotateFlipType.Rotate90FlipX;
                case 8: // left bottom
                    return RotateFlipType.Rotate270FlipNone;
                
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }
        #endregion

        #region image & file properties
        public Size Size
        {
            get
            {
                string x = this.data.ReadMeta(Exif.Photo.PIXELXDIMENSION);
                string y = this.data.ReadMeta(Exif.Photo.PIXELYDIMENSION);
                
                if ( x != "" && y != "" )
                {
                    Size s = new Size(int.Parse(x), int.Parse(y));
                    return s;
                }
                else
                    return this.Image.Size;
            }
        }
        public float HorizontalResolution
        {
            get
            {
                decimal? d = getExifRationalAttribute(Exif.Image.XRESOLUTION);
                if (d.HasValue)
                    return (float) d.Value;
                else
                    return this.Image.HorizontalResolution;
            }
        }
        public float VerticalResolution
        {
            get
            {
                decimal? d = getExifRationalAttribute(Exif.Image.YRESOLUTION);
                if (d.HasValue)
                    return (float) d.Value;
                else
                    return this.Image.VerticalResolution;
            }
        }
        public long Filesize
        {
            get
            {
                FileInfo fi = new FileInfo(this.filename);
                return fi.Length;
            }
        }
        #endregion

        #region repeatable attributes
        public void ClearObjectAttribute() { this.ClearRepeatableAttribute( Iptc.OBJECT_ATTRIBUTE); }
        public void AddObjectAttribute(string value) { this.AddRepeatableAttribute(  Iptc.OBJECT_ATTRIBUTE, value); }
        public void RemoveObjectAttribute(string value) { this.RemoveRepeatableAttribute(Iptc.OBJECT_ATTRIBUTE, value); }
        public List<string> ListObjectAttribute() { return this.ListRepeatableAttribute(Iptc.OBJECT_ATTRIBUTE); }

        public void ClearSubject() { this.ClearRepeatableAttribute(Iptc.SUBJECT); }
        public void AddSubject(string value) { this.AddRepeatableAttribute(Iptc.SUBJECT, value); }
        public void RemoveSubject(string value) { this.RemoveRepeatableAttribute(Iptc.SUBJECT, value); }
        public List<string> ListSubject() { return this.ListRepeatableAttribute(Iptc.SUBJECT); }

        public void ClearSuppCategory() { this.ClearRepeatableAttribute(Iptc.SUPP_CATEGORY); }
        public void AddSuppCategory(string value) { this.AddRepeatableAttribute(Iptc.SUPP_CATEGORY, value); }
        public void RemoveSuppCategory(string value) { this.RemoveRepeatableAttribute(Iptc.SUPP_CATEGORY, value); }
        public List<string> ListSuppCategory() { return this.ListRepeatableAttribute(Iptc.SUPP_CATEGORY); }

        public void ClearKeyword() { this.ClearRepeatableAttribute(Iptc.KEYWORDS); }
        public void AddKeyword(string value) { this.AddRepeatableAttribute(Iptc.KEYWORDS, value); }
        public void RemoveKeyword(string value) { this.RemoveRepeatableAttribute(Iptc.KEYWORDS, value); }
        public List<string> ListKeyword() { return this.ListRepeatableAttribute(Iptc.KEYWORDS); }

        public void ClearLocationCode() { this.ClearRepeatableAttribute(Iptc.LOCATION_CODE); }
        public void AddLocationCode(string value) { this.AddRepeatableAttribute(Iptc.LOCATION_CODE, value); }
        public void RemoveLocationCode(string value) { this.RemoveRepeatableAttribute(Iptc.LOCATION_CODE, value); }
        public List<string> ListLocationCode() { return this.ListRepeatableAttribute(Iptc.LOCATION_CODE); }

        public void ClearLocationName() { this.ClearRepeatableAttribute(Iptc.LOCATION_NAME); }
        public void AddLocationName(string value) { this.AddRepeatableAttribute(Iptc.LOCATION_NAME, value); }
        public void RemoveLocationName(string value) { this.RemoveRepeatableAttribute(Iptc.LOCATION_NAME, value); }
        public List<string> ListLocationName() { return this.ListRepeatableAttribute(Iptc.LOCATION_NAME); }

        public void ClearReferenceService() { this.ClearRepeatableAttribute(Iptc.REFERENCE_SERVICE); }
        public void AddReferenceService(string value) { this.AddRepeatableAttribute(Iptc.REFERENCE_SERVICE, value); }
        public void RemoveReferenceService(string value) { this.RemoveRepeatableAttribute(Iptc.REFERENCE_SERVICE, value); }
        public List<string> ListReferenceService() { return this.ListRepeatableAttribute(Iptc.REFERENCE_SERVICE); }

        public void ClearReferenceNumber() { this.ClearRepeatableAttribute(Iptc.REFERENCE_NUMBER); }
        public void AddReferenceNumber(string value) { this.AddRepeatableAttribute(Iptc.REFERENCE_NUMBER, value); }
        public void RemoveReferenceNumber(string value) { this.RemoveRepeatableAttribute(Iptc.REFERENCE_NUMBER, value); }
        public List<string> ListReferenceNumber() { return this.ListRepeatableAttribute(Iptc.REFERENCE_NUMBER); }

        public void ClearByline() { this.ClearRepeatableAttribute(Iptc.BYLINE); }
        public void AddByline(string value) { this.AddRepeatableAttribute(Iptc.BYLINE, value); }
        public void RemoveByline(string value) { this.RemoveRepeatableAttribute(Iptc.BYLINE, value); }
        public List<string> ListByline() { return this.ListRepeatableAttribute(Iptc.BYLINE); }

        public void ClearBylineTitle() { this.ClearRepeatableAttribute(Iptc.BYLINE_TITLE); }
        public void AddBylineTitle(string value) { this.AddRepeatableAttribute(Iptc.BYLINE_TITLE, value); }
        public void RemoveBylineTitle(string value) { this.RemoveRepeatableAttribute(Iptc.BYLINE_TITLE, value); }
        public List<string> ListBylineTitle() { return this.ListRepeatableAttribute(Iptc.BYLINE_TITLE); }

        public void ClearContact() { this.ClearRepeatableAttribute(Iptc.CONTACT); }
        public void AddContact(string value) { this.AddRepeatableAttribute(Iptc.CONTACT, value); }
        public void RemoveContact(string value) { this.RemoveRepeatableAttribute(Iptc.CONTACT, value); }
        public List<string> ListContact() { return this.ListRepeatableAttribute(Iptc.CONTACT); }

        public void ClearWriter() { this.ClearRepeatableAttribute(Iptc.WRITER); }
        public void AddWriter(string value) { this.AddRepeatableAttribute(Iptc.WRITER, value); }
        public void RemoveWriter(string value) { this.RemoveRepeatableAttribute(Iptc.WRITER, value); }
        public List<string> ListWriter() { return this.ListRepeatableAttribute(Iptc.WRITER); }

        public void ClearRepeatableAttribute(string name)
        {
            int c = ListRepeatableAttribute(name).Count;
            for(int i = 0; i<c; i++)
                data.RemoveMeta(name);
            this.tagsListUpToDate = false;
        }
        public void AddRepeatableAttribute(string name, string value)
        {
            data.AddMeta(name, value);
            this.tagsListUpToDate = false;
        }
        public void RemoveRepeatableAttribute(string name, string value)
        {
            UpdateTagList();
            int numberInFile = 0;
            if (this.tags.ContainsKey(name))
            {
                numberInFile = this.tags[name].Count;
                this.tags[name].Remove(value);
            }

            for(int i = 0; i<numberInFile; i++)
                data.RemoveMeta(name);

            if (tags.ContainsKey(name))
                foreach (string s in tags[name])
                    data.AddMeta(name, s);

            this.tagsListUpToDate = false;
        }
        public List<string> ListRepeatableAttribute(string name)
        {
            UpdateTagList();

            if (this.tags.ContainsKey(name))
                return this.tags[name];
            else
                return new List<string> ();
        }
        #endregion
        #region string properties
        public string IptcObjectType
        {
            get { return this.getStringAttribute(Iptc.OBJECT_TYPE); }
            set { this.setStringAttribute(Iptc.OBJECT_TYPE, value); }
        }
        public string IptcObjectName
        {
            get { return this.getStringAttribute(Iptc.OBJECT_NAME); }
            set { this.setStringAttribute(Iptc.OBJECT_NAME, value); }
        }
        public string IptcEditStatus
        {
            get { return this.getStringAttribute(Iptc.EDIT_STATUS); }
            set { this.setStringAttribute(Iptc.EDIT_STATUS, value); }
        }
        public string IptcEditorialUpdate
        {
            get { return this.getStringAttribute(Iptc.EDITORIAL_UPDATE); }
            set { this.setStringAttribute(Iptc.EDITORIAL_UPDATE, value); }
        }
        public string IptcUrgency
        {
            get { return this.getStringAttribute(Iptc.URGENCY); }
            set { this.setStringAttribute(Iptc.URGENCY, value); }
        }
        public string IptcCategory
        {
            get { return this.getStringAttribute(Iptc.CATEGORY); }
            set { this.setStringAttribute(Iptc.CATEGORY, value); }
        }
        public string IptcFixtureId
        {
            get { return this.getStringAttribute(Iptc.FIXTUREID); }
            set { this.setStringAttribute(Iptc.FIXTUREID, value); }
        }
        public string IptcSpecialInstructions
        {
            get { return this.getStringAttribute(Iptc.SPECIAL_INSTRUCTIONS); }
            set { this.setStringAttribute(Iptc.SPECIAL_INSTRUCTIONS, value); }
        }
        public string IptcActionAdvised
        {
            get { return this.getStringAttribute(Iptc.ACTION_ADVISED); }
            set { this.setStringAttribute(Iptc.ACTION_ADVISED, value); }
        }
        public string IptcProgram
        {
            get { return this.getStringAttribute(Iptc.PROGRAM); }
            set { this.setStringAttribute(Iptc.PROGRAM, value); }
        }
        public string IptcProgramVersion
        {
            get { return this.getStringAttribute(Iptc.PROGRAM_VERSION); }
            set { this.setStringAttribute(Iptc.PROGRAM_VERSION, value); }
        }
        public string IptcCity
        {
            get { return this.getStringAttribute(Iptc.CITY); }
            set { this.setStringAttribute(Iptc.CITY, value); }
        }
        public string IptcSubLocation
        {
            get { return this.getStringAttribute(Iptc.SUB_LOCATION); }
            set { this.setStringAttribute(Iptc.SUB_LOCATION, value); }
        }
        public string IptcProvinceState
        {
            get { return this.getStringAttribute(Iptc.PROVINCE_STATE); }
            set { this.setStringAttribute(Iptc.PROVINCE_STATE, value); }
        }
        public string IptcCountryCode
        {
            get { return this.getStringAttribute(Iptc.COUNTRY_CODE); }
            set { this.setStringAttribute(Iptc.COUNTRY_CODE, value); }
        }
        public string IptcCountryName
        {
            get { return this.getStringAttribute(Iptc.COUNTRY_NAME); }
            set { this.setStringAttribute(Iptc.COUNTRY_NAME, value); }
        }
        public string IptcTransmissionReference
        {
            get { return this.getStringAttribute(Iptc.TRANSMISSION_REFERENCE); }
            set { this.setStringAttribute(Iptc.TRANSMISSION_REFERENCE, value); }
        }
        public string IptcHeadline
        {
            get { return this.getStringAttribute(Iptc.HEADLINE); }
            set { this.setStringAttribute(Iptc.HEADLINE, value); }
        }
        public string IptcCredit
        {
            get { return this.getStringAttribute(Iptc.CREDIT); }
            set { this.setStringAttribute(Iptc.CREDIT, value); }
        }
        public string IptcSource
        {
            get { return this.getStringAttribute(Iptc.SOURCE); }
            set { this.setStringAttribute(Iptc.SOURCE, value); }
        }
        public string IptcCopyright
        {
            get { return this.getStringAttribute(Iptc.COPYRIGHT); }
            set { this.setStringAttribute(Iptc.COPYRIGHT, value); }
        }
        public string IptcCaption
        {
            get { return this.getStringAttribute(Iptc.CAPTION); }
            set { this.setStringAttribute(Iptc.CAPTION, value); }
        }
        public string IptcImageType
        {
            get { return this.getStringAttribute(Iptc.IMAGE_TYPE); }
            set { this.setStringAttribute(Iptc.IMAGE_TYPE, value); }
        }
        public string IptcImageOrientation
        {
            get { return this.getStringAttribute(Iptc.IMAGE_ORIENTATION); }
            set { this.setStringAttribute(Iptc.IMAGE_ORIENTATION, value); }
        }
        public string IptcLanguage
        {
            get { return this.getStringAttribute(Iptc.LANGUAGE); }
            set { this.setStringAttribute(Iptc.LANGUAGE, value); }
        }

        public string getStringAttribute(string name)
        {
            return this.data.ReadMeta(name);
        }
        public void setStringAttribute(string name, string value)
        {
            this.tagsListUpToDate = false;

            this.data.RemoveMeta(name);

            if (value != null && value != "")
                this.data.ModifyMeta(name, value);
        }
        #endregion
        #region date time properties
        public DateTime? IptcDateTimeCreated
        {
            get { return this.getDateTimeAttribute(Iptc.DATE_CREATED, Iptc.TIME_CREATED); }
            set { setDateTimeAttribute(Iptc.DATE_CREATED, Iptc.TIME_CREATED, value); }
        }
        public DateTime? IptcReleaseDateTime
        {
            get { return this.getDateTimeAttribute(Iptc.RELEASE_DATE, Iptc.RELEASE_TIME); }
            set { setDateTimeAttribute(Iptc.RELEASE_DATE, Iptc.RELEASE_TIME, value); }
        }
        public DateTime? IptcExpirationDateTime
        {
            get { return this.getDateTimeAttribute(Iptc.EXPIRATION_DATE, Iptc.EXPIRATION_TIME); }
            set { setDateTimeAttribute(Iptc.EXPIRATION_DATE, Iptc.EXPIRATION_TIME, value); }
        }
        public DateTime? IptcDigitizationDateTime
        {
            get { return this.getDateTimeAttribute(Iptc.DIGITIZATION_DATE, Iptc.DIGITIZATION_TIME); }
            set { setDateTimeAttribute(Iptc.DIGITIZATION_DATE, Iptc.DIGITIZATION_TIME, value); }
        }

        private DateTime? getDateTimeAttribute(string nameDate, string nameTime)
        {
            string date = getStringAttribute(nameDate);
            string time = getStringAttribute(nameTime);

            DateTime d;

            if (date != "")
            {
                d = new DateTime(
                    int.Parse(date.Substring(0, 4)),
                    int.Parse(date.Substring(5, 2)),
                    int.Parse(date.Substring(8, 2)));
            }
            else
                return null;

            if (time != "")
            {
                d = d.AddHours   ( int.Parse(time.Substring(0, 2)));
                d = d.AddMinutes ( int.Parse(time.Substring(3, 2)));
                d = d.AddSeconds ( int.Parse(time.Substring(6, 2)));

                if (time.Substring(8, 1) == "+")
                {
                    d = d.AddHours(   - int.Parse(time.Substring(9, 2)));
                    d = d.AddMinutes( - int.Parse(time.Substring(12, 2)));
                }
                else
                {
                    d = d.AddHours(    int.Parse(time.Substring(9, 2)));
                    d = d.AddMinutes(  int.Parse(time.Substring(12, 2)));
                }
            }

            return d.ToLocalTime();
        }
        private void setDateTimeAttribute(string nameDate, string nameTime, DateTime? value)
        {
            if (value.HasValue)
            {
                int utcOffset= TimeZone.CurrentTimeZone.GetUtcOffset(value.Value).Hours;
                string utcAppendix = (utcOffset >= 0 ? "+" : "") + utcOffset.ToString("00") + ":00";

                string date = value.Value.ToString("yyyy-MM-dd");
                string time = value.Value.ToString("HH:mm:ss") + utcAppendix;  

                setStringAttribute(nameDate, date);
                setStringAttribute(nameTime, time);

                this.tagsListUpToDate = false;
                this.data.RemoveMeta(nameTime);
                this.data.ModifyMeta(nameTime, time, MetaData.TypeId.time);
            }
            else
            {
                setStringAttribute(nameDate, null);
                setStringAttribute(nameTime, null);
            }
        }
        #endregion
        #region exif date time properties
        public DateTime? ExifOriginalDateTime
        {
            get { return getExifDateTimeAttribute(Exif.Photo.DATETIMEORIGINAL); }
            set { setExifDateTimeAttribute(Exif.Photo.DATETIMEORIGINAL, value); }
        }
        public DateTime? ExifDigitizedDateTime
        {
            get { return getExifDateTimeAttribute(Exif.Photo.DATETIMEDIGITIZED); }
            set { setExifDateTimeAttribute(Exif.Photo.DATETIMEDIGITIZED, value); }
        }
        public DateTime? ExifImageDateTime
        {
            get { return getExifDateTimeAttribute(Exif.Image.DATETIME); }
            set { setExifDateTimeAttribute(Exif.Image.DATETIME, value); }
        }

        private DateTime? getExifDateTimeAttribute(string name)
        {
            string s = getStringAttribute(name);
            if (s == "" || s == null)
                return null;
            else
            {
                DateTime d = new DateTime(
                    int.Parse(s.Substring(0, 4)),
                    int.Parse(s.Substring(5, 2)),
                    int.Parse(s.Substring(8, 2)),
                    int.Parse(s.Substring(11, 2)),
                    int.Parse(s.Substring(14, 2)),
                    int.Parse(s.Substring(17, 2)));

                return d;
            }
        }
        private void setExifDateTimeAttribute(string name, DateTime? value)
        {
            if (value.HasValue)
            {
                string date = value.Value.ToString("yyyy:MM:dd HH:mm:ss");
                setStringAttribute(name, date);
            }
            else
                setStringAttribute(name, null);
        }
        #endregion
        #region exif gps properties
        public void GpsVersioIdInit()
        {
            this.data.ModifyMeta(Exif.GpsInfo.GPSVERSIONID, "2 2 0 0 ", MetaData.TypeId.unsignedByte);
        }
        public void GpsVersionIdRemove()
        {
            this.data.RemoveMeta(Exif.GpsInfo.GPSVERSIONID);
        }
        public string GpsVersionId
        {
            get
            {
                return getStringAttribute(Exif.GpsInfo.GPSVERSIONID);
            }
        }
        public GpsCoordinate GpsLatitude
        {
            get
            {
                return GpsCoordinate.FromExif(this.getStringAttribute(Exif.GpsInfo.GPSLATITUDE));
            }
            set
            {
                if (value == null)
                {
                    this.data.RemoveMeta(Exif.GpsInfo.GPSLATITUDE);
                }
                else
                {
                    string s = GpsCoordinate.DecimalToExifRationalString(value.Degrees)
                               + " " + GpsCoordinate.DecimalToExifRationalString(value.Minutes)
                               + " " + GpsCoordinate.DecimalToExifRationalString(value.Seconds);

                    this.tagsListUpToDate = false;
                    this.data.ModifyMeta(Exif.GpsInfo.GPSLATITUDE, s, MetaData.TypeId.unsignedRational);
                }
            }
        }
        public string GpsLatitudeRef
        {
            get { return this.getStringAttribute(Exif.GpsInfo.GPSLATITUDEREF); }
            set { this.setStringAttribute(Exif.GpsInfo.GPSLATITUDEREF, value); }
        }
        public GpsCoordinate GpsLongitude
        {
            get { return GpsCoordinate.FromExif(this.getStringAttribute(Exif.GpsInfo.GPSLONGITUDE)); }
            set
            {
                if (value == null)
                {
                    this.data.RemoveMeta(Exif.GpsInfo.GPSLONGITUDE);
                }
                else
                {
                    string s = GpsCoordinate.DecimalToExifRationalString(value.Degrees)
                               + " " + GpsCoordinate.DecimalToExifRationalString(value.Minutes)
                               + " " + GpsCoordinate.DecimalToExifRationalString(value.Seconds);

                    this.tagsListUpToDate = false;
                    this.data.ModifyMeta(Exif.GpsInfo.GPSLONGITUDE, s, MetaData.TypeId.unsignedRational);
                }
            }
        }
        public string GpsLongitudeRef
        {
            get { return this.getStringAttribute(Exif.GpsInfo.GPSLONGITUDEREF); }
            set { this.setStringAttribute(Exif.GpsInfo.GPSLONGITUDEREF, value); }
        }
        public string GpsAltitudeRef
        {
            get { return this.getStringAttribute(Exif.GpsInfo.GPSALTITUDEREF).Trim(); }
            set { this.setStringAttribute(Exif.GpsInfo.GPSALTITUDEREF, value); }
        }
        public decimal? GpsAltitude
        {
            get { return getExifRationalAttribute(Exif.GpsInfo.GPSALTITUDE); }
            set { setExifRationalAttribute(Exif.GpsInfo.GPSALTITUDE, value); }
        }
        public string GpsSpeedRef
        {
            get { return this.getStringAttribute(Exif.GpsInfo.GPSSPEEDREF); }
            set { this.setStringAttribute(Exif.GpsInfo.GPSSPEEDREF, value); }
        }
        public decimal? GpsSpeed
        {
            get { return getExifRationalAttribute(Exif.GpsInfo.GPSSPEED); }
            set { setExifRationalAttribute(Exif.GpsInfo.GPSSPEED, value); }
        }
        public string GpsTrackRef
        {
            get { return this.getStringAttribute(Exif.GpsInfo.GPSTRACKREF); }
            set { this.setStringAttribute(Exif.GpsInfo.GPSTRACKREF, value); }
        }
        public decimal? GpsTrack
        {
            get { return getExifRationalAttribute(Exif.GpsInfo.GPSTRACK); }
            set { setExifRationalAttribute(Exif.GpsInfo.GPSTRACK, value); }
        }
        public string GpsImgDirectionRef
        {
            get { return this.getStringAttribute(Exif.GpsInfo.GPSIMGDIRECTIONREF); }
            set { this.setStringAttribute(Exif.GpsInfo.GPSIMGDIRECTIONREF, value); }
        }
        public decimal? GpsImgDirection
        {
            get { return getExifRationalAttribute(Exif.GpsInfo.GPSIMGDIRECTION); }
            set { setExifRationalAttribute(Exif.GpsInfo.GPSIMGDIRECTION, value); }
        }
        
        public DateTime? GpsDateTimeStamp
        {
            get { return getGpsDateTimeAttribute(Exif.GpsInfo.GPSDATESTAMP, Exif.GpsInfo.GPSTIMESTAMP); }
            set { setGpsDateTimeAttribute(Exif.GpsInfo.GPSDATESTAMP, Exif.GpsInfo.GPSTIMESTAMP,value);  }
        }
        
        private void setExifRationalAttribute(string name, decimal? value)
        {
            if ( value.HasValue )
            {
                string s = GpsCoordinate.DecimalToExifRationalString(value);

                this.tagsListUpToDate = false;
                this.data.ModifyMeta(name, s,MetaData.TypeId.signedRational);
            }
            else
                this.data.RemoveMeta(name);
        }
        private decimal? getExifRationalAttribute(string name)
        {
            return GpsCoordinate.ExifRationalStringToDecimal(getStringAttribute(name) );
        }
        private DateTime? getGpsDateTimeAttribute(string nameDate, string nameTime)
        {
            string date = getStringAttribute(nameDate);
            string time = getStringAttribute(nameTime);

            DateTime d;

            if (date != "")
            {
                d = new DateTime(
                    int.Parse(date.Substring(0, 4)),
                    int.Parse(date.Substring(5, 2)),
                    int.Parse(date.Substring(8, 2)));
            }
            else
                return null;

            if (time != "")
            {
                string[] timep = time.Split(' ');
                if ( timep.Length == 3 )
                {
                    decimal? h = GpsCoordinate.ExifRationalStringToDecimal(timep[0]);
                    decimal? m = GpsCoordinate.ExifRationalStringToDecimal(timep[1]);
                    decimal? s = GpsCoordinate.ExifRationalStringToDecimal(timep[2]);

                    if ( h.HasValue && m.HasValue && s.HasValue)
                    {
                        d = d.AddHours((double) h.Value);
                        d = d.AddMinutes((double) m.Value);
                        d = d.AddSeconds((double) s.Value);
                    }
                }
            }

            return d;
        }
        private void setGpsDateTimeAttribute(string nameDate, string nameTime, DateTime? value)
        {
            if (value.HasValue)
            {
                string date = value.Value.ToString("yyyy:MM:dd");
                string time = value.Value.ToString("HH'/'1 mm'/'1 ss'/'1");  

                setStringAttribute(nameDate, date);
                this.data.ModifyMeta(nameTime, time, MetaData.TypeId.unsignedRational);
                this.tagsListUpToDate = false;
            }
            else
            {
                setStringAttribute(nameDate, null);
                setStringAttribute(nameTime, null);
            }
        }
        #endregion

        #region other exif properties
        public int ExifImageOrientation
        {
            get
            {
                if (data == null)
                    return 1;

                string s = data.ReadMeta(Exif.Image.ORIENTATION);
                if (s == "")
                    return 1;

                try
                {
                    int i = int.Parse(s);
                    return i;
                }
                catch
                {
                    return 1;
                }
            }
            set
            {
                data.ModifyMeta(Exif.Image.ORIENTATION, value.ToString(), MetaData.TypeId.signedShort);
            }
        }
        public int ExifThumbnailOrientation
        {
            get
            {
                string s = data.ReadMeta(Exif.Thumbnail.ORIENTATION);
                if (s == "")
                    return 1;

                try
                {
                    int i = int.Parse(s);
                    return i;
                }
                catch
                {
                    return 1;
                }
            }
            set
            {
                data.ModifyMeta(Exif.Thumbnail.ORIENTATION, value.ToString(), MetaData.TypeId.signedShort);
            }
        }      
        public void RemoveExifThumbnailOrientation()
        {
            string s = data.ReadMeta(Exif.Thumbnail.ORIENTATION);
            if (s != "")
                data.RemoveMeta(Exif.Thumbnail.ORIENTATION);                
        }
        #endregion

        #region Enum
        #region IEnumerable< KeyValuePair<string,string> > Members

        public IEnumerator< KeyValuePair<string, string> > GetEnumerator()
        {
            UpdateTagList();
            return new PictureMetaDataEnumerator(this.tags);
        }

        #endregion

        public IEnumerator< KeyValuePair<string, List<string>>> GetListEnumerator()
        {
            UpdateTagList();
            return this.tags.GetEnumerator();
        }

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
        #endregion
    }
}