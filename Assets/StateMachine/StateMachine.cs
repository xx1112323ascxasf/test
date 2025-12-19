using UnityEngine;

namespace HierarchicalSM
{
    public class StateMachine
    {
        public readonly State Root;
        public readonly TransitionSequencer Sequencer;

        public StateMachine(State root)
        {
            Root = root;
            Sequencer = new TransitionSequencer(this);

        }


    }




    public class TransitionSequencer
    {
        public readonly StateMachine Machine;
        public TransitionSequencer(StateMachine machine)
        {
            Machine = machine;
        }

        // Transition request from one state to another
        public void RequestTransition(State from, State to)
        {
            
        }
    }
}
