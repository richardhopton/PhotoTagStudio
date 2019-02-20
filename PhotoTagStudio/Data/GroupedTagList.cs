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
    public class GroupedTagList : BaseTagList
    {
        public struct GroupValuePair
        {
            public string Group;
            public string Value;
        }

        public const string DEFAULT_GROUP = "(default)";

        protected List<GroupValuePair> data;

        public GroupedTagList()
        {
            this.data = new List<GroupValuePair>();
        }
        public GroupedTagList(TagList listBasis)
        {
            this.data = new List<GroupValuePair>();

            foreach (string s in listBasis.Data)
                this.Add(s);

            this.canGrow = listBasis.CanGrow;
        }
        public GroupedTagList(bool canGrow)
            : this()
        {
            this.CanGrow = canGrow;
        }

        public List<GroupValuePair> Data
        {
            get { return data; }
        }

        public void AddIfGrowing(string value, string group)
        {
            if (this.canGrow)
            {
                bool found = false;
                foreach (GroupValuePair gvp in data)
                    if (gvp.Value == value)
                    {
                        found = true;
                        break;
                    }

                if (!found)
                    this.Add(value, group);
            }
        }
        public override void AddIfGrowing(string value)
        {
            if (this.canGrow)
            {
                bool found = false;
                foreach (GroupValuePair gvp in data)
                    if (gvp.Value == value)
                    {
                        found = true;
                        break;
                    }

                if ( !found )
                    this.Add(value);
            }
        }
        public override bool Add(string value)
        {
            return this.Add(value, DEFAULT_GROUP); 
        }
        public bool Add(string value, string group)
        {
            GroupValuePair gvp = new GroupValuePair();
            gvp.Value = value.Trim();
            gvp.Group = group.Trim();

            if (!data.Contains(gvp) && gvp.Value != "")
            {
                data.Add(gvp);
                return true;
            }

            return false;
        }

        public void Remove(string value, string group)
        {
            GroupValuePair gvp = new GroupValuePair();
            gvp.Value = value.Trim();
            gvp.Group = group.Trim();

            if (data.Contains(gvp))
                data.Remove(gvp);
        }
        public void Remove(string group)
        {
            List<GroupValuePair> toDelete = new List<GroupValuePair>();

            foreach (GroupValuePair gvp in data)
                if (gvp.Group == group)
                    toDelete.Add(gvp);

            foreach (GroupValuePair gvp in toDelete)
                data.Remove(gvp);
        }

        public void Move(string value, string fromGroup, string toGroup)
        {
            Remove(value, fromGroup);
            Add(value, toGroup);
        }

        public List<string> GetGroups()
        {
            List<string> l = new List<string>();

            foreach (GroupValuePair gvp in data)
                if (!l.Contains(gvp.Group))
                    l.Add(gvp.Group);

            return l;
        }
        public List<string> GetValues(string group)
        {
            List<string> l = new List<string>();

            foreach (GroupValuePair gvp in data)
                if (gvp.Group == group)
                    l.Add(gvp.Value);

            return l;
        }

        public void Sort()
        {
            this.data.Sort(new GroupValuePairComparer());
        }
    }
}