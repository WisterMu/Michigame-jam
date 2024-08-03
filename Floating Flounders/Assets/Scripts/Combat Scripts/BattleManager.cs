using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public enum Stages
    {
        WaitingToStart,
        Stage_1,
        Stage_2,
    }
    
    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private Enemy pfenemySpawn;

    private List<Vector3> spawnPositionsList;
    private Stages stage;

    private void Awake()
    {
        spawnPositionsList = new List<Vector3>();

        foreach (Transform spawnPosition in transform.Find("EnemySpawner"))
        {
            spawnPositionsList.Add(spawnPosition.position);
        }

        stage = Stages.WaitingToStart;
    }

    private void Start()
    { 
        colliderTrigger.OnPlayerEnterTrigger += colliderTrigger_OnPlayerEnterTrigger;
    }

    private void colliderTrigger_OnPlayerEnterTrigger(object sender , System.EventArgs e)
    {
        StartBattle();
        colliderTrigger.OnPlayerEnterTrigger -= colliderTrigger_OnPlayerEnterTrigger;
    }


    private void StartBattle()
    {
        Debug.Log("Start Battle");
        SpawnEnemy();
        
    }

    private void StartNextStage()
    {
        switch (stage)
        {
            default:
            case Stages.WaitingToStart:
                stage = Stages.Stage_1; break;
            case Stages.Stage_1:
                stage = Stages.Stage_2; break;
        }
    }

    private void SpawnEnemy()
    {
        int aliveCount = 0;

        Vector3 spawnPosition = spawnPositionsList[Random.Range(0, spawnPositionsList.Count)];

        Enemy enemyspawn = Instantiate(pfenemySpawn, spawnPosition, Quaternion.identity);
        enemyspawn.Spawn();
    }
}
