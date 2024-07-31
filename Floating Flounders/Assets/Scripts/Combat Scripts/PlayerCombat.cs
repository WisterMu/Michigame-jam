using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;    
    [SerializeField] private float attackDamage = 10f;
    // [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private Transform target;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
           
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Attack();
                    other.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-attackDamage);
                    canAttack = 0f;
                }
           
            
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            target = other.transform;

            Debug.Log(target);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We Hit" + enemy.name);
        }

    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
        return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
