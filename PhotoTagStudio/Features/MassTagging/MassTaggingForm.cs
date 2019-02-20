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
using System.Windows.Forms;
using Schroeter.PhotoTagStudio.Data;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Features.MassTagging
{
    public struct FieldComboBoxEntry
    {
        public FieldComboBoxEntry(string text, string key, bool repeatable)
        {
            this.Text = text;
            this.Key = key;
            this.Repeatable = repeatable;
        }

        public string Text;
        public string Key;
        public bool Repeatable;

        public override string ToString()
        {
            return this.Text;
        }
    }

    public partial class MassTaggingForm : Form
    {
        private List<MassWorkingFile> files;
        private FieldComboBoxEntry selectedTag;
        private TagCollection tags;
        private bool settingsChanged;

        public MassTaggingForm(string path)
        {
            InitializeComponent();

            this.Icon = Resources.PTS;

            this.txtDirectory.Text = path;
        }

        private void btnReadFiles_Click(object sender, EventArgs e)
        {
            this.WaitCursor(true);

            this.selectedTag = (FieldComboBoxEntry)this.cmbField.SelectedItem;

            // dateien suchen
            if (this.files == null)
                FindFiles();

            this.ProgressBarMaximum = this.files.Count;

            this.tags = new TagCollection( (FieldComboBoxEntry) this.cmbField.SelectedItem );
            foreach (MassWorkingFile f in this.files)
            {
                this.tags.RegisterFile(f);
                this.ProgressBarValue++;
            }

            // dateilist löschen
            if (!this.chkCaching.Checked)
                ClearFiles();

            DisplayGrid();

            this.ProgressBarMaximum = 0;
            this.WaitCursor(false);
        }

        private void btnWriteFiles_Click(object sender, EventArgs e)
        {
            this.WaitCursor(true);

            // dateien suchen
            if (this.files == null)
                FindFiles();


            Dictionary<string, MassWorkingFile> workingfiles = new Dictionary<string, MassWorkingFile>();
            foreach (TagEntry tagentry in this.tags.Tags.Values)
                if (tagentry.Text != tagentry.NewText)
                    foreach (MassWorkingFile f in tagentry.Files)
                    {
                        if (!workingfiles.ContainsKey(f.Filename))
                            workingfiles.Add(f.Filename, f);
                        MassWorkingFile mwf = workingfiles[f.Filename];

                        mwf.AddJob(this.selectedTag.Key, this.selectedTag.Repeatable, tagentry.Text, tagentry.NewText.Trim());
                    }

            this.ProgressBarMaximum = workingfiles.Count;

            foreach (MassWorkingFile f in workingfiles.Values)
            {
                f.ProcessJobs();
                this.ProgressBarValue++;
            }

            // dateilist löschen
            if (!this.chkCaching.Checked)
                ClearFiles();

            foreach (TagEntry tagentry in this.tags.Tags.Values)
                if (tagentry.Text != tagentry.NewText)
                    tagentry.Text = tagentry.NewText;

            DisplayGrid();

            this.ProgressBarMaximum = 0;
            this.WaitCursor(false);
        }

        private void btnTags2Settings_Click(object sender, EventArgs e)
        {
            BaseTagList list = null;
            switch (selectedTag.Key)
            {
                case Schroeter.Photo.Iptc.KEYWORDS:
                    list = Settings.Default.GroupedKeywords;
                    break;
                case Schroeter.Photo.Iptc.HEADLINE:
                    list = Settings.Default.Headlines;
                    break;
                case Schroeter.Photo.Iptc.CAPTION:
                    list = Settings.Default.Captions;
                    break;
                case Schroeter.Photo.Iptc.OBJECT_NAME:
                    list = Settings.Default.Objectnames;
                    break;
                case Schroeter.Photo.Iptc.WRITER:
                    list = Settings.Default.Writers;
                    break;
                case Schroeter.Photo.Iptc.BYLINE:
                    list = Settings.Default.Authors;
                    break;
                case Schroeter.Photo.Iptc.COPYRIGHT:
                    list = Settings.Default.Copyrights;
                    break;
                case Schroeter.Photo.Iptc.CONTACT:
                    list = Settings.Default.Contacts;
                    break;
            }

            if (list == null)
            {
                MessageBox.Show("Cannot save the selected tag to the user settings.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (TagEntry entry in this.tags.Tags.Values)
                if (entry.Selected)
                {
                    this.settingsChanged |= list.Add(entry.Text);
                    entry.Selected = false;
                }

            DisplayGrid();
        }

        private void FindFiles()
        {
            ClearFiles();

            this.files = new List<MassWorkingFile>();

            Queue<DirectoryInfo> q = new Queue<DirectoryInfo>();
            q.Enqueue(new DirectoryInfo(this.txtDirectory.Text));

            while (q.Count > 0)
            {
                DirectoryInfo di = q.Dequeue();
                if (di.Exists)
                {
                    if (this.chkSubdirs.Checked)
                        foreach (DirectoryInfo subdi in di.GetDirectories())
                            q.Enqueue(subdi);

                    foreach (FileInfo fi in di.GetFiles("*.jpg"))
                        this.files.Add(new MassWorkingFile(fi.FullName, this.chkCaching.Checked));
                }
            }
        }

        #region progressbar und wait coursor
        private void WaitCursor(bool on)
        {
            this.Cursor = on ? Cursors.WaitCursor : Cursors.Default;
        }

        private int ProgressBarMaximum
        {
            get
            {
                return this.toolStripProgressBar1.Maximum;
            }
            set
            {
                this.toolStripProgressBar1.Maximum = value;
            }
        }

        private int ProgressBarValue
        {
            get
            {
                return this.toolStripProgressBar1.Value;
            }
            set
            {
                this.toolStripProgressBar1.Value = value;

                this.statusStrip1.Refresh();

                //TODO
                //if (this.toolStripProgressBar1.Value > 0 && this.toolStripProgressBar1.Maximum > 9)
                //    this.toolStripStatusLabel1.Text = "(" + this.toolStripProgressBar1.Value + "/" + this.toolStripProgressBar1.Maximum + ")";
                //else
                //    this.toolStripStatusLabel1.Text = "";
            }
        }
        #endregion

        #region Gui zeugs
        private void MassTaggingForm_Load(object sender, EventArgs e)
        {
            List<FieldComboBoxEntry> l = new List<FieldComboBoxEntry>();
            if (Settings.Default.DisplayIPTCTagsWithFlickrNames)
                l.Add(new FieldComboBoxEntry("Tags", Schroeter.Photo.Iptc.KEYWORDS, true));
            else
                l.Add(new FieldComboBoxEntry("Keywords", Schroeter.Photo.Iptc.KEYWORDS, true));

            l.Add(new FieldComboBoxEntry("Headline", Schroeter.Photo.Iptc.HEADLINE, true));

            if (Settings.Default.DisplayIPTCTagsWithFlickrNames)
                l.Add(new FieldComboBoxEntry("Description", Schroeter.Photo.Iptc.CAPTION, false));
            else
                l.Add(new FieldComboBoxEntry("Caption", Schroeter.Photo.Iptc.CAPTION, false));

            if (Settings.Default.DisplayIPTCTagsWithFlickrNames)
                l.Add(new FieldComboBoxEntry("Title", Schroeter.Photo.Iptc.OBJECT_NAME, false));
            else
                l.Add(new FieldComboBoxEntry("Object Name", Schroeter.Photo.Iptc.OBJECT_NAME, false));

            l.Add(new FieldComboBoxEntry("Writer", Schroeter.Photo.Iptc.WRITER, true));
            l.Add(new FieldComboBoxEntry("Author (byline)", Schroeter.Photo.Iptc.BYLINE, true));
            l.Add(new FieldComboBoxEntry("Copyright", Schroeter.Photo.Iptc.COPYRIGHT, false));
            l.Add(new FieldComboBoxEntry("Contact", Schroeter.Photo.Iptc.CONTACT, true));
            l.Add(new FieldComboBoxEntry("City", Schroeter.Photo.Iptc.CITY, false));
            l.Add(new FieldComboBoxEntry("Sublocation", Schroeter.Photo.Iptc.SUB_LOCATION, false));
            l.Add(new FieldComboBoxEntry("Province/state", Schroeter.Photo.Iptc.PROVINCE_STATE, false));
            l.Add(new FieldComboBoxEntry("Country name", Schroeter.Photo.Iptc.COUNTRY_NAME, false));
            l.Add(new FieldComboBoxEntry("Country code", Schroeter.Photo.Iptc.COUNTRY_CODE, false));

            this.cmbField.DataSource = l;
            this.cmbField.SelectedIndex = 0;

            this.selectedTag = (FieldComboBoxEntry)this.cmbField.SelectedItem;
        }

        private void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog(this) == DialogResult.OK)
                this.txtDirectory.Text = f.SelectedPath;
        }

        private void chkSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            ClearFiles();
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e)
        {
            ClearFiles();
        }

        private void ClearFiles()
        {
            if ( files != null )
                foreach (MassWorkingFile file in files)
                    file.Close();

            this.files = null;
        }

        private void DisplayGrid()
        {
            List<TagEntry> l = new List<TagEntry>(this.tags.Tags.Values);
            this.dataGridView1.DataSource = l;
        }

        private void chkCaching_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkCaching.Checked)
                ClearFiles();
        }
        #endregion

        public bool SettingsChanged
        {
            get { return settingsChanged; }
        }

        private void MassTaggingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearFiles();
            GC.Collect();
            GC.Collect();
        }
    }
}