using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public TextAsset textFile;

    bool isTouchingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingPlayer)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log(this.name + " is touching Player!");
        isTouchingPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        // Debug.Log(this.name + " stopped touching Player!");
        isTouchingPlayer = false;
    }

    void TriggerDialogue()
    {
        if (TextManager.Instance.isActive)  // text currently active, do not reload
        {
            TextManager.Instance.UpdateText();
        }
        else
        {
            // load text for first time
            TextManager.Instance.LoadTextFile(textFile);
            TextManager.Instance.UpdateText();  // update to get it started
        }
        
        // Debug.Log("Interacting with object " + this.name);
    }
}
