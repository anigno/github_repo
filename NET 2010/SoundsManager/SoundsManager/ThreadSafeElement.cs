namespace SoundsManager
{
    public class ThreadSafeElement<T>
    {
		#region (------  Fields  ------)

        private readonly object m_syncRoot = new object();
        private T m_value;

		#endregion (------  Fields  ------)

		#region (------  Properties  ------)

        public T Value
        {
            get
            {
                lock (m_syncRoot)
                {
                    return m_value;
                }
            }
            set
            {

                lock (m_syncRoot)
                {
                    m_value = value;
                }
            }
        }

		#endregion (------  Properties  ------)
    }
}