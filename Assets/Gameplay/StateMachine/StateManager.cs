using Unity.VisualScripting;
using UnityEngine;

public class StateManager
{
    protected StateMachine stateMACHINE;
    protected PlayerGeneral playerGENERAL;

    public StateManager(PlayerGeneral playerGENERAL, StateMachine stateMACHINE)
    {
        this.playerGENERAL = playerGENERAL;
        this.stateMACHINE = stateMACHINE;
    }

    public virtual void Enter()
    {
        
    }
    public virtual void Exit()
    {
        
    }
    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void LateUpdate()
    {
        
    }
}
