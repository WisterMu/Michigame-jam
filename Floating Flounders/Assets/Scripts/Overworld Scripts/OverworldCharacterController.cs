using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class OverworldCharacterController : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementDirection;
    public float Speed = 5f;
    public Animator animator;
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    // public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        LoadPosition(GameManager.Instance.overworldLocation);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isMovementFrozen)
        {
            // frozen, do nothing
            movementDirection = new Vector2(0, 0);      // set velocity to 0
        }
        else
        {
            // Set the character's movement direction
            movementDirection.x = Input.GetAxisRaw("Horizontal");
            movementDirection.y = Input.GetAxisRaw("Vertical");

            movementDirection.Normalize();
        }

        animator.SetFloat("Horizontal", movementDirection.x);
        animator.SetFloat("Vertical", movementDirection.y);
        animator.SetFloat("Speed", movementDirection.sqrMagnitude);

        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat(_lastHorizontal, movementDirection.x);
            animator.SetFloat(_lastVertical, movementDirection.y);
        }
    }

    private void FixedUpdate() 
    {
        // movement on fixed update
        body.velocity = movementDirection * Speed;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision Detected!");
    }

    void LoadPosition(Vector2 position)
    {
        body.position = position;
    }
}
