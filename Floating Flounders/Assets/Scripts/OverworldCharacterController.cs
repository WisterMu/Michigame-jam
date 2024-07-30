using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class OverworldCharacterController : MonoBehaviour
{
    private Rigidbody2D body;
    private Vector2 movementDirection;
    public float Speed = 5f;
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
        // input
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // body.MovePosition(body.position + move * Time.deltaTime * Speed);
        
    }

    private void FixedUpdate() 
    {
        // movement
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
