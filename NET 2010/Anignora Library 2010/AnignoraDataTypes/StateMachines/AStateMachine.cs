
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnignoraDataTypes.StateMachines
{
    public enum RunDirectionEnum
    {
        RunForward,
        RunBackward
    }

    public class AStateMachine<T>
    {
        public Action<IEnumerable<T> > PreRunAction { get; set; }

		#region (------  Fields  ------)
        private AState<T> m_rootState = new AState<T>("_ROOT_STATE_");
		#endregion (------  Fields  ------)

		#region (------  Delegates  ------)
        public delegate void StateMachineAction<TD>(AState<TD> p_state, TD p_data);
		#endregion (------  Delegates  ------)

		#region (------  Events  ------)
        public event StateMachineAction<T> StateChanged = delegate { };

        public event StateMachineAction<T> StateFinal = delegate { };
		#endregion (------  Events  ------)

		#region (------  Properties  ------)
        public AState<T> CurrentState { get; private set; }

        public AState<T> RootState { get; set; }
		#endregion (------  Properties  ------)

		#region (------  Public Methods  ------)
        public AState<T> Run(IEnumerable<T> p_dataltems, RunDirectionEnum p_direction = RunDirectionEnum.RunForward)
        {
            if (RootState == null) throw new NullReferenceException("RootState cannot be null");
            if (p_direction == RunDirectionEnum.RunBackward)
            {
                p_dataltems = p_dataltems.Reverse();
            }
            if (PreRunAction != null) PreRunAction(p_dataltems);
            CurrentState = RootState;
            foreach (T data in p_dataltems)
            {
                CurrentState = CurrentState.GetNextState(data);
                StateChanged(CurrentState, data);

                if (CurrentState.IsFinal)
                {
                    StateFinal(CurrentState, data);
                    break;
                }
            }
            return CurrentState;
        }
		#endregion (------  Public Methods  ------)
    }
}