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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Schroeter.KmlGenerator;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;

namespace Schroeter.PhotoTagStudio.Features.KmzMaker
{
    public partial class KmzMakerForm : Form
    {
        PictureMetaData currentPicture;
        GetAllFilesDelegate getAllFilesDelegate;
        
        public KmzMakerForm()
        {
            InitializeComponent();

            this.Icon = Resources.PTS;
        }

        public KmzMakerForm(PictureMetaData currentPicture, string currentDirectory, GetAllFilesDelegate getAllFilesDelegate)
            : this()
        {
            this.currentPicture = currentPicture;
            this.getAllFilesDelegate = getAllFilesDelegate;
            
            if ( currentPicture != null )
            {
                FileInfo fi = new FileInfo(currentPicture.Filename);
                this.txtKmzFile.Text = currentPicture.Filename.Substring(0, currentPicture.Filename.Length - fi.Extension.Length) + ".kmz";

                this.txtName.Text = currentPicture.IptcObjectName;
            }
            else
            {
                if  ( currentDirectory != "" && !currentDirectory.StartsWith("::"))
                {
                    DirectoryInfo di = new DirectoryInfo(currentDirectory);
                    this.txtKmzFile.Text = di.FullName + ".kmz";
                    this.txtName.Text = di.Name;
                }

                this.radSelected.Checked = true;
                this.radOneFile.Enabled = false;
            }

            this.chkOpen.Checked = Settings.Default.KmzOpenFile;
        }
        
        private Placemark PlacemarkFromPicture(PictureMetaData pic)
        {
            if ( pic.GpsLongitude == null || pic.GpsLatitude == null )
                return null;

            Placemark p = new Placemark();
            p.Name = pic.IptcObjectName;
            p.Description = pic.IptcCaption;
            p.Latitude = (double) pic.GpsLatitude.GetValue( pic.GpsLatitudeRef == "S" );
            p.Longitude = (double) pic.GpsLongitude.GetValue( pic.GpsLongitudeRef == "W" );
            p.Tilt = Settings.Default.KmzTilt;
            p.Heading = Settings.Default.KmzHeading;
            p.Range = Settings.Default.KmzRange;

            ImageResize.Dimensions d;
            if ( pic.Image.Height > pic.Image.Width )
                d = ImageResize.Dimensions.Height;
            else
                d = ImageResize.Dimensions.Width;

            Image i = ImageResize.ConstrainProportions(pic.Image, Settings.Default.KmzPictureSize , d);
            p.SetImage(new FileInfo(pic.Filename).Name, i );
            
            return p;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            Settings.Default.KmzOpenFile = this.chkOpen.Checked;

            if (this.txtKmzFile.Text == "")
                return;

            KmlDocument doc = new KmlDocument();
            doc.Name = this.txtName.Text;

            // create placemarks for photos (one, selectend or subdirs)
            if (this.radOneFile.Checked)
            {
                Placemark placemark = PlacemarkFromPicture(currentPicture);
                if ( placemark != null)
                    doc.Placemarks.Add(placemark);
            }
            else if ( this.radSelected.Checked )
            {
                List<string> filenames = this.getAllFilesDelegate(false);
                foreach (string filename in filenames)
                {
                    PictureMetaData pmd = new PictureMetaData(filename);
                    Placemark placemark = PlacemarkFromPicture(pmd);
                    if ( placemark != null)
                        doc.Placemarks.Add(placemark);
                    pmd.Close();
                }
            }
            else if ( this.radSubdirs.Checked )
            {
                List<string> filenames = this.getAllFilesDelegate(false);
                foreach (string filename in filenames)
                {
                    PictureMetaData pmd = new PictureMetaData(filename);
                    Placemark placemark = PlacemarkFromPicture(pmd);
                    if ( placemark != null)
                        doc.Placemarks.Add(placemark);
                    pmd.Close();
                }

                FileInfo fi = new FileInfo(filenames[0]);
                DirectoryInfo startdi = fi.Directory;
                foreach(DirectoryInfo di in startdi.GetDirectories())
                    doc.Folders.Add( CreateFolder(di)  );
            }
            
            // create route
            if ( this.chkRoute.Checked && File.Exists(this.txtRouteFile.Text))
            {
                GpsLog log = GpsLogFactory.FromFile(this.txtRouteFile.Text);

                PlacemarkLine p = new PlacemarkLine();
                p.LineWidth = Settings.Default.KmzLineWidth;
                p.LineColor = Settings.Default.KmzLineColor;
                p.Name = "route";
                foreach (GpsLogEntry l in log)
                    p.Coordinates.Add(new Coordinate(l.Longitude, l.Latitude));
                doc.Placemarks.Add(p);
            }

            if (doc.IsEmpty)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show("No photos with GPS data found and no kmz-file created.", "PhotoTagStudio",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KmzArchiv arc = new KmzArchiv(doc);
                arc.Create(this.txtKmzFile.Text);

                this.Cursor = Cursors.Default;

                if (this.chkOpen.Checked)
                    System.Diagnostics.Process.Start(this.txtKmzFile.Text);
            }
            
        }

        private Folder CreateFolder(DirectoryInfo directory)
        {
            Folder folder = new Folder(directory.Name);
            
            foreach (FileInfo fi in directory.GetFiles("*.jpg"))
            {
                PictureMetaData pmd = new PictureMetaData(fi.FullName);
                Placemark placemark = PlacemarkFromPicture(pmd);
                if ( placemark != null )
                    folder.Placemarks.Add(placemark);
                pmd.Close();
            }

            foreach (DirectoryInfo di in directory.GetDirectories())
                folder.Folders.Add( CreateFolder(di) );

            return folder;
        }
        
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "Google Earth (*.kmz)|*.kmz";
            if (d.ShowDialog(this) == DialogResult.OK)
                this.txtKmzFile.Text = d.FileName;
        }

        private void btnSelectRouteFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "*.txt|*.txt";
            d.FileName = this.txtRouteFile.Text;
            if (d.ShowDialog(this) == DialogResult.OK)
                this.txtRouteFile.Text = d.FileName;
        }

        private void chkRoute_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRouteFile.Enabled = this.chkRoute.Checked;
            this.btnSelectRouteFile.Enabled = this.chkRoute.Checked;
        }
        
        public string GpsRouteFile
        {
            set
            {
                this.txtRouteFile.Text = value;
            }
            get
            {
                if (this.chkRoute.Checked)
                    return this.txtRouteFile.Text;
                else
                    return "";
            }
        }
    }
}