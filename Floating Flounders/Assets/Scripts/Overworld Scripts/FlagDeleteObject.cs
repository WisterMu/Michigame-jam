using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDeleteObject : MonoBehaviour
{
    public List<string> requiredFlags = new List<string>();
    public BoxCollider2D parentCollider = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log(this.name + " is touching Player!");
        bool delete = true;
        foreach (string flag in requiredFlags)
        {
            if (!GameManager.Instance.GetFlag(flag))
            {
                // flag missing
                delete = false;
            }
        }

        if (delete)
        {
            Debug.Log("Disabling collider!!");
            if (parentCollider == null)
            {
                // no parent or I forgot
            }
            else
            {
                parentCollider.enabled = false;      // disable collider in parent
            }
            GetComponent<BoxCollider2D>().enabled = false;      // disable collider for this dialogue too just in case
        }
    }
}
