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
    public class Folder
    {
        private string name;
        private List<PlacemarkBase> placemarks;
        private List<Folder> folders;

        public Folder()
        {
            placemarks = new List<PlacemarkBase>();
            folders = new List<Folder>();
        } 
        
        public Folder(string name) : this()
        {
            this.name = name;
        }
        
        public XmlElement CreateXml(bool forArchiv)
        {
            Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Schroeter.KmlGenerator.Templates.Folder.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(s);
            s.Close();

            XmlElement root = (XmlElement)doc.ChildNodes[1];

            XmlNamespaceManager nsmgr = new XmlNamespaceManager( doc.NameTable );
            nsmgr.AddNamespace("ns","http://earth.google.com/kml/2.0");
            
            root.SelectSingleNode("/ns:Folder/ns:name",nsmgr).InnerText = name;

            foreach (PlacemarkBase p in placemarks)
                root.AppendChild(doc.ImportNode(p.CreateXml(forArchiv), true));
            foreach (Folder f in folders)
                root.AppendChild(doc.ImportNode(f.CreateXml(forArchiv), true));

            return root;
        }
        
        #region properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<PlacemarkBase> Placemarks
        {
            get { return placemarks; }
        }

        public List<Folder> Folders
        {
            get { return folders; }
        }

        #endregion

        public void GetPlacemarks(List<PlacemarkBase> allPlacemarks)
        {
            allPlacemarks.AddRange(placemarks);
            
            foreach(Folder f in folders)
                f.GetPlacemarks(allPlacemarks);
        }

        public bool IsEmpty
        {
            get
            {
                if ( placemarks.Count > 0 )
                    return false;

                foreach (Folder folder in folders)
                    if ( !folder.IsEmpty )
                        return false;
                
                return true;
            }
        }
    }
}
