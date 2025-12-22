using UnityEngine;

public class StateCollection
{
    public StateSubIdle idleSTATE {get; private set;}
    public StateSubMovement moveSTATE {get; private set;}

    public StateCollection(PlayerGeneral playerGeneral, StateMachine stateMachine)
    {
        idleSTATE = new StateSubIdle(playerGeneral, stateMachine);
        moveSTATE = new StateSubMovement(playerGeneral, stateMachine);
    }
}
