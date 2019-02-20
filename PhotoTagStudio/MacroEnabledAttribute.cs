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
using System.Text;

namespace Schroeter.PhotoTagStudio
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MacroEnabledAttribute : Attribute
    {
        private Type view;
        private Type worker;
        private string name;


        public MacroEnabledAttribute(string name, Type view, Type worker)
        {
            this.view = view;
            this.worker = worker;
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public Type View
        {
            get { return view; }
        }


        public Type Worker
        {
            get { return worker; }
        }
    }
}
