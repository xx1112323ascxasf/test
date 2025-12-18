using UnityEngine;


namespace HierarchicalSM
{
    public abstract class State
    {
        public readonly StateMachine Machine;
        public readonly State Parent;
        public State ActiveChild;

        public State(StateMachine machine, State parent = null)
        {
            Machine = machine;
            Parent = parent;
        }

        protected virtual State GetInitialState() => null;
        protected virtual State GetTransition()=> null;

        protected virtual void OnEnter(){}
        protected virtual void OnExit(){}
        protected virtual void OnUpdate(float deltaTime) {} 

    }


    public class StateMachine{}

    public class TransitionSequencer{}

}


