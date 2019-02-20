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

using System.ComponentModel;
using System.Windows.Forms;

namespace Schroeter.Windows.Forms
{
    /// <summary>
    /// Workaround for a Framework 1.0 and 1.1 bug
    /// and it seems in 2.0 there is a similar bug - at least another bug with the same workaround
    /// 
    /// see http://support.microsoft.com/default.aspx/kb/814347
    /// </summary>
    public class NumericUpDownReplacement :NumericUpDown
    {
        protected override void OnValidating(CancelEventArgs e)
        {
            decimal d = this.Value;

            base.OnValidating(e);
        }
    }
}
