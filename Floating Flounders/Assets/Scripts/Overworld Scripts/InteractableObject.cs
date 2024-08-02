using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractableObject : MonoBehaviour
{
    public TextAsset textFile;
    public List<string> requiredFlags;

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
        bool valid = true;      // checking if this interactable should work
        if (requiredFlags.Count == 0)
        {
            // no required flags, do nothing
        }
        else
        { 
            foreach (string flag in requiredFlags)
            {
                if (!GameManager.Instance.GetFlag(flag))
                {
                    valid = false;
                    Debug.Log("Missing flag: " + flag);
                }
            }
        }

        if (valid)
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
        }
        else
        {
            Debug.Log("Required flags not yet met!");
            // TODO: Maybe display a default "I don't have the required items for this"?
        }

        
        // Debug.Log("Interacting with object " + this.name);
    }
}
