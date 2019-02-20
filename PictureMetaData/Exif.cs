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

namespace Schroeter.Photo
{
    public class Exif
    {
        public class Image
        {

            public const string IMAGEWIDTH = "Exif.Image.ImageWidth";
            public const string IMAGELENGTH = "Exif.Image.ImageLength";
            public const string BITSPERSAMPLE = "Exif.Image.BitsPerSample";
            public const string COMPRESSION = "Exif.Image.Compression";
            public const string PHOTOMETRICINTERPRETATION = "Exif.Image.PhotometricInterpretation";
            public const string IMAGEDESCRIPTION = "Exif.Image.ImageDescription";
            public const string MAKE = "Exif.Image.Make";
            public const string MODEL = "Exif.Image.Model";
            public const string STRIPOFFSETS = "Exif.Image.StripOffsets";
            public const string ORIENTATION = "Exif.Image.Orientation";
            public const string SAMPLESPERPIXEL = "Exif.Image.SamplesPerPixel";
            public const string ROWSPERSTRIP = "Exif.Image.RowsPerStrip";
            public const string STRIPBYTECOUNTS = "Exif.Image.StripByteCounts";
            public const string XRESOLUTION = "Exif.Image.XResolution";
            public const string YRESOLUTION = "Exif.Image.YResolution";
            public const string PLANARCONFIGURATION = "Exif.Image.PlanarConfiguration";
            public const string RESOLUTIONUNIT = "Exif.Image.ResolutionUnit";
            public const string TRANSFERFUNCTION = "Exif.Image.TransferFunction";
            public const string SOFTWARE = "Exif.Image.Software";
            public const string DATETIME = "Exif.Image.DateTime";
            public const string ARTIST = "Exif.Image.Artist";
            public const string WHITEPOINT = "Exif.Image.WhitePoint";
            public const string PRIMARYCHROMATICITIES = "Exif.Image.PrimaryChromaticities";
            public const string JPEGINTERCHANGEFORMAT = "Exif.Image.JPEGInterchangeFormat";
            public const string JPEGINTERCHANGEFORMATLENGTH = "Exif.Image.JPEGInterchangeFormatLength";
            public const string YCBCRCOEFFICIENTS = "Exif.Image.YCbCrCoefficients";
            public const string YCBCRSUBSAMPLING = "Exif.Image.YCbCrSubSampling";
            public const string YCBCRPOSITIONING = "Exif.Image.YCbCrPositioning";
            public const string REFERENCEBLACKWHITE = "Exif.Image.ReferenceBlackWhite";
            public const string COPYRIGHT = "Exif.Image.Copyright";
            public const string EXIFTAG = "Exif.Image.ExifTag";
            public const string GPSTAG = "Exif.Image.GPSTag";
        }

        public class Photo
        {
            public const string EXPOSURETIME = "Exif.Photo.ExposureTime";
            public const string FNUMBER = "Exif.Photo.FNumber";
            public const string EXPOSUREPROGRAM = "Exif.Photo.ExposureProgram";
            public const string SPECTRALSENSITIVITY = "Exif.Photo.SpectralSensitivity";
            public const string ISOSPEEDRATINGS = "Exif.Photo.ISOSpeedRatings";
            public const string OECF = "Exif.Photo.OECF";
            public const string EXIFVERSION = "Exif.Photo.ExifVersion";
            public const string DATETIMEORIGINAL = "Exif.Photo.DateTimeOriginal";
            public const string DATETIMEDIGITIZED = "Exif.Photo.DateTimeDigitized";
            public const string COMPONENTSCONFIGURATION = "Exif.Photo.ComponentsConfiguration";
            public const string COMPRESSEDBITSPERPIXEL = "Exif.Photo.CompressedBitsPerPixel";
            public const string SHUTTERSPEEDVALUE = "Exif.Photo.ShutterSpeedValue";
            public const string APERTUREVALUE = "Exif.Photo.ApertureValue";
            public const string BRIGHTNESSVALUE = "Exif.Photo.BrightnessValue";
            public const string EXPOSUREBIASVALUE = "Exif.Photo.ExposureBiasValue";
            public const string MAXAPERTUREVALUE = "Exif.Photo.MaxApertureValue";
            public const string SUBJECTDISTANCE = "Exif.Photo.SubjectDistance";
            public const string METERINGMODE = "Exif.Photo.MeteringMode";
            public const string LIGHTSOURCE = "Exif.Photo.LightSource";
            public const string FLASH = "Exif.Photo.Flash";
            public const string FOCALLENGTH = "Exif.Photo.FocalLength";
            public const string SUBJECTAREA = "Exif.Photo.SubjectArea";
            public const string MAKERNOTE = "Exif.Photo.MakerNote";
            public const string USERCOMMENT = "Exif.Photo.UserComment";
            public const string SUBSECTIME = "Exif.Photo.SubSecTime";
            public const string SUBSECTIMEORIGINAL = "Exif.Photo.SubSecTimeOriginal";
            public const string SUBSECTIMEDIGITIZED = "Exif.Photo.SubSecTimeDigitized";
            public const string FLASHPIXVERSION = "Exif.Photo.FlashpixVersion";
            public const string COLORSPACE = "Exif.Photo.ColorSpace";
            public const string PIXELXDIMENSION = "Exif.Photo.PixelXDimension";
            public const string PIXELYDIMENSION = "Exif.Photo.PixelYDimension";
            public const string RELATEDSOUNDFILE = "Exif.Photo.RelatedSoundFile";
            public const string INTEROPERABILITYTAG = "Exif.Photo.InteroperabilityTag";
            public const string FLASHENERGY = "Exif.Photo.FlashEnergy";
            public const string SPATIALFREQUENCYRESPONSE = "Exif.Photo.SpatialFrequencyResponse";
            public const string FOCALPLANEXRESOLUTION = "Exif.Photo.FocalPlaneXResolution";
            public const string FOCALPLANEYRESOLUTION = "Exif.Photo.FocalPlaneYResolution";
            public const string FOCALPLANERESOLUTIONUNIT = "Exif.Photo.FocalPlaneResolutionUnit";
            public const string SUBJECTLOCATION = "Exif.Photo.SubjectLocation";
            public const string EXPOSUREINDEX = "Exif.Photo.ExposureIndex";
            public const string SENSINGMETHOD = "Exif.Photo.SensingMethod";
            public const string FILESOURCE = "Exif.Photo.FileSource";
            public const string SCENETYPE = "Exif.Photo.SceneType";
            public const string CFAPATTERN = "Exif.Photo.CFAPattern";
            public const string CUSTOMRENDERED = "Exif.Photo.CustomRendered";
            public const string EXPOSUREMODE = "Exif.Photo.ExposureMode";
            public const string WHITEBALANCE = "Exif.Photo.WhiteBalance";
            public const string DIGITALZOOMRATIO = "Exif.Photo.DigitalZoomRatio";
            public const string FOCALLENGTHIN35MMFILM = "Exif.Photo.FocalLengthIn35mmFilm";
            public const string SCENECAPTURETYPE = "Exif.Photo.SceneCaptureType";
            public const string GAINCONTROL = "Exif.Photo.GainControl";
            public const string CONTRAST = "Exif.Photo.Contrast";
            public const string SATURATION = "Exif.Photo.Saturation";
            public const string SHARPNESS = "Exif.Photo.Sharpness";
            public const string DEVICESETTINGDESCRIPTION = "Exif.Photo.DeviceSettingDescription";
            public const string SUBJECTDISTANCERANGE = "Exif.Photo.SubjectDistanceRange";
            public const string IMAGEUNIQUEID = "Exif.Photo.ImageUniqueID";
        }

