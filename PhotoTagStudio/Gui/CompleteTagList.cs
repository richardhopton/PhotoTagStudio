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
using System.Windows.Forms;

namespace Schroeter.PhotoTagStudio.Gui
{
    public partial class CompleteTagList : PictureDetailControlBase
    {
        public CompleteTagList()
            : base()
        {
            InitializeComponent();
        }

        protected override void ClearMyData()
        {
            this.treeView1.Nodes.Clear();
        }

        protected override void RefreshMyData()
        {
            if (this.currentPicture == null)
            {
                ClearData();
                return;
            }

            this.treeView1.BeginUpdate();

            this.treeView1.Nodes.Clear();

            Dictionary<string, TreeNode> roots = new Dictionary<string,TreeNode> ();

            IEnumerator<KeyValuePair<string, List<string>>> e = currentPicture.GetListEnumerator();
            while( e.MoveNext() )
            {
                KeyValuePair<string,List<string>> kvp = e.Current;

                TreeNode root = null;
                string[] parts = kvp.Key.Split('.');
                string prefix = "";
                for (int i = 0; i < parts.Length-1; i++)
                {
                    prefix += parts[i] + ".";
                    if(!roots.ContainsKey(prefix))
                    {
                        TreeNode n = new TreeNode(parts[i]);
                        n.ImageIndex = 0;
                        n.SelectedImageIndex = 0;
                        if (root == null)
                            this.treeView1.Nodes.Add(n);
                        else
                            root.Nodes.Add(n);

                        root = n;

                        roots.Add(prefix, root);
                    }
                    else
                        root = roots[prefix];
                }
               
                TreeNode c = new TreeNode();
                c.ImageIndex = 1;
                c.SelectedImageIndex = 1;
                if (kvp.Value.Count == 1)
                {
                    c.Text = parts[parts.Length - 1] + " = " + FormatTagText(kvp.Value[0]);
                    //try
                    //{
                    //    if (parts[parts.Length - 1] == "XMLPacket"
                    //        || parts[parts.Length - 1] == "IPTCNAA")
                    //    {
                    //        StringBuilder decode = new StringBuilder();
                    //        string[] ch = kvp.Value[0].Split(' ');
                    //        foreach (string cch in ch)
                    //        {
                    //            if (cch != "")
                    //            {
                    //                int i = int.Parse(cch);
                    //                if (i != 0)
                    //                {
                    //                    char y = (char)i;
                    //                    decode.Append(y);
                    //                }
                    //            }
                    //        }
                    //        c.Nodes.Add(decode.ToString());
                    //    }
                    //}
                    //catch(Exception ex)
                    //{
                    //    Console.WriteLine();
                    //}
                }
                else
                {
                    c.Text = parts[parts.Length - 1] + ":";
                    foreach (string s in kvp.Value)
                    {
                        TreeNode x = new TreeNode(FormatTagText(s));
                        x.ImageIndex = 2;
                        x.SelectedImageIndex = 2;
                        c.Nodes.Add(x);
                    }
                }
                root.Nodes.Add(c);
            }

            foreach (TreeNode n in this.treeView1.Nodes)
                n.Expand();

            this.treeView1.EndUpdate();
        }

        private string FormatTagText(string raw)
        {
            if (raw.Length > 50)
                return raw.Substring(0, 50) + "...";           
            else
                return raw;
        }
   }
}