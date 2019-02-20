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
using System.Reflection;
using System.Text;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Gui;

namespace Schroeter.PhotoTagStudio.Workers
{
    public class PluginWorker : SingleFileWorkerBase<PluginModel>
    {
        private static Dictionary<string, IPhotoTagStudioTaggingPlugin> cache = new Dictionary<string, IPhotoTagStudioTaggingPlugin>();

        public override bool ProcessFile(PictureMetaData pmd, PluginModel model)
        {
            IPhotoTagStudioTaggingPlugin plugin;
            if (cache.ContainsKey(model.Plugin))
                plugin = cache[model.Plugin];
            else
            {
                plugin = PluginView.GetPlugin(model.Plugin);
                cache.Add(model.Plugin, plugin);
            }

            if (plugin != null)
                return plugin.ProcessFile(pmd);

            return false;
        }
    }
}
