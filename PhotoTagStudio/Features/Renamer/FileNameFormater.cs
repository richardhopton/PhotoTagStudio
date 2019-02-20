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
using System.IO;
using Schroeter.Photo;

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    class FileNameFormater
    {
        private static string FormatDate(DateTime d, string format)
        {
            try
            {
                return d.ToString(format);
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string FormatFilename(PictureMetaData currentPicture, string format)
        {
            #region text fields
            format = format.Replace("%cap", currentPicture.IptcCaption);

            if (currentPicture.ListContact().Count > 0)
                format = format.Replace("%con", currentPicture.ListContact()[0]);
            else
                format = format.Replace("%con", "");

            format = format.Replace("%on", currentPicture.IptcObjectName);
            format = format.Replace("%cr", currentPicture.IptcCopyright);
            format = format.Replace("%sl", currentPicture.IptcSubLocation);
            format = format.Replace("%cn", currentPicture.IptcCountryName);
            format = format.Replace("%cc", currentPicture.IptcCountryCode);
            format = format.Replace("%h", currentPicture.IptcHeadline);
            format = format.Replace("%c", currentPicture.IptcCity);
            format = format.Replace("%s", currentPicture.IptcProvinceState);

            if (currentPicture.ListByline().Count > 0)
                format = format.Replace("%a", currentPicture.ListByline()[0]);
            else
                format = format.Replace("%a", "");

            if (currentPicture.ListWriter().Count > 0)
                format = format.Replace("%w", currentPicture.ListWriter()[0]);
            else
                format = format.Replace("%w", "");

            string keywords = string.Join(", ", currentPicture.ListKeyword().ToArray());                      
            format = format.Replace("%k", keywords);

            if ( format.Contains("%file"))
            {
                FileInfo fi = new FileInfo(currentPicture.Filename);
                string filename = fi.Name;
                filename = filename.Substring(0, filename.Length - fi.Extension.Length);
                format = format.Replace("%file", filename );
            }

            if (format.Contains("%dir"))
            {                
                FileInfo fi = new FileInfo(currentPicture.Filename);
                format = format.Replace("%dir", fi.Directory.Name);
            }

            #endregion

            #region date time fields
            ReplaceDateFields("%dc", currentPicture.ExifOriginalDateTime, ref format);
            ReplaceDateFields("%dd", currentPicture.ExifDigitizedDateTime, ref format);
            ReplaceDateFields("%d", currentPicture.IptcDateTimeCreated, ref format);
            #endregion

            format = format.Replace('\\', ' ');
            format = format.Replace(':', ' ');
            format = format.Replace('/', ' ');

            return format.Trim();
        }

        private static void ReplaceDateFields(string field, DateTime? value, ref string s)
        {
            int fieldLen = field.Length;
            
            while (s.Contains(field))
            {
                string format = "";
                int pos = s.IndexOf(field);
                int posStart = s.IndexOf("[", pos);
                int posEnd = -1;
                if (posStart != -1 )
                    posEnd = s.IndexOf("]", posStart);
                if (pos != -1 && posStart != -1 && posEnd != -1 && pos + fieldLen == posStart)
                {
                    format = s.Substring(posStart+1, posEnd - posStart - 1);
                    s = s.Remove(posStart , posEnd - posStart+1 );
                }

                s = s.Remove(pos, fieldLen);
                if (value.HasValue)
                    s = s.Insert(pos, FormatDate(value.Value, format));
            }
        }
    }
}