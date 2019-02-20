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
using System.Windows.Forms;
using System.Xml.Serialization;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Gui;
using Schroeter.PhotoTagStudio.Properties;
using Schroeter.PhotoTagStudio.Workers;

namespace Schroeter.PhotoTagStudio.Data
{
    [MacroEnabled("IPTC",typeof(IptcView), typeof(IptcWorker))]
    public class IptcModel : ModelBase
    {
        public event EventHandler KeywordsCheckedChanged;

        private string headline = "";
        private string caption = "";
        private string objectName = "";
        private string writer = "";
        private string author = "";
        private string copyright = "";
        private string contact = "";
        private string city = "";
        private string sublocation = "";
        private string provinceState = "";
        private string countryName = "";
        private string countryCode = "";
        private DateTime created = DateTime.MinValue;

        private bool headlineChecked = false;
        private bool captionChecked = false;
        private bool objectNameChecked = false;
        private bool writeChecked = false;
        private bool authorChecked = false;
        private bool copyrightChecked = false;
        private bool contactChecked = false;
        private bool cityChecked = false;
        private bool sublocationChecked = false;
        private bool provinceStateChecked = false;
        private bool countryNameChecked = false;
        private bool countryCodeChecked = false;
        private bool createdChecked = false;
        private bool keywordChecked = false;

        private bool getDateFromExifChecked = false;

        private List<string> keywordsChecked = new List<string>();
        private List<string> keywordsUnchecked = new List<string>();
        private List<string> keywordsBold = new List<string>();
        private Dictionary<string,string> newKeywordWithGroups = new Dictionary<string, string>();

        public IptcModel()
        {}

        public IptcModel(PictureMetaData pmd)
        {
            if (pmd == null)
                return;

            this.headline = Util.unNull(pmd.IptcHeadline);
            this.caption = Util.unNull(pmd.IptcCaption);
            this.objectName = Util.unNull(pmd.IptcObjectName);
            this.copyright = Util.unNull(pmd.IptcCopyright);
            this.city = Util.unNull(pmd.IptcCity);
            this.sublocation = Util.unNull(pmd.IptcSubLocation);
            this.provinceState = Util.unNull(pmd.IptcProvinceState);
            this.countryName = Util.unNull(pmd.IptcCountryName);
            this.countryCode = Util.unNull(pmd.IptcCountryCode);

            if (pmd.ListByline().Count > 0)
                this.author = pmd.ListByline()[0];

            if (pmd.ListWriter().Count > 0)
                this.writer = pmd.ListWriter()[0];

            if (pmd.ListContact().Count > 0)
                this.contact = pmd.ListContact()[0];

            if (pmd.IptcDateTimeCreated.HasValue)
                this.created = pmd.IptcDateTimeCreated.Value;
            else
                this.created = DateTime.MinValue;

            foreach (string s in pmd.ListKeyword())
            {
                keywordsBold.Add(s);
                keywordsChecked.Add(s);
            }
        }

        public void SetKeyword(string name, CheckState b)
        {
            if (b == CheckState.Checked)
            {
                if (!KeywordsChecked.Contains(name))
                    KeywordsChecked.Add(name);
                KeywordsUnchecked.Remove(name);
            }
            else if (b == CheckState.Unchecked)
            {
                if (!KeywordsUnchecked.Contains(name))
                    KeywordsUnchecked.Add(name);
                KeywordsChecked.Remove(name);
            }
            else
            {
                KeywordsUnchecked.Remove(name);
                KeywordsChecked.Remove(name);
            }

            KeywordChecked = true;

            if (KeywordsCheckedChanged != null)
                KeywordsCheckedChanged(this, new EventArgs());

            SetDirty();
        }

        public void SetNewKeyword(string name, string group)
        {
            if ( !this.newKeywordWithGroups.ContainsKey(name) )
                this.newKeywordWithGroups.Add(name,group);
        }
        
        #region Properties

        public string Headline
        {
            get { return headline; }
            set
            {
                SetDirty();
                headline = value;
                if (enableSpecialUpdateLogic)
                    HeadlineChecked = true;
            }
        }

        public string Caption
        {
            get { return caption; }
            set
            {
                SetDirty();
                caption = value;
                if (enableSpecialUpdateLogic)
                    CaptionChecked = true;
            }
        }

        public string ObjectName
        {
            get { return objectName; }
            set
            {
                SetDirty();
                objectName = value;
                if (enableSpecialUpdateLogic)
                    ObjectNameChecked = true;
            }
        }

