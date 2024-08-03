using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Playermovement : MonoBehaviour
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
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.Set(inputManager.Movement.x, inputManager.Movement.y);

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
}
