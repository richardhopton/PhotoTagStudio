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
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Data
{
    [MacroEnabled("Plugin", typeof(PluginView), typeof(PluginWorker))]
    public class PluginModel : ModelBase
    {
        private string plugin = "";

        public string Plugin
        {
            get { return plugin; }
            set
            {
                SetDirty();
                plugin = value;
            }
        }

        public override bool ForbitExecution()
        {
            return plugin == "";
        }
    }
}
