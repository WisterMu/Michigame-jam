using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Damage and targeting script

    //Establishing variables :D
    public float speed = 3f;
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;
   

    //checking for whether target is detected in range and whether enemy is dead (I - I)7
    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        if (health <= 0f)
        {
            
            Die();
        }

    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }


    //Does damage to player
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<Player>().UpdateHealth(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }




    //Sets player as target to follow if they enter range
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;

            Debug.Log(target);
        }
    }


    //removes player as target once they exit range
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }



    //health script below including death  Xp


    //variables :D
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;


    //Set health to max ;)
    private void Start()
    {
        health = maxHealth;
    }



    //Removes health upon taking damage >-<
    public void TakeDamage(int damage)
    {
        health -= damage;

        //AudioManager.Instance.PlaySoundEffect(0);
    }


    //Makes sure the enemy doesn't get 1 million health 0_0
    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        
    }


    //Removes enemy upon death XO
    void Die()
    {
        Destroy(gameObject);
    }

}
