using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnControl : MonoBehaviour
{
    public GameObject enemy;
    public GameObject Boss;
    public Transform[] EnemySpawner;
    public int enemynum = 4;
    public float delayBeforeSpawn = 3f;

    private List<GameObject> currentEnemies = new List<GameObject>(); 
    private bool bossSpawned = false; 

    void Start()
    {
        StartCoroutine(SpawnEnemiesAfterDelay());
    }

    void Update()
    {
  
        if (currentEnemies.Count == 0 && !bossSpawned)
        {
   
            StartCoroutine(SpawnBossAfterDelay());
        }
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

            currentEnemies.Add(enemy);
        }

        bossSpawned = false;
    }

    IEnumerator SpawnBossAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSpawn);
        SpawnBoss();
    }

    void SpawnBoss()
    {
       
        if (!bossSpawned)
        {
           
            int spawnIndex = Random.Range(0, EnemySpawner.Length);
            Transform spawnPoint = EnemySpawner[spawnIndex];

           
            Instantiate(Boss, spawnPoint.position, Quaternion.identity);

 
            bossSpawned = true;
        }
    }

    public void EnemyDefeated(GameObject enemy)
    {
       
        if (currentEnemies.Contains(enemy))
        {
            currentEnemies.Remove(enemy);
        }
    }
}

    
