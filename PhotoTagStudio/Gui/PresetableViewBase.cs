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

using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Gui
{
    public class PresetableViewBase : UserControl
    {
        protected bool RunningInMacroMode = false;

        public virtual ModelBase GetModelBase()
        {
            return null;
        }

        public virtual void SetModelBase(ModelBase m)
        {
        }

        public virtual void PreInit()
        {
            
        }

        public void PreInitMacroMode()
        {
            RunningInMacroMode = true;
            PreInit();
        }
    }
}