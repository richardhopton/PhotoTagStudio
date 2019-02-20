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

namespace Schroeter.KmlGenerator
{
    public class Coordinates : List<Coordinate>
    {
        public int RemoveDuplicates()
        {
            int count = 0;
            
            for (int i = 0;i< this.Count-1; i++)
            {
                if (this[i].Equals(this[i + 1]))
                {
                    this.RemoveAt(i + 1);
                    i--;
                    count++;
                }
            }
            
            return count;
        }

        public int RemovePeeks()
        {
            int count = 0;

            for (int i = 0; i < this.Count - 2; i++)
            {
                Coordinate c1 = this[i];
                Coordinate c2 = this[i+1];
                Coordinate c3 = this[i+2];

                Double diff13 = c1.Distance(c3);
                Double diff12 = c1.Distance(c2);
                Double diff23 = c2.Distance(c3);
                
                if ( diff12 > diff13 && diff23 > diff13)
                {
                    this.RemoveAt(i + 1);
                    i-=2;
                    count++;
                }
            }

            return count;
        }

    }
}
