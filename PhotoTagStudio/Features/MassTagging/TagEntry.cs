#region Copyright (C) 2005-2008 Benjamin Schr�ter <benjamin@irgendwie.net>
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

using System.Collections.Generic;

namespace Schroeter.PhotoTagStudio.Features.MassTagging
{
    public class TagEntry
    {
        private bool selected;
        private string text;
        private string newText;
        private List<MassWorkingFile> files;

        public TagEntry(string text)
        {
            this.text = text;
            this.newText = text;
            this.selected = false;

            this.files = new List<MassWorkingFile>();
        }

        public void AddFile(MassWorkingFile file)
        {
            this.files.Add(file);
        }

        public int FileCount
        {
            get { return this.files.Count; }
        }

        public string NewText
        {
            get { return newText; }
            set { newText = value; }
        }
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public bool Selected
        {
            get { return selected; }
            set { selected = value; }
        }
        public List<MassWorkingFile> Files
        {
            get { return files; }
            set { files = value; }
        }
    }
}