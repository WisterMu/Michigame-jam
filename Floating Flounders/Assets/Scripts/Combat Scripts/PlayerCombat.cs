using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private float meleeSpeed;
    [SerializeField] private int dmg;

    float timeUntilMelee;

    private void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("attackUp");
                timeUntilMelee = meleeSpeed;
            }
            else
            {
                timeUntilMelee -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemies")
        {
            other.GetComponent<Enemy>().TakeDamage(dmg);
            Debug.Log("Enemy Hit");
        }
    }

}





