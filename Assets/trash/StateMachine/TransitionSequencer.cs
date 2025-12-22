using System.Collections.Generic;
using UnityEngine;


namespace HierarchicalSM
{

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
            Machine.ChangeState(from, to);
        }

        // Compute the lowest common Ancestor of two states
        public static State Lca(State a, State b)
        {
            //create a set of all parent of 'a'
            var ap = new HashSet<State>();
            for (var s = a; s != null; s = s.Parent) ap.Add(s);

            //find the first parent of 'b' that is also parent of 'a'
            for (var s = b; s != null; s = s.Parent)
                if (ap.Contains(s)) return s;


            // if no common ancestor found, return null
            return null;

        }
    }
}