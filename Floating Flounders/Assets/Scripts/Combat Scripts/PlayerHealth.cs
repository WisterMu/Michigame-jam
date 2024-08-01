using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{

    //Variable setup
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;


    //establish starting health at 100%
    private void Start()
    {
        health = maxHealth;
    }


    //Update current health and whether player is alive or dead
    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        else if (health <= 0f)
        {
            health = 0f;
            PlayerDied();
        }
    }


    //brings up game over screen and deactivates player
    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }
}
