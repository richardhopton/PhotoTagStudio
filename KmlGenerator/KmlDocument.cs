#region Copyright (C) 2006 Benjamin Schröter <benjamin@irgendwie.net>
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

using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Schroeter.KmlGenerator
{
    public class KmlDocument
    {
        private string name;
        private List<Folder> folders;
        private List<PlacemarkBase> placemarks;

        public KmlDocument()
        {
            folders = new List<Folder>();
            placemarks = new List<PlacemarkBase>();
        }
        
        public XmlDocument CreateXml(bool forArchiv)
        {
            Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Schroeter.KmlGenerator.Templates.KmlDocument.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(s);
            s.Close();

            XmlElement root = (XmlElement)doc.ChildNodes[1];
            XmlElement document = (XmlElement)root.ChildNodes[0];
            XmlElement n = (XmlElement)document.ChildNodes[0];
            n.InnerText = name;

            foreach (Folder f in folders)
                document.AppendChild(doc.ImportNode(f.CreateXml(forArchiv), true));
            
            foreach (PlacemarkBase p in placemarks)
                document.AppendChild(doc.ImportNode(p.CreateXml(forArchiv), true));

            return doc;
        }
        
        #region properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Folder> Folders
        {
            get { return folders; }
        }

        public List<PlacemarkBase> Placemarks
        {
            get { return placemarks; }
        }
        #endregion

        public void GetPlacemarks(List<PlacemarkBase> allPlacemarks)
        {
            allPlacemarks.AddRange(placemarks);
            foreach (Folder f in folders)
                f.GetPlacemarks(allPlacemarks);            
        }

        public bool IsEmpty
        {
            get
            {
                if (placemarks.Count > 0)
                    return false;

                foreach (Folder folder in folders)
                    if (!folder.IsEmpty)
                        return false;

                return true;
            }
        }
    }
}
