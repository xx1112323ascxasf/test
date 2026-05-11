using UnityEngine;

public class AiAgent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AiStateMachine stateMachine; 
    public AiStateId initialState; //the initial state that the agent will be in when the game starts
    void Start()
    {
        stateMachine = new AiStateMachine(this); //create a new state machine for this agent
        stateMachine.ChangeState(initialState); //set the initial state of the state machine to the initial state specified in the inspector
    }
    

    
    void Update()
    {
        stateMachine.Update(); 
    }


}
