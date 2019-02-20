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
using System.Text;
using Schroeter.Photo;
using Schroeter.PhotoTagStudio.Data;

namespace Schroeter.PhotoTagStudio.Workers
{
    public class IptcWorker : SingleFileWorkerBase<IptcModel>
    {
        public override bool ProcessFile(PictureMetaData pmd, IptcModel model)
        {
            if ( model.PendingUpdates )
                model.UpdatePicture(pmd);

            return model.PendingUpdates;
        }
    }
}
