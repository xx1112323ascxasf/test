using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;
    public float UpdateSpeed = 0.1f; // how frequently to update the path 


    [SerializeField] private Animator Animator; 
    [SerializeField] private NavMeshAgent Agent;
    private AgentLinkMover LinkMover; 

    private bool hasIsWalkingParameter;

    public const string IsWalking = "IsWalking";
    private const string Jump = "Jump";
    private const string Landed = "Landed";



    private void Awake()
    {
        if (Animator == null) Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        LinkMover = GetComponent<AgentLinkMover>();

        if (LinkMover != null)
        {
            LinkMover.OnLinkEnd += HandleLinkEnd;
            LinkMover.OnLinkStart += HandleLinkStart;
        }

        hasIsWalkingParameter = false;
        if (Animator != null)
        {
            var parms = Animator.parameters;
            for (int i = 0; i < parms.Length; i++)
            {
                if (parms[i].name == IsWalking)
                {
                    hasIsWalkingParameter = true;
                    break;
                }
            }
        }
    }

    public void Start()
    {
        StartCoroutine(FollowTarget());
        
    }
    public void Update()
    {
        if (Animator != null && hasIsWalkingParameter)
            Animator.SetBool(IsWalking, Agent.velocity.magnitude > 0.01f);
    }
    private void HandleLinkStart()
    {
        Animator.SetTrigger(Jump);
    }
    private void HandleLinkEnd()
    {
        Animator.SetTrigger(Landed);
    }
    private IEnumerator FollowTarget()
    {

        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);
        while (enabled)
        {
            Agent.SetDestination(Target.transform.position);

            yield return Wait;
        }
    }
}

