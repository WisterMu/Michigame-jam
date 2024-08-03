using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnControl : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] EnemySpawner;
    public int enemynum = 4;
    public float delayBeforeSpawn = 3f; 

    void Start()
    {
        StartCoroutine(SpawnEnemiesAfterDelay());
    }

    IEnumerator SpawnEnemiesAfterDelay()
    {
        
        yield return new WaitForSeconds(delayBeforeSpawn);

        
        SpawnEnemies();
    }



    void SpawnEnemies()
    {
        for (int i = 0; i < enemynum; i++)
        {

            int SpawnIndex = Random.Range(0, EnemySpawner.Length);
            Transform spawnPoint = EnemySpawner[SpawnIndex];

            Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        }
    }
}
