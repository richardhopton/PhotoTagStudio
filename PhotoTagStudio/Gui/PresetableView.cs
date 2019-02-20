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
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class PresetableView<MODEL> : PresetableViewBase where MODEL:ModelBase,new()
    {
        protected MODEL model;

        public PresetableView()
        {
            model = new MODEL();

            InitializeComponent();
        }

        public virtual MODEL GetModel()
        {
            return model;
        }

        public virtual void SetModel(MODEL m)
        {
            model = m;
            model.EnableSpecialUpdateLogic = true;
        }

        #region PresetableViewBase Members

        public override ModelBase GetModelBase()
        {
            return GetModel();
        }

        public override void SetModelBase(ModelBase m)
        {
            SetModel(m as MODEL);
        }
        #endregion

        public override void PreInit()
        {
            SetModel(model);
        }

        #region private
        private List<string> presetList;

        private void BuildMenu()
        {
            this.loadPresetToolStripMenuItem.DropDownItems.Clear();
            this.deletePresetToolStripMenuItem.DropDownItems.Clear();

            if ( presetList == null)
                presetList = Settings.Default.PresetModels.GetAllPresetModelNames<MODEL>();

            foreach (string s in presetList)
            {
                ToolStripItem tsi = this.loadPresetToolStripMenuItem.DropDownItems.Add(s);
                tsi.Click += new EventHandler(loadPreset_Click);

                tsi = this.deletePresetToolStripMenuItem.DropDownItems.Add(s);
                tsi.Click += new EventHandler(deletePreset_Click);
            }
        }

        private void deletePreset_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem tsi = sender as ToolStripDropDownItem;
            if (tsi != null)
            {
                string name = tsi.Text;

                Settings.Default.PresetModels.DeletePresetModel<MODEL>(name);

                presetList.Remove(name);
                BuildMenu();
            }
        }

        private void loadPreset_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem tsi = sender as ToolStripDropDownItem;
            if ( tsi != null )
            {
                string name = tsi.Text;

                MODEL m = ModelBase.CloneModel(Settings.Default.PresetModels.GetPresetModel<MODEL>(name));

                SetModel(m);
            }
        }

        private void savePreset_Click(object sender, EventArgs e)
        {
            InputBox f = new InputBox("Save preset", "What's the name for the new preset", "");
            if (f.ShowDialog(this.FindForm()) == DialogResult.OK)
            {
                string name = f.Input.Trim();
                if (name == "")
                    return;

                //search the current focused control
                Queue<Control> queue = new Queue<Control>();
                queue.Enqueue(this);
                while(queue.Count > 0)
                {
                    Control c = queue.Dequeue();
                    if ( c.Focused )
                    {
                        ForceValidation(c);
                        break;
                    }

                    foreach (Control c2 in c.Controls)
                        queue.Enqueue(c2);
                }

                MODEL m = ModelBase.CloneModel(GetModel());
                Settings.Default.PresetModels.AddPresetModel(name, m);
                if ( !presetList.Contains(name) )
                {
                    presetList.Add(name);
                    presetList.Sort();
                }
                BuildMenu();
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BuildMenu();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            SetModel(new MODEL());
        }
        #endregion

        protected void ForceValidation(Control currentCtl)
        {
            // todo: gibt es einen besseren weg um validate auf sender zu erzwingen??
            if (currentCtl != null)
            {
                Control nextCtl = this.GetNextControl(currentCtl, true);
                if (nextCtl == null)
                    nextCtl = this.GetNextControl(currentCtl, false);

                if (nextCtl!= null)
                    nextCtl.Focus();
                
                currentCtl.Focus();
            }
        }
    }
}
