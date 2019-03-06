using System;
using System.Reactive.Subjects;
using System.Threading;

namespace SymbolAnalysis.Creatures
{
    public abstract class CreatureBase : ICreature
    {
        #region Constructors

        protected CreatureBase(sbyte[] p_dnaBytes)
        {
            UniqueId = Interlocked.Increment(ref s_uniqueIdCounter);

            DnaBytes = p_dnaBytes;
            Success = 0;
            Age = 0;
            m_timer = new Timer(timerCallback);
        }

        #endregion

        #region Abstracts

        /// <summary>
        /// Evolve to a new creature and initialize it
        /// </summary>
        /// <returns>New Creature</returns>
        public abstract ICreature Evolve();

        public abstract bool IsDieCondition();
        public abstract bool IsEvolveCondition();

        /// <summary>
        /// Search the next location in the world, update success
        /// </summary>
        /// <returns></returns>
        public abstract float Search();

        #endregion

        #region Public Methods

        public void Kill()
        {
            m_timer.Change(-1, -1);
            IsAlive = false;
            m_onDied.OnNext(this);
        }
        protected sbyte[] DuplicateDna()
        {
            sbyte[] newDna = new sbyte[DnaBytes.Length];
            Buffer.BlockCopy(DnaBytes, 0, newDna, 0, newDna.Length);
            return newDna;
        }

        public void Start()
        {
            m_timer.Change(StepIntervalMs, StepIntervalMs);
        }

        #endregion

        #region Public Properties

        public uint Age { get; private set; }
        public long UniqueId { get; private set; }
        public sbyte[] DnaBytes { get; protected set; }
        public bool IsAlive { get; private set; }

        public IObservable<ICreature> OnDied
        {
            get { return m_onDied; }
        }

        public int StepIntervalMs { get; protected set; }
        public float Success { get; protected set; }

        #endregion

        #region Private Methods

        private void timerCallback(object p_state)
        {
            Age++;
            Success = Search();
            if (IsEvolveCondition())
            {
                ICreature newCreature = Evolve();
                newCreature.Start();
            }
            if (IsDieCondition())
            {
                Kill();
            }
        }

        #endregion

        #region Fields

        private static long s_uniqueIdCounter;

        private readonly Subject<ICreature> m_onDied = new Subject<ICreature>();

        private readonly Timer m_timer;

        #endregion
    }
}