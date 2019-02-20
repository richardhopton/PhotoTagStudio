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

namespace Schroeter.PhotoTagStudio.Data
{
    [Serializable]
    public class ModelStore<MODEL> where MODEL : ModelBase
    {
        private List<KeyValueStore<string, MODEL>> data = new List<KeyValueStore<string, MODEL>>();

        public List<KeyValueStore<string, MODEL>> Data
        {
            get { return data; }
            set { data = value; }
        }

        public ModelStore()
        {
            
        }

        public void Add(string name, MODEL model)
        {
            Delete(name);

            data.Add(new KeyValueStore<string, MODEL>(name, model));
        }

        public List<string> GetList()
        {
            List<string> l = new List<string>();

            foreach (KeyValueStore<string, MODEL> p in data)
                l.Add(p.Key);

            l.Sort();
            return l;
        }

        public MODEL Get(string name)
        {
            foreach (KeyValueStore<string, MODEL> p in data)
                if (p.Key == name)
                    return p.Value;

            return null;
        }

        public void Delete(string name)
        {
            foreach (KeyValueStore<string, MODEL> p in data)
                if (p.Key == name)
                {
                    data.Remove(p);
                    break;
                }
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }
    }
}
