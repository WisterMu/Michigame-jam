using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public Animator animator;

    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
        animator.SetFloat("Speed", moveInput.sqrMagnitude);



        if (moveInput != Vector2.zero)
        {
            animator.SetFloat(_lastHorizontal, moveInput.x);
            animator.SetFloat(_lastVertical, moveInput.y);
        }
    }




    //Variable setup
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;


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
