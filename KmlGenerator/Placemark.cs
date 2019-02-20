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

using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace Schroeter.KmlGenerator
{
    public class Placemark : PlacemarkBase
    {
        private double longitude;
        private double latitude;
        private FileInfo imageFile;
        private string filename;
        private Image image;
        private int range = 160;
        private int tilt;
        private int heading;

        public override XmlElement CreateXml(bool forArchiv)
        {
            Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Schroeter.KmlGenerator.Templates.Placemark.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(s);            
            s.Close();

            XmlElement root = (XmlElement)doc.ChildNodes[1];

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", "http://earth.google.com/kml/2.0");

            root.SelectSingleNode("/ns:Placemark/ns:name",nsmgr).InnerText = name;
            root.SelectSingleNode("/ns:Placemark/ns:LookAt/ns:longitude", nsmgr).InnerText = XmlConvert.ToString(longitude);
            root.SelectSingleNode("/ns:Placemark/ns:LookAt/ns:latitude", nsmgr).InnerText = XmlConvert.ToString(latitude);
            root.SelectSingleNode("/ns:Placemark/ns:LookAt/ns:tilt", nsmgr).InnerText = XmlConvert.ToString(tilt);
            root.SelectSingleNode("/ns:Placemark/ns:LookAt/ns:heading", nsmgr).InnerText = XmlConvert.ToString(heading);
            root.SelectSingleNode("/ns:Placemark/ns:LookAt/ns:range", nsmgr).InnerText = XmlConvert.ToString(range);
            root.SelectSingleNode("/ns:Placemark/ns:Style/ns:IconStyle/ns:Icon/ns:href", nsmgr).InnerText = MakeImagePath(forArchiv);

            string coor = XmlConvert.ToString(longitude) + "," + XmlConvert.ToString(latitude);
            root.SelectSingleNode("/ns:Placemark/ns:Point/ns:coordinates", nsmgr).InnerText = coor;

            root.SelectSingleNode("/ns:Placemark/ns:description", nsmgr).AppendChild(doc.CreateCDataSection(MakeDescription(forArchiv)));

            
            return root;
        }

        private string MakeImagePath(bool forArchiv)
        {
            string s = forArchiv || imageFile == null ? "images/" + filename : imageFile.FullName;
            return s.ToLower();
        }
        
        private string MakeDescription(bool forArchiv)
        {
            string s = "{1}<br><br><img src=\"{2}\">";
            return String.Format(s, name, description, MakeImagePath(forArchiv));

        }

        public void SetImage(string imgName, Image img)
        {
            this.filename = imgName;
            this.image = img;
            this.imageFile = null;
        }
        
        public void SetImage(FileInfo file)
        {
            this.image = null;
            this.imageFile = file;
            this.filename = file.Name;
        }
        
        #region properties

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }
        public FileInfo ImageFile
        {
            get { return imageFile; }
        }
        public string Filename
        {
            get { return filename; }
        }
        public Image Image
        {
            get { return image; }
        }
        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        public int Tilt
        {
            get { return tilt; }
            set { tilt = value; }
        }

        public int Heading
        {
            get { return heading; }
            set { heading = value; }
        }
        #endregion
    }
}
