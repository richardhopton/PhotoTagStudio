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

namespace Schroeter.PhotoTagStudio.Data
{
    [Serializable]
    public class Location
    {
        private string city;
        private string sublocation;
        private string state;
        private string countryCode;
        private string countryName;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Sublocation
        {
            get { return sublocation; }
            set { sublocation = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        public string CountryCode
        {
            get { return countryCode; }
            set { countryCode = value; }
        }
        public string CountryName
        {
            get { return countryName; }
            set { countryName = value; }
        }

        public string GetKey()
        {
            string x = "+++";
            return city + x + sublocation + x + countryCode + state + x + countryName;
        }

        public override string ToString()
        {
            string x = " / ";
            return city + x + sublocation + x + state + x + countryName + " (" + countryCode  + ")";            
        }
    }
}
