using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform Target;



    [SerializeField] private Animator Animator; 
    [SerializeField] private NavMeshAgent Agent;
    private AgentLinkMover LinkMover; 

    private const string IsWalking = "IsWalking";
    private const string Jump = "Jump";
    private const string Landed = "Landed";


    
    public float UpdateSpeed = 0.1f; // how frequently to update the path 
   

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        LinkMover = GetComponent<AgentLinkMover>();

        LinkMover.OnLinkEnd += HandleLinkEnd;
        LinkMover.OnLinkStart += HandleLinkStart;

        
    }

    public void Start()
    {
        StartCoroutine(FollowTarget());
        
    }
    public void Update()
    {
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

