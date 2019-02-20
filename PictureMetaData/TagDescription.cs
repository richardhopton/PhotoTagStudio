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

namespace Schroeter.Photo
{
    public delegate string FormatMethod(string value);

    public class TagDescription
    {
        private TagGroupDescription group;
        private string name;
        private string description;
        private Type datatype;
        private int key;

        private FormatMethod formatMethod;

        public TagDescription(TagGroupDescription group, string name, string description, Type datatype, int key, FormatMethod formatMethod)
        {
            this.group = group;
            this.name = name;
            this.description = description;
            this.datatype = datatype;
            this.key = key;
            this.formatMethod = formatMethod;            
        }

        public TagDescription(TagGroupDescription group, string name, string description, Type datatype, int key):this(group,name,description,datatype,key, ExifFormating.printDefault)
        {
        }

        public string Fullname
        {
            get
            {
                return this.group.Name + "." + this.name;
            }
        }

        #region properties
        public TagGroupDescription Group
        {
            get { return group; }
        }
        public string Name
        {
            get { return name; }
        }
        public string Description
        {
            get { return description; }
        }
        public Type Datatype
        {
            get { return datatype; }
        }
        public int Key
        {
            get { return key; }
        }
        public FormatMethod FormatMethod
        {
            get { return formatMethod; }
        }
        #endregion
    }
}