using System;

namespace AnignoraCommonAndHelpers
{
    [Serializable]
    public abstract class UniqueIdBase
    {
		#region (------  Fields  ------)

        private static readonly object M_SYNC_ROOT = new object();
        private static uint s_uniqueId;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        protected UniqueIdBase()
        {
            lock (M_SYNC_ROOT)
            {
                Id = s_uniqueId++;
            }
        }

		#endregion (------  Constructors  ------)

		#region (------  Properties  ------)

        public uint Id { get; set; }

		#endregion (------  Properties  ------)
    }
}