        public string Writer
        {
            get { return writer; }
            set
            {
                SetDirty();
                writer = value;
                if (enableSpecialUpdateLogic)
                    WriteChecked = true;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                SetDirty();
                author = value;
                if (enableSpecialUpdateLogic)
                    AuthorChecked = true;
            }
        }

        public string Copyright
        {
            get { return copyright; }
            set
            {
                SetDirty();
                copyright = value;
                if (enableSpecialUpdateLogic)
                    CopyrightChecked = true;
            }
        }

        public string Contact
        {
            get { return contact; }
            set
            {
                SetDirty();
                contact = value;
                if (enableSpecialUpdateLogic)
                    ContactChecked = true;
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                SetDirty();
                city = value;
                if (enableSpecialUpdateLogic)
                    CityChecked = true;
            }
        }

        public string Sublocation
        {
            get { return sublocation; }
            set
            {
                SetDirty();
                sublocation = value;
                if (enableSpecialUpdateLogic)
                    SublocationChecked = true;
            }
        }

        public string ProvinceState
        {
            get { return provinceState; }
            set
            {
                SetDirty();
                provinceState = value;
                if (enableSpecialUpdateLogic)
                    ProvinceStateChecked = true;
            }
        }

        public string CountryName
        {
            get { return countryName; }
            set
            {
                SetDirty();
                countryName = value;
                if (enableSpecialUpdateLogic)
                    CountryNameChecked = true;
            }
        }

        public string CountryCode
        {
            get { return countryCode; }
            set
            {
                SetDirty();
                countryCode = value;
                if (enableSpecialUpdateLogic)
                    CountryCodeChecked = true;
            }
        }

        public DateTime Created
        {
            get { return created; }
            set
            {
                SetDirty();
                created = value;
                if (enableSpecialUpdateLogic)
                    CreatedChecked = true;
            }
        }

        public bool HeadlineChecked
        {
            get { return headlineChecked; }
            set { SetDirty(); headlineChecked = value; }
        }

        public bool CaptionChecked
        {
            get { return captionChecked; }
            set { SetDirty(); captionChecked = value; }
        }

        public bool ObjectNameChecked
        {
            get { return objectNameChecked; }
            set { SetDirty(); objectNameChecked = value; }
        }

        public bool WriteChecked
        {
            get { return writeChecked; }
            set { SetDirty(); writeChecked = value; }
        }

        public bool AuthorChecked
        {
            get { return authorChecked; }
            set { SetDirty(); authorChecked = value; }
        }

        public bool CopyrightChecked
        {
            get { return copyrightChecked; }
            set { SetDirty(); copyrightChecked = value; }
        }

        public bool ContactChecked
        {
            get { return contactChecked; }
            set { SetDirty(); contactChecked = value; }
        }

        public bool CityChecked
        {
            get { return cityChecked; }
            set { SetDirty(); cityChecked = value; }
        }

        public bool SublocationChecked
        {
            get { return sublocationChecked; }
            set { SetDirty(); sublocationChecked = value; }
        }

        public bool ProvinceStateChecked
        {
            get { return provinceStateChecked; }
            set { SetDirty(); provinceStateChecked = value; }
        }

        public bool CountryNameChecked
        {
            get { return countryNameChecked; }
            set { SetDirty(); countryNameChecked = value; }
        }

        public bool CountryCodeChecked
        {
            get { return countryCodeChecked; }
            set { SetDirty(); countryCodeChecked = value; }
        }

        public bool CreatedChecked
        {
            get { return createdChecked; }
            set
            {
                createdChecked = value;
                if (!createdChecked && getDateFromExifChecked)
                {
                    getDateFromExifChecked = false;
                    SetDirty();
                }
            }
        }

        public bool KeywordChecked
        {
            get { return keywordChecked; }
            set { SetDirty(); keywordChecked = value; }
        }

        public bool GetDateFromExifChecked
        {
            get { return getDateFromExifChecked; }
            set
            {
                SetDirty();
                getDateFromExifChecked = value;
                Created = DateTime.MinValue;
                CreatedChecked = value;
            }
        }

        public List<string> KeywordsChecked
        {
            get { return keywordsChecked; }
            set
            {
                keywordsChecked = value;
            }
        }

        public List<string> KeywordsUnchecked
        {
            get { return keywordsUnchecked; }
            set
            {
                keywordsUnchecked = value;
            }
        }

