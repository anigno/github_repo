using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.Patterns.StateMachinePattern
{
    public abstract class State
    {
        public delegate void StateActivityEventHandler(State state);
        
        public event StateActivityEventHandler OnEnterState;
        public event StateActivityEventHandler OnLeaveState;
        
        public abstract void RunState(params object[] stateParams);
 
        public void RaiseOnEnterState(State state)
        {
            if (OnEnterState != null) OnEnterState(state);
        }
        
        public void RaiseOnLeaveState(State state)
        {
            if (OnLeaveState != null) OnLeaveState(state);
        }

    }
}