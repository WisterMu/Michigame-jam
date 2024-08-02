using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //establishing some variables and stuff
    public Transform attackPointleft;   
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public bool directionleft;

    //checking things every frame
    void Update()
    {
        Left();
        if (directionleft == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AttackLeft();
            }

        }
        else if (directionleft == false) { }

        directionleft = false;
    }


        //ugly bools to detect player direction
     void Left()
    {
        if (!Input.GetKeyDown(KeyCode.W))
        {
            if (!Input.GetKeyDown(KeyCode.D))
            {
                if (!Input.GetKeyDown(KeyCode.S))
                {
                    directionleft = true;
                }
                else
                { 
                    directionleft = false; 
                }
            }
        }

    }

    //Detects enemies and does attackDamage value to them to the left
    void AttackLeft()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointleft.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }


    //Draws attack sphere
    void OnDrawGizmosSelected()
    {
        if(attackPointleft == null)
        {
        return; }

        Gizmos.DrawWireSphere(attackPointleft.position, attackRange);
    }
 
}





