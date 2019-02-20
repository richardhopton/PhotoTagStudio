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
using System.Xml.Serialization;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Data
{
    [Flags]
    public enum ExifDateFields
    {
        None = 0,
        ExifImageDateTime = 1,
        ExifPhotoDateTimeOriginal = 2,  // this one is used by flickr        
        ExifPhotoDateTimeDigitized = 4,
        ExifGpsInfoDateTimeStamp = 8,
        IptcCreated = 16,

        FlickrDateTime = ExifPhotoDateTimeOriginal
    }

    [MacroEnabled("EXIF dates", typeof(ExifDateView), typeof(ExifDateWorker))]
    public class ExifDateModel : ModelBase
    {
        private ExifDateFields sourceField = ExifDateFields.None;
        private DateTime customSource = DateTime.Now;

        private TimeSpan offset = new TimeSpan(0);

        private ExifDateFields targetFields = ExifDateFields.None;

        public ExifDateModel()
        {
        }

        #region properties
        public ExifDateFields SourceField
        {
            get { return sourceField; }
            set { sourceField = value; }
        }

        public DateTime CustomSource
        {
            get { return customSource; }
            set { customSource = value; }
        }

        [XmlIgnore]
        public TimeSpan Offset
        {
            get { return offset; }
            set
            {
                 offset = value;
            }
        }

        public ExifDateFields TargetFields
        {
            get { return targetFields; }
            set { targetFields = value; }
        }
        #endregion

        #region timespan serialization
        // see http://codebetter.com/blogs/brendan.tompkins/archive/2004/08/10/21612.aspx
        public long _Offset
        {
            get { return Offset.Ticks; }
            set { this.Offset = new TimeSpan(value); }
        }

        public bool PendingUpdates
        {
            get { return targetFields != ExifDateFields.None; }
        }

        #endregion
    }
}
