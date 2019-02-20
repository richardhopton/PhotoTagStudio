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

using System.Collections.Generic;

namespace Schroeter.PhotoTagStudio.Features.MassTagging
{
    public class TagCollection
    {
        private Dictionary<string, TagEntry> tags;
        private FieldComboBoxEntry field;

        public TagCollection(FieldComboBoxEntry field)
        {
            this.field = field;

            this.tags = new Dictionary<string, TagEntry>();
        }

        public void RegisterFiles(List<MassWorkingFile> files)
        {
            foreach (MassWorkingFile f in files)
                RegisterFile(f);
        }

        public void RegisterFile(MassWorkingFile file)
        {
            if (field.Repeatable)
                foreach (string s in file.MetaData.ListRepeatableAttribute(field.Key))
                    AddTag(s, file);
            else
                AddTag(file.MetaData.getStringAttribute(field.Key), file);
        }

        private void AddTag(string tag, MassWorkingFile f)
        {
            if (tag == "")
                return;

            TagEntry e;
            if (tags.ContainsKey(tag))
                e = tags[tag];
            else
            {
                e = new TagEntry(tag);
                this.tags.Add(tag, e);
            }

            e.AddFile(f);
        }

        public Dictionary<string, TagEntry> Tags
        {
            get { return tags; }
            set { tags = value; }
        }
    }
}