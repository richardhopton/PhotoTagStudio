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
using Schroeter.Photo;

namespace Schroeter.Photo.DefaultPlugins
{
    [PluginDescription("Tag the lens for Anja and Benjamin","Adds a keyword for the lens of a KonicaMinolta DSLR camera based on the LensId")]
    public class LensPlugin : IPhotoTagStudioTaggingPlugin
    {
        private const string LENS_ID_TAG = "Exif.Minolta.LensID";

        public bool ProcessFile(PictureMetaData pmd)
        {
            string LensID;
            double FocalLength;
            double MaxAperture;
            try
            {
                LensID = pmd.getStringAttribute(LENS_ID_TAG);
                FocalLength = toFloat(pmd.getStringAttribute(Exif.Photo.FOCALLENGTH));
                //MaxAperture = toFloat(pmd.getStringAttribute(Exif.Photo.MAXAPERTUREVALUE));
            }
            catch
            {
                return false;
            }

            string lens = "";
            switch(LensID)
            {
                case "25501":
                case "26131":
                    lens = "Minolta AF 50mm F1.7";
                    break;
                case "25601":
                    lens = "Minolta AF 100-200mm F4.5";
                    break;
                case "128":
                    lens = "Tamron AF 28-200mm F3.8-5.6";
                    break;
                case "65535":
                    lens = "Pentacon MF 200mm F4";
                    break;
                case "24":
                    lens = "Sigma AF 17-70mm F2.8-4.5";

                    if (FocalLength > 70)
                        lens = "Minolta AF 24-105mm F3.5-4.5 (D)";
                    break;                    
            }
           
//            Console.WriteLine(string.Format("{3}: {0} - {1} - {2}",LensID,FocalLength,MaxAperture,lens));

            if (lens == "")
                return false;
           
            if (pmd.ListKeyword().Contains(lens))
                return false;

            pmd.AddKeyword(lens);
       
            return true;
        }

        private double toFloat(string value)
        {
            try
            {
                long first = 0;
                long second = 0;

                string[] parts = value.Split('/');
                if (parts.Length >= 2)
                {
                    first = long.Parse(parts[0]);
                    second = long.Parse(parts[1]);
                }

                if (second != 0)
                {
                    double d = first;
                    d /= second;
                    return d;
                }
            }
            catch
            {
                return 0;                
            }

            return 0;
        }
    }
}
