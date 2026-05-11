using UnityEngine;

public class AiStateMachine
{
    public AiState[] states; //array of states that the state machine can be in
    public AiAgent agent; 
    public AiStateId currentState; //the current state that the state machine is in
    public AiStateMachine(AiAgent agent) //constructor for the state machine, 
    {                                    //takes in the agent that it will be controlling
        this.agent = agent;
        int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
        states = new AiState[numStates];
    }

    public void RegisterState(AiState state) //registers a state to the state machine, 
    {                                       //takes in the state to be registered
        int index = (int)state.GetId();
        states[index] = state; 
    }

    public AiState GetState(AiStateId stateId) 
    {                               
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(agent); //calls the update function of the current state
    }
    public void ChangeState(AiStateId newState)
    {
        GetState(currentState)?.Exit(agent); //calls the exit function of the current state
        currentState = newState; //changes the current state to the new state
        GetState(currentState)?.Enter(agent); //calls the enter function of the new state
    }
}
