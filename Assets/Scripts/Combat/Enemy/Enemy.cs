using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
public class Enemy : PoolableObject 
{
    public EnemyMovement Movement;
    public NavMeshAgent Agent;
    public int Health; 
}
