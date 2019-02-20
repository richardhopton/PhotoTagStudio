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
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SettingsManager.ImportOldConfig();
            SettingsManager.InitUserSettings();
            SettingsManager.RegisterManager();

#if(!DEBUG)
            try
            {
#endif
                // check for macro file as first parameter
                string macroFilename = GetMacroParameter(arg);
                if ( macroFilename != "" )
                {
                    bool dontAsk = false;
                    bool edit = false;
                    string directory = "";
                    // look for the /dontAsk or /edit switch
                    foreach (string s in arg)
                    {
                        string para = s.Trim().ToLower();
                        if (para == "/dontask")
                            dontAsk = true;
                        else if (para == "/edit")
                            edit = true;
                        //else if (para.StartsWith("/dir=")) //TODO
                        //{
                        //    DirectoryInfo di = new DirectoryInfo(para.Substring(5));
                        //    if (di.Exists)
                        //        directory = di.FullName;
                        //    else
                        //        directory = "";
                        //}
                    }

                    //MessageBox.Show(directory);

                    if (edit)
                    {
                        Application.Run(new MainForm(macroFilename));
                    }
                    else
                    {
                        Macro macro = Macros.OpenMacroFromFile(macroFilename);
                        if (macro == null)
                        {
                            // file does not exist or is invalid
                            MessageBox.Show("Cannot open the given macro file!", "PhotoTagStudio", MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                        Application.Run(new StandAloneMacroExecutionForm(macro, GetStartingDirectory(arg), !dontAsk));
                    }

                    return; // exit
                }

                // start pts the normal way
                Application.Run(new MainForm(GetStartingDirectory(arg)));
#if(!DEBUG)
            }
            catch (Exception ex)
            {
                ErrorHandler.LogException(ex);
            }
#endif
        }
        
        static string GetMacroParameter(string[] arg)
        {
            if (arg.Length >= 1)
            {
                if ( arg[0].Trim().ToLower().EndsWith(".ptsmacro") )
                {
                    // there is a file!
                    FileInfo fi = new FileInfo(arg[0]);
                    if ( fi.Exists )
                        return fi.FullName;
                }
            }

            return "";
        }

        static string GetStartingDirectory(string[] arg)
        {
            string dir;
            if (arg.Length >= 1)
            {
                dir = arg[0].Trim();
                if (dir.EndsWith("\\"))
                    dir = dir.Substring(0, dir.Length - 1);
            }
            else
                dir = Settings.Default.LastWorkingDirectory;

            if (dir == "" )
                return "";

            DirectoryInfo di = new DirectoryInfo(dir);
            while( !di.Exists )
            {
                di = di.Parent;
                if (di == null)
                    return "";
            }

            return di.FullName;
        }
    }
}