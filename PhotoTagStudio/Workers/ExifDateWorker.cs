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
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Workers
{
    public class ExifDateWorker : SingleFileWorkerBase<ExifDateModel>
    {
        public override bool ProcessFile(PictureMetaData pmd, ExifDateModel model)
        {
            if (!model.PendingUpdates)
                return false;

            // get the base value
            DateTime date = DateTime.MinValue;
            switch (model.SourceField)
            {
                case ExifDateFields.ExifImageDateTime:
                    if (pmd.ExifImageDateTime.HasValue)
                        date = pmd.ExifImageDateTime.Value;
                    break;
                case ExifDateFields.ExifPhotoDateTimeOriginal:
                    if (pmd.ExifOriginalDateTime.HasValue)
                        date = pmd.ExifOriginalDateTime.Value;
                    break;
                case ExifDateFields.ExifPhotoDateTimeDigitized:
                    if (pmd.ExifDigitizedDateTime.HasValue)
                        date = pmd.ExifDigitizedDateTime.Value;
                    break;
                case ExifDateFields.ExifGpsInfoDateTimeStamp:
                    if (pmd.GpsDateTimeStamp.HasValue)
                        date = pmd.GpsDateTimeStamp.Value;
                    break;
                case ExifDateFields.IptcCreated:
                    if (pmd.IptcDateTimeCreated.HasValue)
                        date = pmd.IptcDateTimeCreated.Value;
                    break;
                case ExifDateFields.None:
                    date = model.CustomSource;
                    break;                    
            }

            // add the offset
            if (date != DateTime.MinValue && model.SourceField != ExifDateFields.None)
                date = date.Add(model.Offset);
            
            // now wirte it back to the fileds
            DateTime? newValue = date == DateTime.MinValue ? null : new DateTime?(date);

            if ( (model.TargetFields & ExifDateFields.ExifImageDateTime) > 0)
                pmd.ExifImageDateTime = newValue;
            if ((model.TargetFields & ExifDateFields.ExifPhotoDateTimeOriginal) > 0)
                pmd.ExifOriginalDateTime = newValue;
            if ((model.TargetFields & ExifDateFields.ExifPhotoDateTimeDigitized) > 0)
                pmd.ExifDigitizedDateTime = newValue;
            if ((model.TargetFields & ExifDateFields.ExifGpsInfoDateTimeStamp) > 0)
                pmd.GpsDateTimeStamp = newValue;
            if ((model.TargetFields & ExifDateFields.IptcCreated) > 0)
                pmd.IptcDateTimeCreated = newValue;

            return true;
        }
    }
}
