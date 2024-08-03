using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputManager : MonoBehaviour
{
    public static Vector2 Movement;

    private PlayerInput _playerInput;
    private InputAction _moveAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput> ();

        _moveAction = _playerInput.actions["Move"];
    }
 

    // Update is called once per frame
    void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
    }
}
