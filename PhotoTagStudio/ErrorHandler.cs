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

namespace Schroeter.PhotoTagStudio
{
    public class ErrorHandler
    {
        public static void LogException(Exception ex)
        {
            LogException(ex, "");
        }

        public static void LogException(Exception ex, string filename)
        {
            string s = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + " " + filename.Replace("\\", "-").Replace(":", "-");
            s = s.Trim();
            s += ".log";
            FileInfo fi = new FileInfo(s);

            StreamWriter sw = new StreamWriter(fi.FullName, true);
            sw.WriteLine(filename);
            sw.WriteLine();
            sw.WriteLine(ex.Message);
            sw.WriteLine(ex.StackTrace);
            sw.WriteLine(ex.ToString());
            sw.Close();

            MessageBox.Show(fi.FullName + ":\n\n" + filename + "\n\n" + ex.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
