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
using System.IO;
using System.Text;
using System.Windows.Forms;
using ShellLib;

namespace Schroeter.PhotoTagStudio.Features.Renamer
{
    class RenamerEngine
    {
        private SortedDictionary<string , string> OldNameAndNewName = new SortedDictionary<string, string>();
        private Dictionary<string, int> NewNamesAndCounter = new Dictionary<string, int>();
      
        public bool explicitNumberParameterInFormatString;  //e.g. the %# or %## tag
        public bool firstElementStartsWithEmptyNumberText;

        public RenamerEngine(bool explicitNumberParameterInFormatString, bool firstElementStartsWithEmptyNumberText) : this(explicitNumberParameterInFormatString, firstElementStartsWithEmptyNumberText, true)
        {
        }

        public RenamerEngine(bool explicitNumberParameterInFormatString, bool firstElementStartsWithEmptyNumberText, bool WorkOrderAscending)
        {
            this.firstElementStartsWithEmptyNumberText = firstElementStartsWithEmptyNumberText;
            this.explicitNumberParameterInFormatString = explicitNumberParameterInFormatString;

            if (WorkOrderAscending)
                OldNameAndNewName = new SortedDictionary<string, string>();
            else
                OldNameAndNewName = new SortedDictionary<string, string>(new DescandingComparer());
        }

        public void AddNewRenameItem(FileSystemInfo element, string wishedNewName)
        {
            int number;

            // if there is another item with the same wish name, get the number of this item
            if (NewNamesAndCounter.ContainsKey(wishedNewName.ToLower()))
                number = ++NewNamesAndCounter[wishedNewName.ToLower()];
            else
            {
                number = firstElementStartsWithEmptyNumberText ? 0 : 1;
                NewNamesAndCounter.Add(wishedNewName.ToLower(), number);
            }

            // place this number somewhere in the new name
            if (number != 0)
            {
                if (explicitNumberParameterInFormatString)
                    wishedNewName = wishedNewName.Replace("%#", number.ToString());
                else
                    wishedNewName = wishedNewName + " (" + number + ")";

            }
            else
                wishedNewName = wishedNewName.Replace("%#", "");  // remove the tag

            wishedNewName = wishedNewName.Trim();

            string wishedNewNameWithExtension = wishedNewName + element.Extension;
            // store these new names for later renaming
            OldNameAndNewName.Add(element.FullName.ToLower(), wishedNewNameWithExtension);
        }

        public int Count
        {
            get
            {
                return OldNameAndNewName.Count;
            }
        }

        public string GetNewName(string oldName)
        {
            if (OldNameAndNewName.ContainsKey(oldName.ToLower()) )
                return OldNameAndNewName[oldName.ToLower()];

            return "";
        }

        public bool CopyMove(bool move)
        {
            ShellFileOperation fo = CreateFileOperation(move);
            bool ret = fo.DoOperation();

            foreach (ShellNameMapping mapping in fo.NameMappings)
                foreach (KeyValuePair<string, string> pair in OldNameAndNewName)
                {
                    if (pair.Value.ToLower() == mapping.DestinationPath.ToLower())
                    {                        
                        OldNameAndNewName[pair.Key] = mapping.RenamedDestinationPath;
                        break;
                    }
                }

            return ret;
        }

        private ShellFileOperation CreateFileOperation(bool move)
        {
            ShellFileOperation fo = new ShellFileOperation();

            int c = 0;
            foreach (KeyValuePair<string, string> pair in OldNameAndNewName)
                if (pair.Key.ToLower() != pair.Value.ToLower())
                    c++;

            String[] source = new String[c];
            String[] dest = new String[c];

            int i = 0;
            foreach (KeyValuePair<string, string> pair in OldNameAndNewName)
            {
                if (pair.Key.ToLower() != pair.Value.ToLower())
                {
                    source[i] = pair.Key;
                    dest[i] = pair.Value;
                    i++;
                }
            }

            fo.Operation = move
                               ? ShellFileOperation.FileOperations.FO_MOVE
                               : ShellFileOperation.FileOperations.FO_COPY;
//            fo.OwnerWindow = this.Handle; 
            fo.SourceFiles = source;
            fo.DestFiles = dest;

            fo.OperationFlags = ShellFileOperation.ShellFileOperationFlags.FOF_NOCONFIRMMKDIR
                                | ShellFileOperation.ShellFileOperationFlags.FOF_MULTIDESTFILES
                                | ShellFileOperation.ShellFileOperationFlags.FOF_ALLOWUNDO
                                | ShellFileOperation.ShellFileOperationFlags.FOF_WANTMAPPINGHANDLE;

            return fo;
        }

        public SortedDictionary<string, string> GetAllOldAndNewFilenames()
        {
            return OldNameAndNewName;
        }
        public List<string> GetAllNewFilenames()
        {
            List<string> l = new List<string>(OldNameAndNewName.Count);

            foreach (KeyValuePair<string, string> pair in OldNameAndNewName)
                l.Add(pair.Value);

            return l;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in OldNameAndNewName)
            {
                sb.Append(pair.Key);
                sb.Append("\t->\t");
                sb.Append(pair.Value);
                sb.Append("\n");
            }

            return sb.ToString();
        }

        private class DescandingComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.CompareTo(y) * -1;
            }
        }
    }
}
