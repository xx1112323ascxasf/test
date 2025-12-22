using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace HierarchicalSM
{
    public class StateMachine
    {
        public readonly State Root;
        public readonly TransitionSequencer Sequencer;

        bool statred;

        public StateMachine(State root)
        {
            Root = root;
            Sequencer = new TransitionSequencer(this);

        }

        public void Start()
        {
            if (statred) return;

            statred = true;
            Root.Enter(); 
        }

        public void Tick(float deltaTime)
        {
            if(!statred) Start();
            
        }

        internal void InternalTick(float deltaTime) => Root.Update(deltaTime);


        // Perform the actual switch from 'from' to 'to' by existing up to the shared ancestor, then entering down  to the target

        public void ChangeState(State from, State to)
        {
            if (from == to || from == null || to == null) return;

            State lca = TransitionSequencer.Lca(from,to);

            // Exit current bracnch up to (but not include) LCA

            for (State s = from; s != lca; s = s.Parent) s.Exit();

            // Enter targer bracnh from LCA down to target

            var stack = new Stack<State>();
            for(State s = to; s != lca; s = s.Parent) stack.Push(s);
            while (stack.Count > 0) stack.Pop().Enter();
        }





    }

    // public class TransitionSequencer
    // {
    //     public readonly StateMachine Machine;
    //     public TransitionSequencer(StateMachine machine)
    //     {
    //         Machine = machine;
    //     }

    //     // Transition request from one state to another
    //     public void RequestTransition(State from, State to)
    //     {
    //         Machine.ChangeState(from, to);
    //     }

    //     // Compute the lowest common Ancestor of two states
    //     public static State Lca(State a, State b)
    //     {
    //         //create a set of all parent of 'a'
    //         var ap = new HashSet<State>();
    //         for (var s = a; s != null; s = s.Parent) ap.Add(s);

    //         //find the first parent of 'b' that is also parent of 'a'
    //         for (var s = b; s != null; s = s.Parent)
    //             if (ap.Contains(s)) return s;


    //         // if no common ancestor found, return null
    //         return null;

    //     }

}


