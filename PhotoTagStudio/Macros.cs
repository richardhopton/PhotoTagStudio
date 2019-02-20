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
using System.IO;
using System.Windows.Forms;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio
{
    class Macros
    {
        public const string FILE_DIALOG_FILTER = "PhotoTag Studio Macros (*.ptsmacro)|*.ptsmacro|All files (*.*)|*.*";

        public static Macro OpenMacro(IWin32Window dialogowner)
        {
            string s;
            return Macros.OpenMacro(dialogowner, out s);
        }
        public static Macro OpenMacro(IWin32Window dialogowner, out string filename)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.InitialDirectory = Settings.Default.MacroDirectory;
            d.Title = "Open PhotoTagStudio macro";
            d.Filter = FILE_DIALOG_FILTER;
            if (d.ShowDialog(dialogowner) == DialogResult.OK)
            {
                MacroEditor.RememberFileAndDirectory(d.FileName);

                filename = d.FileName;
                return OpenMacroFromFile(d.FileName);
            }

            filename = "";
            return null;
        }
        public static Macro OpenMacroFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                MessageBox.Show(
                    String.Format("The file {0} does not exist.", filename),
                    "PhotoTagStudio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            FileStream fs = new FileStream(filename, FileMode.Open);
            Macro m = Macro.Deserialize(fs);
            fs.Close();

            if (m == null)
            {
                MessageBox.Show(
                    String.Format("Cannot open the macro. The file {0} seems to be invalid.", filename),
                    "PhotoTagStudio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if ( CheckMacro(m))
                return m;
            else
                return null;
        }

        public static bool CheckMacro(Macro m)
        {
            if ( m == null )
                return false;

            foreach (ModelBase item in m.WorkItems)
                if ( item is PluginModel )
                {
                    PluginModel pluginItem = (PluginModel) item;
                    string plugin = pluginItem.Plugin;

                    IPhotoTagStudioTaggingPlugin p = PluginView.GetPlugin(plugin);
                    if ( p == null )
                    {
                        if (MessageBox.Show("The macro uses a plugin that cannot be found by PhotoTagStudio: " + plugin + "\n\nUse the macro anyway?", "Plugin for macro not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                            return false;
                    }
                }

            return true;
        }

        public static bool ExecuteMacro(Macro m, string startDirectory, bool askBeforeExecutionWhenDirectoryIsGivenFromFirstItem, IStatusDisplay statusDisplay, Form Parentform)
        {
            MacroWorker w = new MacroWorker(m, statusDisplay);

            if (w.ForbitExecution())
            {
                MessageBox.Show("Cannot execute the macro. One of the items is not valid.",
                                "Execute PhotoTagStudio Macro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            string dir;
            if (w.ProvidesItsOwnStartDirectories(out dir))
            {
                DirectoryInfo di = new DirectoryInfo(dir);
                if (!di.Exists)
                {
                    MessageBox.Show(String.Format("Cannot execute the macro. The start directory '{0}' does not exist.", di.FullName),
                                    "Execute PhotoTagStudio Macro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false; // directoy not exist -> exit                    
                }

                if (askBeforeExecutionWhenDirectoryIsGivenFromFirstItem)
                    if (MessageBox.Show(String.Format("Execute the macro on the directory '{0}'?", di.FullName), "Execute PhotoTagStudio Macro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return false; //answer = no
            }
            else
            {
                FolderBrowseBox fbb = new FolderBrowseBox("Execute PhotoTagStudio Macro", "Select the folder to execute the macro:", startDirectory);
                fbb.Subdirectories = Settings.Default.MacroUseSubdirectories;
                if (fbb.ShowDialog(Parentform) == DialogResult.Cancel)
                    return false;

                Settings.Default.MacroUseSubdirectories = fbb.Subdirectories;
                w.SetWorkingset(fbb.Directory, fbb.Subdirectories);
            }

            w.Start();
            return true;
        }
    }
}