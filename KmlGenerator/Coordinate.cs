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

namespace Schroeter.KmlGenerator
{
    public struct Coordinate
    {
        public Coordinate(decimal longitude, decimal latitude, decimal attitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            Attitude = attitude;
        }
        public Coordinate(decimal longitude, decimal latitude) : this ( longitude, latitude, 0)
        {
        }
        
        public decimal Longitude;
        public decimal Latitude;
        public decimal Attitude;

        public override bool Equals(object obj)
        {
            if (obj is Coordinate)
            {
                Coordinate c = (Coordinate)obj;
                return c.Longitude == this.Longitude && c.Latitude == this.Latitude && c.Attitude == this.Attitude;
            }
            else
                return false;
        }
        
        public double Distance(Coordinate c)
        {
            return Math.Sqrt(Math.Pow((double) c.Longitude - (double) this.Longitude, 2) +
                      Math.Pow((double) c.Latitude - (double) this.Latitude, 2));
        }
    }
}