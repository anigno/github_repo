using System;

namespace AnignoLibrary.Patterns.StateMachinePattern
{
    public class StateMAchineException : Exception
    {
        public StateMAchineException(string format, params object[] objects)
            : base(string.Format(format, objects))
        {
            //Nothing
        }

    }
}