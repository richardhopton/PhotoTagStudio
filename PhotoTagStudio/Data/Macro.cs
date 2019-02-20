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
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Schroeter.PhotoTagStudio.Data
{
    public class Macro
    {
        private string name = "";
        private string description = "";
        private List<ModelBase> workItems = new List<ModelBase>();

        public Macro()
        {
        }

        #region properties
        [XmlIgnore]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        // workaround to get the serialition working on strings with newline
        public string[] DescriptionLines
        {
            get
            {
                return description.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            }
            set
            {
                description = String.Join("\r\n", value);
            }
        }

        public List<ModelBase> WorkItems
        {
            get { return workItems; }
            set { workItems = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        public void Serialize(Stream stream)
        {
            XmlSerializer ser = GetSerializer();
            ser.Serialize(stream,this);
        }

        public static Macro Deserialize(Stream stream)
        {
            try
            {
                XmlSerializer ser = GetSerializer();
                return ser.Deserialize(stream) as Macro;
            }
            catch
            {
                return null;
            }
        }

        private static XmlSerializer serializer;
        public static XmlSerializer GetSerializer()
        {
            if (serializer == null)
            {
                Type baseclass = typeof(ModelBase);
                List<Type> allTypes = new List<Type>();
                foreach (Type type in typeof(Macro).Assembly.GetTypes())
                    if (type.IsClass && !type.IsAbstract && type.IsPublic && type.IsSubclassOf(baseclass))
                        allTypes.Add(type);

                serializer = new XmlSerializer(typeof(Macro), allTypes.ToArray());
            }
            return serializer;
        }
    }
}
