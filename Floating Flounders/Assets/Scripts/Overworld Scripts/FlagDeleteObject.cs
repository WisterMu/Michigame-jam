using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagDeleteObject : MonoBehaviour
{
    public List<string> requiredFlags = new List<string>();
    BoxCollider2D selfCollider = null;
    BoxCollider2D[] parentColliders = null;
    SpriteRenderer selfSprite = null;
    public bool deleteSelfCollider, deleteImage, deleteParentCollider;
    bool insideTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        selfCollider = GetComponent<BoxCollider2D>();
        selfSprite = GetComponentInParent<SpriteRenderer>();
        parentColliders = GetComponentsInParent<BoxCollider2D>();   // technically this also includes self collider
        // but if the parent collider is being deleted then the interact should be deleted too
    }

    // Update is called once per frame
    void Update()
    {
        if (insideTrigger)  // only attempt delete while player is inside hitbox
        {
            AttemptDelete();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        insideTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        insideTrigger = false;    
    }

    private void AttemptDelete()
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
            if (deleteSelfCollider)
            {
                Debug.Log("Disabling self collider!!");
                if (selfCollider == null)
                {
                    // no parent or I forgot
                }
                else
                {
                    selfCollider.enabled = false;      // disable collider in parent
                }
                GetComponent<BoxCollider2D>().enabled = false;      // disable collider for this dialogue too just in case
            }
            if (deleteImage)
            {
                Debug.Log("Disabling image!");
                selfSprite.enabled = false;
            }
            if (deleteParentCollider)
            {
                Debug.Log("Disabling parent collider!!");
                foreach (BoxCollider2D collider in parentColliders)
                {
                    collider.enabled = false;
                }
            }
        }
    }
}
