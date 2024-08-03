using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    public Canvas escapeCanvas;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        escapeCanvas = GetComponent<Canvas>();
        escapeCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escapeCanvas.enabled = !escapeCanvas.enabled;   // toggle canvas
            isActive = escapeCanvas.enabled;
        }
    }
}
