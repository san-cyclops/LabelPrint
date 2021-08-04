using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ERP.Notification;

namespace ERP.Notification
{
    public class PopupNotifierCollection : System.Collections.CollectionBase
    {
        public PopupNotifierCollection()
        {
        }

        public PopupNotifier this[int index]
        {
            get { return (PopupNotifier)List[index]; }
            set { List[index] = value; }
        }

        public int Add(PopupNotifier item)
        {
            return this.List.Add(item);
        }

        public bool Contains(PopupNotifier item)
        {
            return this.List.Contains(item);
        }

        public void Remove(PopupNotifier item)
        {
            this.List.Remove(item);
        }

        public int IndexOf(PopupNotifier item)
        {
            return this.List.IndexOf(item);
        }

        public void Popup()
        {
            foreach (PopupNotifier item in List)
            {
                item.Popup(List.IndexOf(item));
            }

        }
    }
}
