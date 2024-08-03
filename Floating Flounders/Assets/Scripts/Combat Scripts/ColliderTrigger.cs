using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{


    public event EventHandler OnPlayerEnterTrigger;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player = collider.GetComponent<Player>();
        if(player != null)
        {

            Debug.Log("Player activated");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }
    }
}
