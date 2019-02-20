#region Copyright (C) 2005-2007 Benjamin Schröter <benjamin@irgendwie.net>
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
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Features.Renamer;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class Renamer : PictureDetailControlBase
    {
        //view
        public Renamer()
        {
            InitializeComponent();

            InitHelpString();
        }

        //ctr
        protected override void RefreshMyData()
        {
            UpdatePreviews();
        }
        //ctr
        protected override void ClearMyData()
        {
            UpdatePreviews();
        }
        //view
        protected override void RefreshMySettings()
        {
            this.txtFilename.DataSource = null;
            this.txtFilename.DataSource = Settings.Default.FilenameFormats.Data;
            this.txtFilename.SelectedItem = Settings.Default.FilenameFormats.DefaultValue;

            this.txtDirectoryname.DataSource = null;
            this.txtDirectoryname.DataSource = Settings.Default.DirectorynameFormats.Data;
            this.txtDirectoryname.SelectedItem = Settings.Default.DirectorynameFormats.DefaultValue;

            this.chkFilename.Checked = true;
            this.chkDirectory.Checked = false;
        }
        //ctr
        private void UpdatePreviews()
        {
            if (currentPicture != null)
            {
                this.labFilenameExample.Text = FileNameFormater.FormatFilename(currentPicture, this.txtFilename.Text) + ".jpg";
                this.labDirectoryExample.Text = FileNameFormater.FormatFilename(currentPicture, this.txtDirectoryname.Text);
            }
        }

        //view
        #region update help
        private void InitHelpString()
        {
            StringBuilder b = new StringBuilder();

            b.Append("%h\tHeadline\r\n");
            b.Append("%cap\tCaption\r\n");
            b.Append("%on\tObject name\r\n");
            b.Append("%w\tWriter\r\n");
            b.Append("%a\tAuthor (byline)\r\n");
            b.Append("%cr\tCopyright\r\n");
            b.Append("%con\tContact\r\n");
            b.Append("%c\tCity\r\n");
            b.Append("%sl\tSublocation\r\n");
            b.Append("%s\tProvince / state\r\n");
            b.Append("%cn\tCountry name\r\n");
            b.Append("%cc\tCountry code\r\n");
            b.Append("%k\tKeywords (comma seperated)\r\n");
            b.Append("\r\n");
            b.Append("%d\tIPTC created date time\r\n");
            b.Append("%dc\tEXIF created date time\r\n");
            b.Append("%dd\tEXIF digitized date time\r\n");
            b.Append("\r\n");
            b.Append("%##\tA number (starting at 1) for every picture with the same rest of name\r\n");
            b.Append("%#\tAs %##, but the first file is left without any number\r\n");
            b.Append("\tIf you do not use either %# or %## a number will be added to files with same names\r\n");
            b.Append("\r\n");
            b.Append("For the date time fields you can specify optional a format.\r\n");
            b.Append("Use [ and ] with the following patterns after the field name (e.g. %dc[yyyy-MM-dd])\r\n");
            b.Append("\r\n");
            b.Append("dd\tThe day of the month. Single-digit days will have a leading zero.\r\n");
            b.Append("ddd \tThe abbreviated name of the day of the week.\r\n");
            b.Append("dddd \tThe full name of the day of the week.\r\n");
            b.Append("MM \tThe numeric month. Single-digit months will have a leading zero.\r\n");
            b.Append("MMM \tThe abbreviated name of the month.\r\n");
            b.Append("MMMM \tThe full name of the month.\r\n");
            b.Append("yy \tThe year without the century. \r\n");
            b.Append("yyyy \tThe year in four digits.\r\n");
            b.Append("hh\tThe hour in a 12-hour clock. Single-digit hours will have a leading zero.\r\n");
            b.Append("HH \tThe hour in a 24-hour clock. Single-digit hours will have a leading zero.\r\n");
            b.Append("mm \tThe minute. Single-digit minutes will have a leading zero.\r\n");
            b.Append("ss \tThe second. Single-digit seconds will have a leading zero.\r\n");
            b.Append("\r\n");
            b.Append("d \tShort date pattern.\r\n");
            b.Append("D \tLong date pattern.\r\n");
            b.Append("f \tFull date and time pattern (long date and short time).\r\n");
            b.Append("F \tFull date and time pattern (long date and long time).\r\n");
            b.Append("g \tGeneral pattern (short date and short time).\r\n");
            b.Append("G \tGeneral pattern (short date and long time).\r\n");
            b.Append("m, M \tMonth day pattern.\r\n");
            b.Append("r, R \tRFC1123 pattern.\r\n");
            b.Append("s \tSortable date time pattern (based on ISO 8601).\r\n");
            b.Append("t \tShort time pattern.\r\n");
            b.Append("T \tLong time pattern.\r\n");
            b.Append("u \tUniversal sortable date time pattern using the format for universal time display.\r\n");
            b.Append("U \tFull date and time pattern (long date and long time) using universal time.\r\n");
            b.Append("y, Y \tYear month pattern.");

            this.richTextBox1.Text = b.ToString();
        }
        #endregion

        #region TextChanged-Events
        //ctrl
        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            this.UpdatePreviews();
            this.chkFilename.Checked = true;
        }
        //ctrl
        private void txtDirectoryname_TextChanged(object sender, EventArgs e)
        {
            this.UpdatePreviews();
            this.chkDirectory.Checked = true;
        }
        #endregion

        //TODO
        private void btnRename_Click(object sender, EventArgs e)
        {
            IStatusDisplay statusDisplay = (IStatusDisplay)this.FindForm();

            StopOtherWorker();
            
            List<string> filenames;
            if (this.chkFilename.Checked)
                filenames = this.GetAllFileList(this.chkSubdirs.Checked);
            else
                filenames = new List<string>();
            List<string> directories;
            if (this.chkDirectory.Checked)
                directories = this.GetAllDirectoryList(this.chkSubdirs.Checked);
            else
                directories = new List<string>();

            statusDisplay.WorkStart(filenames.Count + directories.Count);

            #region renaming files
            Features.Renamer.RenamerEngine renamer = new Features.Renamer.RenamerEngine(this.txtFilename.Text.Contains("%#"), !this.txtFilename.Text.Contains("%##"));
            
            filenames.Sort();
            foreach (string filename in filenames)
            {
                // get the new name form the metadata
                PictureMetaData pmd = new PictureMetaData(filename);
                string newname = FileNameFormater.FormatFilename(pmd, this.txtFilename.Text);
                newname = newname.Replace("%##", "%#");
                pmd.Close();

                if (newname != "")
                {
                    // open a file info
                    FileInfo fi = new FileInfo(filename);
                    newname = fi.DirectoryName + "\\" + newname;

                    // give the new name to the renamer
                    renamer.AddNewRenameItem(fi, newname);
                }

                // next
                statusDisplay.WorkNextPart();
            }

            // and now: do all the dirty working
            renamer.Rename();

            Settings.Default.FilenameFormats.AddIfGrowing(this.txtFilename.Text);
            #endregion

            string goToDir;
            #region renaming directories
            renamer = new Features.Renamer.RenamerEngine(this.txtDirectoryname.Text.Contains("%#"), !this.txtDirectoryname.Text.Contains("%##"));

            directories.Sort();
            foreach (string directory in directories)
            {
                // get the new name form the metadata
                PictureMetaData pmd;
                DirectoryInfo di = new DirectoryInfo(directory);
                bool dontClosePmd = false;
                if (this.currentDirectory == di.FullName && this.currentPicture != null)
                {
                    pmd = this.currentPicture;
                    dontClosePmd = true;
                }
                else
                    pmd = GetPictureMetaDataFromDirectory(di);

                if (pmd != null)
                {
                    string newname = FileNameFormater.FormatFilename(pmd, this.txtDirectoryname.Text);
                    newname = newname.Replace("%##", "%#");

                    if (!dontClosePmd)
                        pmd.Close();

                    if (newname != "")
                    {
                        // give the new name to the renamer
                        renamer.AddNewRenameItem(di, newname);
                    }
                }

                // next
                statusDisplay.WorkNextPart();
            }

            // and now: do all the dirty working
            DirectoryInfo curdi = new DirectoryInfo(this.currentDirectory);
            goToDir = curdi.Parent.FullName + "\\" +  renamer.GetNewName(this.currentDirectory);
            renamer.Rename();

            Settings.Default.DirectorynameFormats.AddIfGrowing(this.txtDirectoryname.Text);
            #endregion

            if (this.chkDirectory.Checked)
            {
                if ( Directory.Exists((goToDir)))
                    this.FireDirectoryNameChanged(goToDir);                
            }
            else
                this.FireDirectoryChanged();

            statusDisplay.WorkFinished();
        }

        //TODO
        private PictureMetaData GetPictureMetaDataFromDirectory(DirectoryInfo di)
        {
            FileInfo[] fis = di.GetFiles("*.jpg");
            if (fis.Length > 0)
            {
                return new PictureMetaData(fis[0].FullName);
            }
            else
                return null;
        }

    }
}