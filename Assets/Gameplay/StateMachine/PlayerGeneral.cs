using HierarchicalSM;
using TMPro;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{
    StateMachine StateMachine;
    public StateMachine stateMachine => StateMachine;

    StateCollection States;
    public StateCollection STATES => States;

    [Header("Component")]
    [SerializeField] Rigidbody RigitBody;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI CurrentState;

    void Awake()
    {
        StateMachine = new StateMachine();
        States = new StateCollection(this, StateMachine); 
    }
    void Start()
    {
        StateMachine.Init(States.idleSTATE);
    }

    void Update()
    {
        StateMachine.state.Update();
        CurrentState.text = StateMachine.state.ToString();
    }
    private void FixedUpdate()
    {
        StateMachine.state.FixedUpdate();
    }
    private void LateUpdate()
    {
        StateMachine.state.LateUpdate();
    }


}
