using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Schroeter.Windows.Forms
{
    public class TabControlWithHiddenTab : TabControl
    {
        private int pageCount = 1;
        private List<TabPage> allTabPages = new List<TabPage>();

        private ContextMenu menu;

        public event EventHandler<PageVisibleChangedByContextMenuEventArgs> PageVisibleChangedByContextMenu;

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            if (e.Control is TabPage)
            {
                TabPage page = (TabPage)e.Control;
                if (!allTabPages.Contains(page))
                {
                    page.Tag = pageCount++;
                    allTabPages.Add(page);

                    InvalidateContextMenu();
                }
            }
        }

        private void InvalidateContextMenu()
        {
            if (menu != null)
            {
                foreach (MenuItem m in menu.MenuItems)
                    m.Click -= new EventHandler(contextMenuItem_Click);

                menu = null;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if ( e.Button != MouseButtons.Right )
                return;

            if ( menu == null)
            {
                menu = new ContextMenu();
                foreach (TabPage page in allTabPages)
                {
                    MenuItem mi = new MenuItem(page.Text);
                    mi.Tag = page;
                    mi.Click += new EventHandler(contextMenuItem_Click);
                    mi.Checked = this.TabPages.Contains(page);
                    menu.MenuItems.Add(mi);
                }
                menu.MenuItems.Add("-");
                menu.MenuItems.Add("Show all", new EventHandler(contextMenuItem_Click));
                
            }

            menu.Show(this, e.Location);
            base.OnMouseClick(e);
        }

        void contextMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem) sender;
            TabPage page = item.Tag as TabPage;
            if (page != null)
            {
                item.Checked = !item.Checked;

                if (item.Checked)
                {
                    ShowPage(page);
                    if (PageVisibleChangedByContextMenu != null)
                        PageVisibleChangedByContextMenu(this, new PageVisibleChangedByContextMenuEventArgs(page, item.Checked));
                }
                else
                {
                    if (this.TabCount > 1)
                    {
                        HidePage(page);
                        if (PageVisibleChangedByContextMenu != null)
                            PageVisibleChangedByContextMenu(this, new PageVisibleChangedByContextMenuEventArgs(page, item.Checked));
                    }
                    else
                        item.Checked = !item.Checked;
                }
            }
            else
            {
                // show all menu item
                foreach (MenuItem i in menu.MenuItems)
                    if ( i.Tag != null && !i.Checked )
                        contextMenuItem_Click(i,new EventArgs());
            }
        }

        #region public methods
        private void HidePage(TabPage page)
        {
            if ( this.TabPages.Contains(page) )
                this.TabPages.Remove(page);
        }

        private void ShowPage(TabPage page)
        {
            if ( !this.TabPages.Contains(page) )
            {
                int numberOfNewPage = (int) page.Tag;

                for (int i = 0; i < this.TabPages.Count; i++)
                {
                    int numberOfCurrentPage = (int) this.TabPages[i].Tag;
                    if (numberOfCurrentPage > numberOfNewPage)
                    {
                        this.TabPages.Insert(i, page);
                        return;
                    }
                }
                this.TabPages.Add(page);
            }
        }

        public void PageVisible(TabPage page, bool setVisible)
        {
            if (setVisible)
                ShowPage(page);
            else
                HidePage(page);

            InvalidateContextMenu();
        }
        #endregion

        #region properties
        public List<TabPage> AllTabPages
        {
            get { return allTabPages; }
        }
        #endregion
    }

    public class PageVisibleChangedByContextMenuEventArgs : EventArgs
    {
        private TabPage page;
        private bool visible;


        public PageVisibleChangedByContextMenuEventArgs(TabPage page, bool visible)
        {
            this.page = page;
            this.visible = visible;
        }

        public TabPage Page
        {
            get { return page; }
            set { page = value; }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }
    }
}
