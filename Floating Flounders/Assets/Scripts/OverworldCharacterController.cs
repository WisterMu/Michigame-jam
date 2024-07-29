using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class OverworldCharacterController : MonoBehaviour
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
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // body.MovePosition(body.position + move * Time.deltaTime * Speed);
        
    }

    private void FixedUpdate() {
        body.velocity = movementDirection * Speed;
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision Detected!");
    }
}
