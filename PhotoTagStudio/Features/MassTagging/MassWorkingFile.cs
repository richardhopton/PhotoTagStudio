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
using Schroeter.Photo;

namespace Schroeter.PhotoTagStudio.Features.MassTagging
{
    public class MassWorkingFile
    {
        private struct Job
        {
            public string TagName;
            public bool RepeatableTag;
            public string OldValue;
            public string NewValue;
        }

        private bool caching;
        private string filename;

        public string Filename
        {
            get { return filename; }
        }

        private PictureMetaData picture;
        private List<Job> jobs;

        public MassWorkingFile(string filename, bool caching)
        {
            this.caching = caching;
            this.filename = filename;
            this.picture = null;

            this.jobs = new List<Job>();
        }

        ~MassWorkingFile()
        {
            Close();
        }

        public void AddJob(string tagName, bool repeatable, string oldValue, string newValue)
        {
            Job j = new Job();
            j.TagName = tagName;
            j.OldValue = oldValue;
            j.NewValue = newValue;
            j.RepeatableTag = repeatable;

            this.jobs.Add(j);
        }

        public void ProcessJobs()
        {
            if (this.jobs.Count == 0)
                return;

            PictureMetaData pmd = this.MetaData;

            foreach (Job j in jobs)
            {
                if (j.RepeatableTag)
                {
                    pmd.RemoveRepeatableAttribute(j.TagName, j.OldValue);
                    if ( j.NewValue != "" )
                        pmd.AddRepeatableAttribute(j.TagName, j.NewValue);
                }
                else
                {
                    if (pmd.getStringAttribute(j.TagName) == j.OldValue)
                        pmd.setStringAttribute(j.TagName, j.NewValue);
                }
            }

            pmd.SaveChanges();

            if (!this.caching)
                pmd.Close();

            this.jobs = new List<Job>();
        }

        public void Close()
        {
            if (picture != null)
            {
                picture.Close();
                picture = null;
            }
        }

        public PictureMetaData MetaData
        {
            get
            {
                PictureMetaData pmd;

                if (this.picture == null)
                {
                    pmd = new PictureMetaData(this.filename);
                    if (this.caching)
                        this.picture = pmd;
                }
                else
                    pmd = this.picture;

                return pmd;
            }
        }
    }
}
