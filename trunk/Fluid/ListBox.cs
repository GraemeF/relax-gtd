﻿using System.Collections.Generic;

namespace Fluid
{
    public class ListBox : Control<ListBoxBuilder, ListBox>, IContainer
    {
        public IEnumerable<ListBoxItem> Items
        {
            get { return ListBoxItem.In(this); }
        }
    }
}