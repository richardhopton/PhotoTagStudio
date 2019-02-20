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
using System.Text;

namespace Schroeter.Photo
{
    public class GpsCoordinate
    {
        private decimal degrees;
        private decimal minutes;
        private decimal seconds;

        public GpsCoordinate()
        {
            
        }
        
        public GpsCoordinate(decimal degrees, decimal minutes, decimal seconds)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        
        public GpsCoordinate(decimal value)
        {
            SetValue(value);
        }

        public decimal Degrees
        {
            get { return degrees; }
            set { degrees = value; }
        }
        public decimal Minutes
        {
            get { return minutes; }
            set { minutes = value; }
        }
        public decimal Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
        
        public decimal GetValue()
        {
            return GetValue(false);
        }
        
        public decimal GetValue(bool negate)
        {
            return (degrees + minutes/60 + seconds/3600) * (negate ? -1 :1);
        }
        
        public void SetValue(decimal val)
        {
            val = Math.Abs(val);

            degrees = Decimal.Floor(val);
            val -= degrees;
            val *= 60;

            minutes = Decimal.Floor(val);
            val -= minutes;
            val *= 60;

            seconds = val;
        }
        
        public static GpsCoordinate FromExif(string exifString)
        {
            if (exifString == null || exifString == "")
                return null;

            string[] dms = exifString.Split(' ');
            if (dms.Length != 3)
                return null;

            decimal? d = ExifRationalStringToDecimal(dms[0]);
            decimal? m = ExifRationalStringToDecimal(dms[1]);
            decimal? s = ExifRationalStringToDecimal(dms[2]);
            if (!d.HasValue || !m.HasValue || !s.HasValue)
                return null;

            return new GpsCoordinate(d.Value, m.Value, s.Value);
        }
        public static string InputMask
        {
            get { return "000° 00' 00.00\""; }
        }        
        public void FromString(string str)
        {
            decimal d = 0;
            decimal m = 0;
            decimal s = 0;

            try
            {
                string[] p = str.Split(' ');
                if (p.Length >= 1)
                    d = decimal.Parse(cleanNumString(p[0]));
                if (p.Length >= 2)
                    m = decimal.Parse(cleanNumString(p[1]));
                if (p.Length >= 3)
                    s = decimal.Parse(cleanNumString(p[2]));
            }
            catch
            {
                return;
            }

            degrees = d;
            minutes = m;
            seconds = s;
        }
        
        private string cleanNumString(string s)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            foreach (char c in s)
                if (char.IsNumber(c) || c == '.' || c == ',')
                    sb.Append(c);

            return sb.ToString();
        }
        
        public override string ToString()
        {
            return string.Format("{0:000}° {1:00}' {2:00.00}\"", degrees, minutes, seconds);
        }

        internal static string DecimalToExifRationalString(decimal? value)
        {
            int z = 1;
            int n = (int) decimal.Floor(value.Value*z);
            while ( (value.Value - ((decimal)n/z))!=0 && z <10000 )
            {
                z *= 10;
                n = (int)decimal.Floor(value.Value*z);
            }

            return n.ToString() + "/" + z.ToString();
        }
        internal static decimal? ExifRationalStringToDecimal(string s)
        {
            if (s == "" || s == null)
                return null;

            string[] p = s.Split('/');
            if (p.Length != 2)
                return null;

            decimal zaehler = int.Parse(p[0]);
            decimal nenner = int.Parse(p[1]);

            return zaehler/nenner;
        }

        public GpsCoordinate Clone()
        {
            return new GpsCoordinate(degrees,minutes,seconds);
        }
    }
}
