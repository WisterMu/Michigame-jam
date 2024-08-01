using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    //establishing some variables and stuff
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;


    //checking things every frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();            
        }
    }

    //Detects enemies and does attackDamage value to them
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }


    //Draws attack sphere
    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
        return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
