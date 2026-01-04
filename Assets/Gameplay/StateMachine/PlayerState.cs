using UnityEngine;
using System.Collections.Generic;

public abstract class PlayerState
{
    protected PlayerState _playerstate;

    public abstract List<PlayerState> GetActiontData();
    public abstract void Idle();

    public abstract void Moving();

    public abstract void Airborne();


}
    
