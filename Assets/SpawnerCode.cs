using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCode : MonoBehaviour
{
    public GameObject applePrefab;
    public float spawnTime;
    public float spawnDelay;

    void Start()
    {
        InvokeRepeating("spawnApples", spawnTime, spawnDelay);
    }

    

    public void spawnApples()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-5, 5), Random.Range(3.50f, 5), 0);
        Instantiate(applePrefab, randomSpawnPosition, Quaternion.identity);
    }
    
        
            

          
    
    
}
