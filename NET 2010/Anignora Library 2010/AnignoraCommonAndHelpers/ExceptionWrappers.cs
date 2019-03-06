using System;
using System.Threading;

namespace AnignoraCommonAndHelpers
{
    public class ExceptionWrappers
    {
        public event EventHandler<EventArgs<Exception>> ExceptionThrown = delegate { };
        public Exception LastException { get; private set; }

        public bool ExceptionWrapper(Action p_action)
        {
            try
            {
                p_action();
                return true;
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionThrown(Thread.CurrentThread, new EventArgs<Exception>(ex));
            }
            return false;
        }

        public T ExceptionWrapper<T>(Func<T> p_func, T p_onExceptionReturnValue = default(T))
        {
            T t = p_onExceptionReturnValue;
            try
            {
                t = p_func();
            }
            catch (Exception ex)
            {
                LastException = ex;
                ExceptionThrown(Thread.CurrentThread, new EventArgs<Exception>(ex));
            }
            return t;
        }
    }
}