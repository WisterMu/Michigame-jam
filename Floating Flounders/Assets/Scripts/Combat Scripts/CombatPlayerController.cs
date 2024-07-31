using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CombatCharacterController : MonoBehaviour
{
    private Rigidbody2D body;

    private Vector2 movementDirection;

    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // input
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // body.MovePosition(body.position + move * Time.deltaTime * Speed);
        
    }

    private void FixedUpdate() 
    {
        // movement
        body.velocity = movementDirection * Speed;
    }
}
