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

        internal void Enter()
        {
            if (Parent != null) Parent.ActiveChild = this;
            OnEnter();
            State init = GetInitialState();
            if (init != null) init.Enter();
        }

        internal void Exit()
        {
            if (ActiveChild != null) ActiveChild.Exit();
            ActiveChild = null;
            OnExit();
        }
         
        public void Update(float deltaTime)
        {
            State t = GetTransition();
            if (t != null)
            {
                Machine.Sequencer.RequestTransition(this, t);
                return;
            }
        } 

    }



  

}