        [XmlIgnore]
        public List<string> KeywordsBold
        {
            get { return keywordsBold; }
            set { keywordsBold = value; }
        }

        [XmlIgnore]
        public Dictionary<string, string> NewKeywordWithGroups
        {
            get { return newKeywordWithGroups; }
            set { newKeywordWithGroups = value; }
        }
        #endregion

        [XmlIgnore]
        public bool PendingUpdates
        {
            get
            {
                return headlineChecked ||
                        captionChecked ||
                        objectNameChecked ||
                        writeChecked ||
                        authorChecked ||
                        copyrightChecked ||
                        contactChecked ||
                        cityChecked ||
                        sublocationChecked ||
                        provinceStateChecked ||
                        countryNameChecked ||
                        countryCodeChecked ||
                        createdChecked ||
                        keywordChecked;         
            }
        }

        public void UpdatePicture(PictureMetaData pmd)
        {
            if (pmd == null)
                return;

            if (headlineChecked)
                pmd.IptcHeadline = Util.nullAsEmpty(headline);
            if (captionChecked)
                pmd.IptcCaption = Util.nullAsEmpty(caption);
            if (objectNameChecked)
                pmd.IptcObjectName = Util.nullAsEmpty(objectName);
            if (copyrightChecked)
                pmd.IptcCopyright = Util.nullAsEmpty(copyright);
            if (cityChecked)
                pmd.IptcCity = Util.nullAsEmpty(city);
            if (sublocationChecked)
                pmd.IptcSubLocation = Util.nullAsEmpty(sublocation);
            if (provinceStateChecked)
                pmd.IptcProvinceState = Util.nullAsEmpty(provinceState);
            if (countryNameChecked)
                pmd.IptcCountryName = Util.nullAsEmpty(countryName);
            if (countryCodeChecked)
                pmd.IptcCountryCode = Util.nullAsEmpty(countryCode);

            if (authorChecked)
            {
                pmd.ClearByline();
                if ( author != "" )
                    pmd.AddByline(author);
            }
            if (writeChecked)
            {
                pmd.ClearWriter();
                if (writer != "")
                    pmd.AddWriter(writer);
            }
            if (contactChecked)
            {
                pmd.ClearContact();
                if (contact != "")
                    pmd.AddContact(contact);
            }

            if (createdChecked)
            {
                if (getDateFromExifChecked)
                    pmd.IptcDateTimeCreated = pmd.ExifOriginalDateTime;
                else
                {
                    if ( created != DateTime.MinValue )
                        pmd.IptcDateTimeCreated = created;
                    else
                        pmd.IptcDateTimeCreated = null;
                }
            }

            if (keywordChecked)
            {
                List<string> allKeywords = pmd.ListKeyword();
                foreach (string s in keywordsChecked)
                    if (!allKeywords.Contains(s))
                        pmd.AddKeyword(s);
                foreach (string s in keywordsUnchecked)
                    if (allKeywords.Contains(s))
                        pmd.RemoveKeyword(s);
            }
        }

        public void UpdateSettings()
        {
            if (captionChecked)
                Settings.Default.Captions.AddIfGrowing(caption);
            if (copyrightChecked)
                Settings.Default.Copyrights.AddIfGrowing(copyright);
            if (headlineChecked)
                Settings.Default.Headlines.AddIfGrowing(headline);
            if (objectNameChecked)
                Settings.Default.Objectnames.AddIfGrowing(objectName);
            if (authorChecked)
                Settings.Default.Authors.AddIfGrowing(author);
            if (contactChecked)
                Settings.Default.Contacts.AddIfGrowing(contact);
            if (writeChecked)
                Settings.Default.Writers.AddIfGrowing(writer);

            if (cityChecked || sublocationChecked || provinceStateChecked || countryCodeChecked || countryNameChecked)
            {
                Location l = new Location();
                l.City = city;
                l.Sublocation = sublocation;
                l.State = provinceState;
                l.CountryName = countryName;
                l.CountryCode = countryCode;
                Settings.Default.Locations.AddIfGrowing(l);
            }

            if (keywordChecked)
                foreach (KeyValuePair<string, string> pair in newKeywordWithGroups)
                    if (keywordsChecked.Contains(pair.Key))
                        Settings.Default.GroupedKeywords.AddIfGrowing(pair.Key, pair.Value);
        }
    }
}

