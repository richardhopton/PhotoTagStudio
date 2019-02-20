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
    public class Iptc
    {
        // 1x date
        public const string RELEASE_DATE = "Iptc.Application2.ReleaseDate";
        public const string EXPIRATION_DATE = "Iptc.Application2.ExpirationDate";
        public const string DATE_CREATED = "Iptc.Application2.DateCreated";
        public const string DIGITIZATION_DATE = "Iptc.Application2.DigitizationDate";
        // 1x time
        public const string RELEASE_TIME = "Iptc.Application2.ReleaseTime";
        public const string EXPIRATION_TIME = "Iptc.Application2.ExpirationTime";
        public const string TIME_CREATED = "Iptc.Application2.TimeCreated";
        public const string DIGITIZATION_TIME = "Iptc.Application2.DigitizationTime";

        // 1x string
        public const string OBJECT_TYPE = "Iptc.Application2.ObjectType";
        public const string OBJECT_NAME = "Iptc.Application2.ObjectName";
        public const string EDIT_STATUS = "Iptc.Application2.EditStatus";
        public const string EDITORIAL_UPDATE = "Iptc.Application2.EditorialUpdate";
        public const string URGENCY = "Iptc.Application2.Urgency";
        public const string CATEGORY = "Iptc.Application2.Category";
        public const string FIXTUREID = "Iptc.Application2.FixtureId";
        public const string SPECIAL_INSTRUCTIONS = "Iptc.Application2.SpecialInstructions";
        public const string ACTION_ADVISED = "Iptc.Application2.ActionAdvised";
        public const string PROGRAM = "Iptc.Application2.Program";
        public const string PROGRAM_VERSION = "Iptc.Application2.ProgramVersion";
        public const string CITY = "Iptc.Application2.City";
        public const string SUB_LOCATION = "Iptc.Application2.SubLocation";
        public const string PROVINCE_STATE = "Iptc.Application2.ProvinceState";
        public const string COUNTRY_CODE = "Iptc.Application2.CountryCode";
        public const string COUNTRY_NAME = "Iptc.Application2.CountryName";
        public const string TRANSMISSION_REFERENCE = "Iptc.Application2.TransmissionReference";
        public const string HEADLINE = "Iptc.Application2.Headline";
        public const string CREDIT = "Iptc.Application2.Credit";
        public const string SOURCE = "Iptc.Application2.Source";
        public const string COPYRIGHT = "Iptc.Application2.Copyright";
        public const string CAPTION = "Iptc.Application2.Caption";
        public const string IMAGE_TYPE = "Iptc.Application2.ImageType";
        public const string IMAGE_ORIENTATION = "Iptc.Application2.ImageOrientation";
        public const string LANGUAGE = "Iptc.Application2.Language";

        // n-x string
        public const string OBJECT_ATTRIBUTE = "Iptc.Application2.ObjectAttribute";
        public const string SUBJECT = "Iptc.Application2.Subject";
        public const string SUPP_CATEGORY = "Iptc.Application2.SuppCategory";
        public const string KEYWORDS = "Iptc.Application2.Keywords";
        public const string LOCATION_CODE = "Iptc.Application2.LocationCode";
        public const string LOCATION_NAME = "Iptc.Application2.LocationName";
        public const string REFERENCE_SERVICE = "Iptc.Application2.ReferenceService";
        public const string REFERENCE_NUMBER = "Iptc.Application2.ReferenceNumber";
        public const string BYLINE = "Iptc.Application2.Byline";
        public const string BYLINE_TITLE = "Iptc.Application2.BylineTitle";
        public const string CONTACT = "Iptc.Application2.Contact";
        public const string WRITER = "Iptc.Application2.Writer";
    }
}
