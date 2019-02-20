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
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Gui
{
    public class KeyboardInteractionPresetableView<MODEL> : PresetableView<MODEL> where MODEL : ModelBase, new()
    {
        public event EventHandler EnterPressed;
        public event EventHandler PageDownPressed;
        public event EventHandler PageUpPressed;
        public event EventHandler DeletePressed;

        #region key handeling
        private Keys rememberedKey;
        protected virtual void txt_KeyDown(object sender, KeyEventArgs e)
        {
            rememberedKey = e.KeyCode;
        }

        protected virtual void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (rememberedKey != e.KeyCode)
                return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (EnterPressed != null)
                    {
                        ForceValidation(sender as Control);

                        this.EnterPressed(sender, new EventArgs());
                    }
                    break;

                case Keys.PageDown:
                    if (PageDownPressed != null && !(sender is TreeView))
                        this.PageDownPressed(sender, new EventArgs());
                    break;

                case Keys.PageUp:
                    if (PageUpPressed != null && !(sender is TreeView))
                        this.PageUpPressed(sender, new EventArgs());
                    break;

                case Keys.Delete:
                    if (DeletePressed != null && sender is CheckBox)
                        this.DeletePressed(sender, new EventArgs());
                    break;
            }
        }
        #endregion

    }
}
