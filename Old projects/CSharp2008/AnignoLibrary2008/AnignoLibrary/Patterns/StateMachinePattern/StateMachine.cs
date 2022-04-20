using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnignoLibrary.Patterns.StateMachinePattern
{
    public class StateMachine
    {
        public const string START_STATE_NAME = "StartState";
        private readonly Dictionary<string,State> _states=new Dictionary<string, State>();
        
        private State _currentState;
        public Dictionary<string, State> States
        {
            get { return _states; }
        }

        public void Start()
        {
            if (!States.ContainsKey(START_STATE_NAME)) throw new StateMAchineException("No StartState found");
            _currentState = States[START_STATE_NAME];
            RunState();
        }

        private void RunState(params object[] objects)
        {
            _currentState.RaiseOnEnterState(_currentState);
            _currentState.RunState(objects);
            _currentState.RaiseOnLeaveState(_currentState);
        }


    }
}
