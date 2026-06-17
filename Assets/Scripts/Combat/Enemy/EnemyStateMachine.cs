using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; } = EnemyState.Idle;

    public void ChangeState(EnemyState newState)
    {
        if (CurrentState == newState)
            return;

        Debug.Log($"Enemy state changed: {CurrentState} -> {newState}");
        CurrentState = newState;
    }
}
