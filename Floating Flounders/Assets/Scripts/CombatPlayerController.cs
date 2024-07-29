using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    private Vector2 movementDirection;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movementDirection = body.velocity;
        // movementDirection.x = Input.GetAxisRaw("Horizontal");
        
        float moveInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);

        

        // if ((Input.GetAxisRaw("Vertical") > 0) && (movementDirection.y == 0))
        // {
        //     Jump();
        // }
        // else
        // {
        //     movementDirection.y = Input.GetAxisRaw("Vertical");
        // }
    }

    private void FixedUpdate() 
    {
        if ((Input.GetAxisRaw("Vertical") > 0) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
        }
        // body.velocity = movementDirection * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Jump()
    {
        movementDirection.y = 5;
    }
}
