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
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;

namespace Schroeter.KmlGenerator
{
    public class KmzArchiv
    {
        private KmlDocument kmlDocument;

        public KmzArchiv(KmlDocument kml)
        {
            this.kmlDocument = kml;
        }
        
        public void Create(string filename)
        {
            ZipOutputStream z = new ZipOutputStream(File.Create(filename));
            z.SetLevel(2);

            ZipEntry entry = new ZipEntry("doc.kml");
            z.PutNextEntry(entry);
            XmlDocument doc = kmlDocument.CreateXml(true);
            doc.PreserveWhitespace = true;
            MemoryStream ms = new MemoryStream();
            TextWriter tw = new StreamWriter(ms, new UTF8Encoding(false));
            doc.Save(tw);
            ms.Position = 0;
            byte[] b = new byte[ms.Length];
            ms.Read(b, 0, (int)ms.Length);
            z.Write(b, 0, (int)ms.Length);
            ms.Close();

            foreach(PlacemarkBase pb in GetPlacemarks())
            {
                Placemark p = pb as Placemark;
                if (p != null)
                {
                    byte[] buffer;
                    if (p.ImageFile != null)
                    {
                        FileStream fs = p.ImageFile.OpenRead();
                        buffer = new byte[fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                    }
                    else
                    {
                        MemoryStream ims = new MemoryStream();
                        p.Image.Save(ims, ImageFormat.Jpeg);
                        buffer = new byte[ims.Length];
                        ims.Position = 0;
                        ims.Read(buffer, 0, buffer.Length);
                    }

                    entry = new ZipEntry("images/" + p.Filename);
                    z.PutNextEntry(entry);
                    z.Write(buffer, 0, buffer.Length);
                }
            }
            
            z.Finish();
            z.Close();
        }

        public List<PlacemarkBase> GetPlacemarks()
        {
            List<PlacemarkBase> p = new List<PlacemarkBase>();            
            kmlDocument.GetPlacemarks(p);
            return p;
        }
        
        #region properties
        public KmlDocument KmlDocument
        {
            get { return kmlDocument; }
        }
        #endregion
    }
}
