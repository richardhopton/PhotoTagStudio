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
using System.Collections;
using System.Collections.Generic;

namespace Schroeter.PhotoTagStudio.Features.KmzMaker
{
    public class GpsLog : IEnumerable<GpsLogEntry>
    {
        private SortedList<DateTime, GpsLogEntry> entries;
        private TimeSpan offset;
        private List<NamedGpsLogEntry> waypoints;

        internal GpsLog()
        {
            offset = new TimeSpan(0);
            entries = new SortedList<DateTime, GpsLogEntry>();
            waypoints = new List<NamedGpsLogEntry>();
        }
                
        public GpsLogEntry GetNearestEntry(DateTime time)
        {
            time = time.Add(offset);
                
            GpsLogEntry l = null;
            foreach(GpsLogEntry e in entries.Values)
                if ( e.Time >= time )
                {
                    l = e;
                    break;
                }

            return l;
        }

        #region properties
        public int Count
        {
            get
            {
                return entries.Count;
            }
        }

        public TimeSpan Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public DateTime? FirstTime
        {
            get
            {
                if (entries.Count > 0)
                    return entries.Keys[0];
                else
                    return null;
            }
        }

        public DateTime? LastTime
        {
            get
            {
                if (entries.Count > 0)
                    return entries.Keys[ entries.Count-1 ];
                else
                    return null;
            }
        }

        public List<NamedGpsLogEntry> Waypoints
        {
            get { return waypoints; }
        }
        #endregion

        internal void AddEntry(GpsLogEntry e)
        {
            if (!entries.ContainsKey(e.Time))
                entries.Add(e.Time, e);
        }

        internal void AddWaypoint(NamedGpsLogEntry e)
        {
            this.waypoints.Add(e);    
        }

        IEnumerator<GpsLogEntry> IEnumerable<GpsLogEntry>.GetEnumerator()
        {
            return entries.Values.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return entries.Values.GetEnumerator();
        }
    }
}