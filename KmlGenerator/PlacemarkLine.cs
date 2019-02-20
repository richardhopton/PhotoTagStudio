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
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace Schroeter.KmlGenerator
{
    public class PlacemarkLine : PlacemarkBase
    {
        private Coordinates coordinates;
        private int lineWidth = 1;
        private Color lineColor = Color.Red;

        public PlacemarkLine()
        {
            coordinates = new Coordinates();
        }

        #region properties
        public Coordinates Coordinates
        {
            get { return coordinates; }
        }

        public int LineWidth
        {
            get { return lineWidth; }
            set { lineWidth = value; }
        }

        public Color LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }
        }
        #endregion

        public override XmlElement CreateXml(bool forArchiv)
        {
            Stream s = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Schroeter.KmlGenerator.Templates.PlacemarkLine.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(s);
            s.Close();

            XmlElement root = (XmlElement)doc.ChildNodes[1];

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ns", "http://earth.google.com/kml/2.0");

            root.SelectSingleNode("/ns:Placemark/ns:name", nsmgr).InnerText = name;
            root.SelectSingleNode("/ns:Placemark/ns:Style/ns:LineStyle/ns:width", nsmgr).InnerText = lineWidth.ToString();
            root.SelectSingleNode("/ns:Placemark/ns:Style/ns:LineStyle/ns:color", nsmgr).InnerText = ToColorString(lineColor);
            root.SelectSingleNode("/ns:Placemark/ns:description", nsmgr).AppendChild(doc.CreateCDataSection(description));

            root.SelectSingleNode("/ns:Placemark/ns:LineString/ns:coordinates", nsmgr).InnerText = MakeCoordinates();            

            return root;
        }

        private static string ToColorString(Color color)
        {
            return string.Format("{0:x2}{1:x2}{2:x2}{3:x2}", color.A, color.B, color.G, color.R);
        }

        private string MakeCoordinates()
        {
            //coordinates.RemovePeeks();
            coordinates.RemoveDuplicates();
            
            StringBuilder sb = new StringBuilder();
            
            foreach(Coordinate c in coordinates)
            {
                sb.Append(XmlConvert.ToString(c.Longitude));
                sb.Append(",");
                sb.Append(XmlConvert.ToString(c.Latitude));
                sb.Append(",");
                sb.Append(XmlConvert.ToString(c.Attitude));
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}
