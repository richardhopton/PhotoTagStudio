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
using System.Drawing;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class PluginView : PresetableViewForPluginModel
    {
        public event EventHandler EnterPressed;

        public PluginView()
        {
            InitializeComponent();

            foreach (AvailablePlugin plugin in AllPlugins)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = plugin.Name;
                lvi.SubItems.Add(plugin.Description);
                lvi.Tag = plugin;

                this.listView1.Items.Add(lvi);
            }
        }

        public override void SetModel(PluginModel m)
        {
            base.SetModel(m);

            this.listView1.SelectedItems.Clear();
            if ( this.model.Plugin != "" )
            {
                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    AvailablePlugin plugin = (AvailablePlugin)lvi.Tag;
                    if (plugin.PluginType.FullName == model.Plugin)
                    {
                        lvi.Selected = true;
                        break;
                    }
                }
            }

        }

        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            this.listView1.Columns[0].Width = (int) (this.listView1.Width*0.30);
            this.listView1.Columns[1].Width = (int)(this.listView1.Width * 0.65);
        }

        #region available plugins
        public struct AvailablePlugin
        {
            public string Name;
            public string Description;
            public Type PluginType;

            public AvailablePlugin(string name, string description, Type pluginType)
            {
                Name = name;
                Description = description;
                PluginType = pluginType;
            }

            public IPhotoTagStudioTaggingPlugin CreateNewPlugin()
            {
                // creating a new plugin with the parameterless constructor
                object o = PluginType.GetConstructor(new Type[] { }).Invoke(null);
                return o as IPhotoTagStudioTaggingPlugin;
            }
        }

        private static List<AvailablePlugin> allPlugins;
        public static List<AvailablePlugin> AllPlugins
        {
            get
            {
                if ( allPlugins == null )
                {
                    allPlugins = new List<AvailablePlugin>();

                    string path = typeof (PluginView).Assembly.Location;
                    FileInfo fi = new FileInfo(path);
                    string pluginpath = fi.DirectoryName + "\\plugins";
                    pluginpath = pluginpath.Replace("\\\\", "\\");
                    DirectoryInfo di = new DirectoryInfo(pluginpath);
                    if ( di.Exists )
                    {
                        foreach (FileInfo file in di.GetFiles("*.dll"))
                        {
                            try
                            {
                                Assembly a =  Assembly.LoadFile(file.FullName);
                                foreach (Type type in a.GetTypes())
                                    foreach (Type interfaceType in type.GetInterfaces())
                                        if ( interfaceType.Equals(typeof(IPhotoTagStudioTaggingPlugin)))
                                        {
                                            // we found a plugin

                                            AvailablePlugin avp;

                                            object[] attributes = type.GetCustomAttributes(typeof(PluginDescriptionAttribute), false);
                                            if ( attributes.Length > 0 )
                                            {
                                                PluginDescriptionAttribute att = (PluginDescriptionAttribute) attributes[0];
                                                avp = new AvailablePlugin(att.Name,att.Description,type);
                                            }
                                            else
                                                avp = new AvailablePlugin(type.Name,type.FullName,type);

                                            allPlugins.Add(avp);
                                        }
                            }
                            catch
                            {
                            }
                        }
                    }
                }

                return allPlugins;
            }
        }
        public static IPhotoTagStudioTaggingPlugin GetPlugin(String name)
        {
            foreach (AvailablePlugin plugin in AllPlugins)
                if (plugin.PluginType.FullName == name)
                    return plugin.CreateNewPlugin();

            return null;
        }
        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                AvailablePlugin plugin = (AvailablePlugin)lvi.Tag;

                this.model.Plugin = plugin.PluginType.FullName;
            }
            else
                this.model.Plugin = "";
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (EnterPressed != null)
                    this.EnterPressed(sender, new EventArgs());
        }
    }

    // workaround, the visual studio (2005 and orcas beta 2) cannot design 
    // a control deriverd from PresetableView<PluginModel> :-(
    // but PresetableViewForPluginModel is fine :-)
    public class PresetableViewForPluginModel : PresetableView<PluginModel>
    {
    }
}
