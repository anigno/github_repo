using System;

namespace AnignoraDataTypes.Lists
{
    public class ListFilteredEventArgs<T> : EventArgs
    {
        public T Item { get; private set; }

        public ListFilteredEventArgs(T p_item)
        {
            Item = p_item;
        }
    }
}