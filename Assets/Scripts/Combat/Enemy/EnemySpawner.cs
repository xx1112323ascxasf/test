using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn  : MonoBehaviour
{
    public Transform Player;
    public int NubmerOfEnemieToSpawn = 5; 
    public float SpawnDelay = 1f;
   
    public List<Enemy> EnemyPrefabs = new List<Enemy>(); //reference 

    private Dictionary<int, ObjectPool> EnemyObjectPools = new Dictionary<int, ObjectPool>(); //managing object pools for each enemy type
}