        public class GpsInfo
        {
            public const string GPSVERSIONID = "Exif.GPSInfo.GPSVersionID";
            public const string GPSLATITUDEREF = "Exif.GPSInfo.GPSLatitudeRef";
            public const string GPSLATITUDE = "Exif.GPSInfo.GPSLatitude";
            public const string GPSLONGITUDEREF = "Exif.GPSInfo.GPSLongitudeRef";
            public const string GPSLONGITUDE = "Exif.GPSInfo.GPSLongitude";
            public const string GPSALTITUDEREF = "Exif.GPSInfo.GPSAltitudeRef";
            public const string GPSALTITUDE = "Exif.GPSInfo.GPSAltitude";
            public const string GPSTIMESTAMP = "Exif.GPSInfo.GPSTimeStamp";
            public const string GPSSATELLITES = "Exif.GPSInfo.GPSSatellites";
            public const string GPSSTATUS = "Exif.GPSInfo.GPSStatus";
            public const string GPSMEASUREMODE = "Exif.GPSInfo.GPSMeasureMode";
            public const string GPSDOP = "Exif.GPSInfo.GPSDOP";
            public const string GPSSPEEDREF = "Exif.GPSInfo.GPSSpeedRef";
            public const string GPSSPEED = "Exif.GPSInfo.GPSSpeed";
            public const string GPSTRACKREF = "Exif.GPSInfo.GPSTrackRef";
            public const string GPSTRACK = "Exif.GPSInfo.GPSTrack";
            public const string GPSIMGDIRECTIONREF = "Exif.GPSInfo.GPSImgDirectionRef";
            public const string GPSIMGDIRECTION = "Exif.GPSInfo.GPSImgDirection";
            public const string GPSMAPDATUM = "Exif.GPSInfo.GPSMapDatum";
            public const string GPSDESTLATITUDEREF = "Exif.GPSInfo.GPSDestLatitudeRef";
            public const string GPSDESTLATITUDE = "Exif.GPSInfo.GPSDestLatitude";
            public const string GPSDESTLONGITUDEREF = "Exif.GPSInfo.GPSDestLongitudeRef";
            public const string GPSDESTLONGITUDE = "Exif.GPSInfo.GPSDestLongitude";
            public const string GPSDESTBEARINGREF = "Exif.GPSInfo.GPSDestBearingRef";
            public const string GPSDESTBEARING = "Exif.GPSInfo.GPSDestBearing";
            public const string GPSDESTDISTANCEREF = "Exif.GPSInfo.GPSDestDistanceRef";
            public const string GPSDESTDISTANCE = "Exif.GPSInfo.GPSDestDistance";
            public const string GPSPROCESSINGMETHOD = "Exif.GPSInfo.GPSProcessingMethod";
            public const string GPSAREAINFORMATION = "Exif.GPSInfo.GPSAreaInformation";
            public const string GPSDATESTAMP = "Exif.GPSInfo.GPSDateStamp";
            public const string GPSDIFFERENTIAL = "Exif.GPSInfo.GPSDifferential";
        }

        public class Iop
        {
            public const string INTEROPERABILITYINDEX = "Exif.Iop.InteroperabilityIndex";
            public const string INTEROPERABILITYVERSION = "Exif.Iop.InteroperabilityVersion";
            public const string RELATEDIMAGEFILEFORMAT = "Exif.Iop.RelatedImageFileFormat";
            public const string RELATEDIMAGEWIDTH = "Exif.Iop.RelatedImageWidth";
            public const string RELATEDIMAGELENGTH = "Exif.Iop.RelatedImageLength";
        }

        public class Thumbnail
        {
            public const string ORIENTATION = "Exif.Thumbnail.Orientation";
        }
    }
}
