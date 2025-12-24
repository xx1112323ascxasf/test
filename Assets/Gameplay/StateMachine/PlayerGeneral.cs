using HierarchicalSM;
using TMPro;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour
{
    StateMachine StateMachine;
    public StateMachine stateMachine => StateMachine;

    StateCollection States;
    public StateCollection STATES => States;


    InputProcessor InputProcessor;
    
    public InputProcessor inputPROCESSOR => InputProcessor;
    
    PlayerM



    [Header("Component")]
    [SerializeField] Rigidbody RigitBody;
    [SerializeField] PlayerConfiguration PlayerConfiguration;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI CurrentState;

    void Awake()
    {
        StateMachine = new StateMachine();
        States = new StateCollection(this, StateMachine); 
        InputProcessor = new InputProcessor();
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
