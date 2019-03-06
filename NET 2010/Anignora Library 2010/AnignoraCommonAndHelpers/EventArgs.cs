using System;

namespace AnignoraCommonAndHelpers
{
    public class EventArgs<T> : EventArgs
    {
        public T Item { get; private set;  }
    

        public EventArgs(T p_t)
        {
            Item = p_t;
        }
    }
}