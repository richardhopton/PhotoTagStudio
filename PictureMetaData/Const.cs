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

namespace Schroeter.Photo
{
    public class Const
    {
        private static Dictionary<string, TagGroupDescription> Groups;
        private static Dictionary<string, TagDescription> Tags;

        static Const()
        {
            CreateGroupList();
            CreateTagList();
        }

        private static void CreateGroupList()
        {
            Groups = new Dictionary<string, TagGroupDescription>();

            addToGroupDictionary("Image");
            addToGroupDictionary("Photo");
            addToGroupDictionary("GPSInfo");
            addToGroupDictionary("Iop");
        }

        private static void addToGroupDictionary(string name)
        {
            addToGroupDictionary(name, name);
        }
        private static void addToGroupDictionary(string name, string description)
        {
            TagGroupDescription tg = new TagGroupDescription("Exif." + name, description);
            Groups.Add(tg.Name, tg);
        }

        private static void CreateTagList()
        {
            Tags = new Dictionary<string, TagDescription>();

            TagGroupDescription g;

            g = Groups["Exif.Image"];
            addToDictionary(g, 0x0100, "ImageWidth", "Image width", typeof(long));
            addToDictionary(g, 0x0101, "ImageLength", "Image height", typeof(long));
            addToDictionary(g, 0x0102, "BitsPerSample", "Number of bits per component", typeof(short));
            addToDictionary(g, 0x0103, "Compression", "Compression scheme", typeof(short), ExifFormating.print0x0103); 
            addToDictionary(g, 0x0106, "PhotometricInterpretation", "Pixel composition", typeof(short), ExifFormating.print0x0106); 
            addToDictionary(g, 0x010e, "ImageDescription", "Image title", typeof(string));
            addToDictionary(g, 0x010f, "Make", "Manufacturer of image input equipment", typeof(string));
            addToDictionary(g, 0x0110, "Model", "Model of image input equipment", typeof(string));
            addToDictionary(g, 0x0111, "StripOffsets", "Image data location", typeof(long));
            addToDictionary(g, 0x0112, "Orientation", "Orientation of image", typeof(short), ExifFormating.print0x0112); 
            addToDictionary(g, 0x0115, "SamplesPerPixel", "Number of components", typeof(short));
            addToDictionary(g, 0x0116, "RowsPerStrip", "Number of rows per strip", typeof(long));
            addToDictionary(g, 0x0117, "StripByteCounts", "Bytes per compressed strip", typeof(long));
            addToDictionary(g, 0x011a, "XResolution", "Image resolution in width direction", typeof(double)); 
            addToDictionary(g, 0x011b, "YResolution", "Image resolution in height direction", typeof(double)); 
            addToDictionary(g, 0x011c, "PlanarConfiguration", "Image data arrangement", typeof(short));
            addToDictionary(g, 0x0128, "ResolutionUnit", "Unit of X and Y resolution", typeof(short), ExifFormating.printUnit); 
            addToDictionary(g, 0x012d, "TransferFunction", "Transfer function", typeof(short));
            addToDictionary(g, 0x0131, "Software", "Software used", typeof(string));
            addToDictionary(g, 0x0132, "DateTime", "File change date and time", typeof(string));
            addToDictionary(g, 0x013b, "Artist", "Person who created the image", typeof(string));
            addToDictionary(g, 0x013e, "WhitePoint", "White point chromaticity", typeof(double));
            addToDictionary(g, 0x013f, "PrimaryChromaticities", "Chromaticities of primaries", typeof(double));
            addToDictionary(g, 0x0201, "JPEGInterchangeFormat", "Offset to JPEG SOI", typeof(long));
            addToDictionary(g, 0x0202, "JPEGInterchangeFormatLength", "Bytes of JPEG data", typeof(long));
            addToDictionary(g, 0x0211, "YCbCrCoefficients", "Color space transformation matrix coefficients", typeof(double));
            addToDictionary(g, 0x0212, "YCbCrSubSampling", "Subsampling ratio of Y to C", typeof(short));
            addToDictionary(g, 0x0213, "YCbCrPositioning", "Y and C positioning", typeof(short), ExifFormating.print0x0213); 
            addToDictionary(g, 0x0214, "ReferenceBlackWhite", "Pair of black and white reference values", typeof(double));
            addToDictionary(g, 0x8298, "Copyright", "Copyright holder", typeof(string));
            addToDictionary(g, 0x8769, "ExifTag", "Exif IFD Pointer", typeof(long));
            addToDictionary(g, 0x8825, "GPSTag", "GPSInfo IFD Pointer", typeof(long));

            g = Groups["Exif.Photo"];
            addToDictionary(g, 0x829a, "ExposureTime", "Exposure time", typeof(double), ExifFormating.print0x829a);
            addToDictionary(g, 0x829d, "FNumber", "F number", typeof(double) , ExifFormating.print0x829d); 
            addToDictionary(g, 0x8822, "ExposureProgram", "Exposure program", typeof(short), ExifFormating.print0x8822); 
            addToDictionary(g, 0x8824, "SpectralSensitivity", "Spectral sensitivity", typeof(string));
            addToDictionary(g, 0x8827, "ISOSpeedRatings", "ISO speed ratings", typeof(short));
            addToDictionary(g, 0x8828, "OECF", "Optoelectric coefficient", null);
            addToDictionary(g, 0x9000, "ExifVersion", "Exif Version", null);
            addToDictionary(g, 0x9003, "DateTimeOriginal", "Date and time original image was generated", typeof(string));
            addToDictionary(g, 0x9004, "DateTimeDigitized", "Date and time image was made digital data", typeof(string));
            addToDictionary(g, 0x9101, "ComponentsConfiguration", "Meaning of each component", null, ExifFormating.print0x9101);
            addToDictionary(g, 0x9102, "CompressedBitsPerPixel", "Image compression mode", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0x9201, "ShutterSpeedValue", "Shutter speed", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0x9202, "ApertureValue", "Aperture", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0x9203, "BrightnessValue", "Brightness", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0x9204, "ExposureBiasValue", "Exposure bias", typeof(double),ExifFormating.print0x9204);
            addToDictionary(g, 0x9205, "MaxApertureValue", "Maximum lens aperture", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0x9206, "SubjectDistance", "Subject distance", typeof(double), ExifFormating.print0x9206); 
            addToDictionary(g, 0x9207, "MeteringMode", "Metering mode", typeof(short), ExifFormating.print0x9207);
            addToDictionary(g, 0x9208, "LightSource", "Light source", typeof(short), ExifFormating.print0x9208); 
            addToDictionary(g, 0x9209, "Flash", "Flash", typeof(short), ExifFormating.print0x9209);
            addToDictionary(g, 0x920a, "FocalLength", "Lens focal length", typeof(double),ExifFormating.print0x920a); 
            addToDictionary(g, 0x9214, "SubjectArea", "Subject area", typeof(short));
            addToDictionary(g, 0x927c, "MakerNote", "Manufacturer notes", null);
            addToDictionary(g, 0x9286, "UserComment", "User comments", typeof(string)); 
            addToDictionary(g, 0x9290, "SubSecTime", "DateTime subseconds", typeof(string));
            addToDictionary(g, 0x9291, "SubSecTimeOriginal", "DateTimeOriginal subseconds", typeof(string));
            addToDictionary(g, 0x9292, "SubSecTimeDigitized", "DateTimeDigitized subseconds", typeof(string));
            addToDictionary(g, 0xa000, "FlashpixVersion", "Supported Flashpix version", null);
            addToDictionary(g, 0xa001, "ColorSpace", "Color space information", typeof(short), ExifFormating.print0xa001); 
            addToDictionary(g, 0xa002, "PixelXDimension", "Valid image width", typeof(long));
            addToDictionary(g, 0xa003, "PixelYDimension", "Valid image height", typeof(long));
            addToDictionary(g, 0xa004, "RelatedSoundFile", "Related audio file", typeof(string));
            addToDictionary(g, 0xa005, "InteroperabilityTag", "Interoperability IFD Pointer", typeof(long));
            addToDictionary(g, 0xa20b, "FlashEnergy", "Flash energy", typeof(double));
            addToDictionary(g, 0xa20c, "SpatialFrequencyResponse", "Spatial frequency response", null);
            addToDictionary(g, 0xa20e, "FocalPlaneXResolution", "Focal plane X resolution", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0xa20f, "FocalPlaneYResolution", "Focal plane Y resolution", typeof(double), ExifFormating.printFloat); 
            addToDictionary(g, 0xa210, "FocalPlaneResolutionUnit", "Focal plane resolution unit", typeof(short),ExifFormating.printUnit); 
            addToDictionary(g, 0xa214, "SubjectLocation", "Subject location", typeof(short));
            addToDictionary(g, 0xa215, "ExposureIndex", "Exposure index", typeof(double));
            addToDictionary(g, 0xa217, "SensingMethod", "Sensing method", typeof(short), ExifFormating.print0xa217); 
            addToDictionary(g, 0xa300, "FileSource", "File source", null, ExifFormating.print0xa300); 
            addToDictionary(g, 0xa301, "SceneType", "Scene type", null, ExifFormating.print0xa301); 
            addToDictionary(g, 0xa302, "CFAPattern", "CFA pattern", null);
            addToDictionary(g, 0xa401, "CustomRendered", "Custom image processing", typeof(short));
            addToDictionary(g, 0xa402, "ExposureMode", "Exposure mode", typeof(short), ExifFormating.print0xa402); 
            addToDictionary(g, 0xa403, "WhiteBalance", "White balance", typeof(short), ExifFormating.print0xa403);
            addToDictionary(g, 0xa404, "DigitalZoomRatio", "Digital zoom ratio", typeof(double), ExifFormating.print0xa404); 
            addToDictionary(g, 0xa405, "FocalLengthIn35mmFilm", "Focal length in 35 mm film", typeof(short), ExifFormating.print0xa405); 
            addToDictionary(g, 0xa406, "SceneCaptureType", "Scene capture type", typeof(short), ExifFormating.print0xa406); ;
            addToDictionary(g, 0xa407, "GainControl", "Gain control", typeof(double), ExifFormating.print0xa407);
            addToDictionary(g, 0xa408, "Contrast", "Contrast", typeof(short), ExifFormating.print0xa408); 
            addToDictionary(g, 0xa409, "Saturation", "Saturation", typeof(short), ExifFormating.print0xa409); 
            addToDictionary(g, 0xa40a, "Sharpness", "Sharpness", typeof(short), ExifFormating.print0xa40a); 
            addToDictionary(g, 0xa40b, "DeviceSettingDescription", "Device settings description", null);
            addToDictionary(g, 0xa40c, "SubjectDistanceRange", "Subject distance range", typeof(short), ExifFormating.print0xa40c); 
            addToDictionary(g, 0xa420, "ImageUniqueID", "Unique image ID", typeof(string));

            g = Groups["Exif.GPSInfo"];
            addToDictionary(g, 0x0000, "GPSVersionID", "GPS tag version", typeof(byte));
            addToDictionary(g, 0x0001, "GPSLatitudeRef", "North or South Latitude", typeof(string));
            addToDictionary(g, 0x0002, "GPSLatitude", "Latitude", typeof(double));
            addToDictionary(g, 0x0003, "GPSLongitudeRef", "East or West Longitude", typeof(string));
            addToDictionary(g, 0x0004, "GPSLongitude", "Longitude", typeof(double));
            addToDictionary(g, 0x0005, "GPSAltitudeRef", "Altitude reference", typeof(byte));
            addToDictionary(g, 0x0006, "GPSAltitude", "Altitude", typeof(double));
            addToDictionary(g, 0x0007, "GPSTimeStamp", "GPS time (atomic clock)", typeof(double));
            addToDictionary(g, 0x0008, "GPSSatellites", "GPS satellites used for measurement", typeof(string));
            addToDictionary(g, 0x0009, "GPSStatus", "GPS receiver status", typeof(string));
            addToDictionary(g, 0x000a, "GPSMeasureMode", "GPS measurement mode", typeof(string));
            addToDictionary(g, 0x000b, "GPSDOP", "Measurement precision", typeof(double));
            addToDictionary(g, 0x000c, "GPSSpeedRef", "Speed unit", typeof(string));
            addToDictionary(g, 0x000d, "GPSSpeed", "Speed of GPS receiver", typeof(double));
            addToDictionary(g, 0x000e, "GPSTrackRef", "Reference for direction of movement", typeof(string));
            addToDictionary(g, 0x000f, "GPSTrack", "Direction of movement", typeof(double));
            addToDictionary(g, 0x0010, "GPSImgDirectionRef", "Reference for direction of image", typeof(string));
            addToDictionary(g, 0x0011, "GPSImgDirection", "Direction of image", typeof(double));
            addToDictionary(g, 0x0012, "GPSMapDatum", "Geodetic survey data used", typeof(string));
            addToDictionary(g, 0x0013, "GPSDestLatitudeRef", "Reference for latitude of destination", typeof(string));
            addToDictionary(g, 0x0014, "GPSDestLatitude", "Latitude of destination", typeof(double));
            addToDictionary(g, 0x0015, "GPSDestLongitudeRef", "Reference for longitude of destination", typeof(string));
            addToDictionary(g, 0x0016, "GPSDestLongitude", "Longitude of destination", typeof(double));
            addToDictionary(g, 0x0017, "GPSDestBearingRef", "Reference for bearing of destination", typeof(string));
            addToDictionary(g, 0x0018, "GPSDestBearing", "Bearing of destination", typeof(double));
            addToDictionary(g, 0x0019, "GPSDestDistanceRef", "Reference for distance to destination", typeof(string));
            addToDictionary(g, 0x001a, "GPSDestDistance", "Distance to destination", typeof(double));
            addToDictionary(g, 0x001b, "GPSProcessingMethod", "Name of GPS processing method", null);
            addToDictionary(g, 0x001c, "GPSAreaInformation", "Name of GPS area", null);
            addToDictionary(g, 0x001d, "GPSDateStamp", "GPS date", typeof(string));
            addToDictionary(g, 0x001e, "GPSDifferential", "GPS differential correction", typeof(short));

            g = Groups["Exif.Iop"];
            addToDictionary(g, 0x0001, "InteroperabilityIndex", "Interoperability Identification", typeof(string));
            addToDictionary(g, 0x0002, "InteroperabilityVersion", "Interoperability version", null);
            addToDictionary(g, 0x1000, "RelatedImageFileFormat", "File format of image file", typeof(string));
            addToDictionary(g, 0x1001, "RelatedImageWidth", "Image width", typeof(long));
            addToDictionary(g, 0x1002, "RelatedImageLength", "Image height", typeof(long));

        }
        private static void addToDictionary(TagGroupDescription group, int key, string name, string description, Type datatype)
        {
            TagDescription td = new TagDescription(group, name, description, datatype, key);
            Tags.Add(td.Fullname, td);
        }
        private static void addToDictionary(TagGroupDescription group, int key, string name, string description, Type datatype, FormatMethod formatMethod)
        {
            TagDescription td = new TagDescription(group, name, description, datatype, key,formatMethod);
            Tags.Add(td.Fullname, td);
        }

        public static TagDescription GetTagDescription(string name)
        {
            if (!Tags.ContainsKey(name))
                return null;
            return Tags[name];
        }
        public static TagGroupDescription GetTagGroupDescription(string name)
        {
            if (!Groups.ContainsKey(name))
                return null;
            return Groups[name];
        }
    }
}