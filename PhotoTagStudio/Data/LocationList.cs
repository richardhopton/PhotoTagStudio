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

namespace Schroeter.PhotoTagStudio.Data
{
    [Serializable]
    public class LocationList
    {
        private List<Location> data;
        private bool canGrow;

        public LocationList()
        {
            this.data = new List<Location>();
        }
        public LocationList(bool canGrow) : this()
        {
            this.CanGrow = canGrow;
        }

        public List<Location> Data
        {
            get { return data ; }
        }

        public void AddIfGrowing(Location v)
        {
            if (this.canGrow)
                this.Add(v);
        }

        public bool Add(Location v)
        {
            string vkey = v.GetKey();

            //todo: schöner / schneller machen
            foreach(Location l in data)
                if ( l.GetKey() == vkey )
                    return false;

            this.data.Add(v);
            return true;
        }

        public bool CanGrow
        {
            get { return canGrow; }
            set { canGrow = value; }
        }
    }
}