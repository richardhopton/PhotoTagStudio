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

namespace Schroeter.Photo
{
    public class PictureMetaDataEnumerator : IEnumerator< KeyValuePair<string, string> >
    {
        private Dictionary<string, List<string>> tags;
        private IEnumerator<string> enumDict;
        private IEnumerator<string> enumList;
        private bool dictHasNext;
        private bool listHasNext;

        public PictureMetaDataEnumerator(Dictionary<string, List<string>> tags)
        {
           this.tags = tags;

           this.Reset();
       }

        #region IEnumerator< KeyValuePair<string,string> > Members

        public KeyValuePair<string, string> Current
        {
            get
            {
                return new KeyValuePair<string, string>(enumDict.Current, enumList.Current);
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get 
            {
                return this.Current;
            }
        }

        public bool MoveNext()
        {
            if (this.listHasNext)
            {
                this.listHasNext = this.enumList.MoveNext();
                if ( this.listHasNext )
                    return true;

            }
            
            if (this.dictHasNext)
            {
                this.dictHasNext = this.enumDict.MoveNext();
                if (this.dictHasNext)
                {
                    this.enumList = this.tags[this.enumDict.Current].GetEnumerator();
                    this.listHasNext = this.enumList.MoveNext();
                    return true;
                }
            }

            return false;
        }

        public void Reset()
        {
            this.enumDict = this.tags.Keys.GetEnumerator();
            this.dictHasNext = true;
            this.listHasNext = false;
        }

        #endregion
    }
}