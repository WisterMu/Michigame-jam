using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    RawImage button;
    // BoxCollider2D buttonCollider;
    public Texture2D selected;
    public Texture2D unselected;
    public Texture2D hovered;
    public bool optionQuit, optionContinue, optionStart, optionOption, optionClose;
    public EscapeMenu menu;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<RawImage>();
        // buttonCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver() 
    {
        if (button.texture == selected)
        {
            // this button has been clicked, don't replace with hovering
        }
        else
        {
            button.texture = hovered;
        }
        
    }

    private void OnMouseExit() 
    {
        button.texture = unselected;
    }

    private void OnMouseDown() 
    {
        button.texture = selected;
        // Debug.Log("Clicking BUtton!");
    }

    private void OnMouseUpAsButton() 
    {
        if (optionQuit)
        {
            Debug.Log("Attempting Quit!");
            Application.Quit();
        }
        if (optionContinue)
        {
            
        }
        if (optionStart && !menu.isActive)
        {
            SceneManager.LoadScene("Overworld");
        }
        if (optionOption)
        {
            menu.escapeCanvas.enabled = true;
            menu.isActive = true;
        }
        if (optionClose)
        {
            menu.escapeCanvas.enabled = false;
            menu.isActive = false;
        }
    }
}
