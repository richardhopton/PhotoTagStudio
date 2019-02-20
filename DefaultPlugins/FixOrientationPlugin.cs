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

namespace Schroeter.Photo.DefaultPlugins
{
    // Some cameras (e.g. Konica Minolta Dynax 5D) write different values to the 
    // Exif.Image.Orientation and Exif.Thumbnail.Orientation tags. 
    //
    // flickr.com uses the wrong Thumbnail tag, too. 
    // With this plugin  all Exif.Thumbnail.Orientation will be removed
    [PluginDescription("Fix orientation for flickr!", "Removes the Exif.Thumbnail.Orientation if it has not the same value as Exif.Image.Orientation.")]
    public class FixOrientationPlugin : IPhotoTagStudioTaggingPlugin
    {
        public bool ProcessFile(PictureMetaData pmd)
        {
            if (pmd.ExifThumbnailOrientation != pmd.ExifImageOrientation)
            {
                pmd.RemoveExifThumbnailOrientation();
                return true;
            }

            return false;
        }
    }
}
