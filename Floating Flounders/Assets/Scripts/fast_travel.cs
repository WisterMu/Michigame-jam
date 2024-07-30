using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fast_travel : MonoBehaviour
{

    void OnMouseDown()
    {
        if (gameObject.name == "Overworld")
        {
            Application.LoadLevel("Overworld");
        }
    }
}
