using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmanager : MonoBehaviour
{
    private spawnControl waveManager;

    void Start()
    {
        // Find the EnemyWaveManager in the scene
        waveManager = FindObjectOfType<spawnControl>();
    }
}
