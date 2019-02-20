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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Schroeter.PhotoTagStudio.Data
{
    [Serializable]
    public class PresetStore : IXmlSerializable
    {
        PresetStoreXml ps = new PresetStoreXml();

        public PresetStore()
        {
            
        }

        #region proxy for ps method calls
        public void AddPresetModel<MODEL>(string name, MODEL model) where MODEL : ModelBase
        {
            ps.AddPresetModel(name, model);
        }

        public MODEL GetPresetModel<MODEL>(string name) where MODEL : ModelBase
        {
            return ps.GetPresetModel<MODEL>(name);
        }

        public List<string> GetAllPresetModelNames<MODEL>() where MODEL : ModelBase
        {
            return ps.GetAllPresetModelNames<MODEL>();
        }

        public void DeletePresetModel<MODEL>(string name) where MODEL : ModelBase
        {
            ps.DeletePresetModel<MODEL>(name);
        }

        public MODEL GetLastModel<MODEL>() where MODEL : ModelBase
        {
            return ps.GetLastModel<MODEL>();
        }

        public void SaveLastModel<MODEL>(MODEL model) where MODEL : ModelBase
        {
            ps.SaveLastModel(model);
        }
        #endregion

        #region IXmlSerializable Members

        public XmlSchema GetSchema()
        {
            return new XmlSchema();
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            object o = GetSerializer().Deserialize(reader);
            ps = o as PresetStoreXml;

            reader.ReadEndElement();
        }
        public void WriteXml(XmlWriter writer)
        {
            GetSerializer().Serialize(writer, ps);
        }
        #endregion

        private static XmlSerializer serializer;
        private static XmlSerializer GetSerializer()
        {
            if (serializer == null)
            {
                Type baseclass = typeof (ModelBase);
                List<Type> allTypes = new List<Type>();
                foreach (Type type in typeof(PresetStore).Assembly.GetTypes())
                    if ( type.IsClass && !type.IsAbstract && type.IsPublic && type.IsSubclassOf(baseclass) )
                    {
                        allTypes.Add(type);

                        Type m = typeof (ModelStore<>);  // create ModelStore<type>
                        allTypes.Add(m.MakeGenericType(type));
                    }

                serializer = new XmlSerializer(typeof(PresetStoreXml), allTypes.ToArray());
            }
            return serializer;
        }
    }
}
