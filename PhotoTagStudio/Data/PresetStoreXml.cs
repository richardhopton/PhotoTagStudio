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

namespace Schroeter.PhotoTagStudio.Data
{
    public class PresetStoreXml
    {
        public PresetStoreXml()
        {
        }

        #region presets
        private List<object> models = new List<object>();

        public void AddPresetModel<MODEL>(string name, MODEL model) where MODEL : ModelBase
        {
            ModelStore<MODEL> s = GetModelStore<MODEL>(true);
            s.Add(name, model);
        }

        public MODEL GetPresetModel<MODEL>(string name) where MODEL : ModelBase
        {
            ModelStore<MODEL> s = GetModelStore<MODEL>(false);
            if (s == null)
                return null;

            return s.Get(name);
        }

        public List<string> GetAllPresetModelNames<MODEL>() where MODEL : ModelBase
        {
            ModelStore<MODEL> s = GetModelStore<MODEL>(false);
            if (s == null)
                return new List<string>();

            return s.GetList();
        }

        public void DeletePresetModel<MODEL>(string name) where MODEL : ModelBase
        {
            ModelStore<MODEL> s = GetModelStore<MODEL>(false);
            if ( s == null )
                return;

            s.Delete(name);

            if (s.Count == 0)
                models.Remove(s);
        }

        private ModelStore<MODEL> GetModelStore<MODEL>(bool create) where MODEL : ModelBase
        {
            foreach (object o in models)
                if ( o is ModelStore<MODEL>)
                    return (ModelStore<MODEL>)o;

            if (create)
            {
                ModelStore<MODEL> s = new ModelStore<MODEL>();
                models.Add(s);
                return s;
            }
            else
                return null;
        }
        #endregion

        #region last models
        private List<ModelBase> lastModels = new List<ModelBase>();

        public MODEL GetLastModel<MODEL>() where MODEL : ModelBase
        {
            foreach (ModelBase o in lastModels)
                if (o is MODEL)
                    return (MODEL)o;

            return null;
        }

        public void SaveLastModel<MODEL>(MODEL model) where MODEL : ModelBase
        {
            foreach (ModelBase o in lastModels)
                if (o is MODEL)
                {
                    lastModels.Remove(o);
                    break;
                }

            lastModels.Add(model);
        }
        #endregion

        #region getter und setter for xmlserializable
        public List<ModelBase> LastModels
        {
            get { return lastModels; }
            set { lastModels = value; }
        }
        public List<object> Models
        {
            get { return models; }
            set { models = value; }
        }
        #endregion
    }
}
