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
using System.Xml.Serialization;
using Schroeter.PhotoTagStudio.Features.Renamer;

namespace Schroeter.PhotoTagStudio.Data
{
    [XmlInclude(typeof(IptcModel))]
    [XmlInclude(typeof(ExifGpsModel))]
    [XmlInclude(typeof(CopyMoveModel))]
    [XmlInclude(typeof(RenameModel))]
    [XmlInclude(typeof(PluginModel))]
    [XmlInclude(typeof(ExifDateModel))]
    public class ModelBase
    {
        protected bool enableSpecialUpdateLogic = false;
        protected bool isDirty = false;

        [XmlIgnore]
        public bool EnableSpecialUpdateLogic
        {
            get { return enableSpecialUpdateLogic; }
            set { enableSpecialUpdateLogic = value; }
        }

        protected void SetDirty()
        {
            isDirty = true;
        }

        public void ResetDirty()
        {
            isDirty = false;
        }

        [XmlIgnore]
        public bool IsDirty
        {
            get { return isDirty; }
        }

        public virtual bool ForbitExecution()
        {
            return false;
        }

        public static MODEL CloneModel<MODEL>(MODEL m) where MODEL: ModelBase
        {
            XmlSerializer ser = new XmlSerializer(typeof(MODEL));
            MemoryStream s = new MemoryStream();
            ser.Serialize(s,m);
            
            s.Flush();
            s.Position = 0;

            MODEL n = ser.Deserialize(s) as MODEL;

            return n;
        }
    }
}