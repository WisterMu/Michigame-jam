using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossmanager : MonoBehaviour
{
    private spawnControl waveManager;
    public bool isBossDead = false;

    void Start()
    {
        // Find the EnemyWaveManager in the scene
        waveManager = FindObjectOfType<spawnControl>();
    }

    private void HandleBossDeath()
    {
        isBossDead = true; // Set the flag or perform any action needed
        Debug.Log("Boss has been defeated!");

        // You can also call other methods or trigger further events here
        GameManager.Instance.SetFlag("Win2");
    }
}
