using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagAppearObject : MonoBehaviour
{
    public List<string> requiredFlags = new List<string>();
    BoxCollider2D selfCollider = null;
    BoxCollider2D[] parentColliders = null;
    SpriteRenderer selfSprite = null;
    bool hasAppeared = false;

    // Start is called before the first frame update
    void Start()
    {
        selfCollider = GetComponent<BoxCollider2D>();
        selfSprite = GetComponentInParent<SpriteRenderer>();
        parentColliders = GetComponentsInParent<BoxCollider2D>();   // technically this also includes self collider
        // but if the parent collider is being shown then the interact should be shown too

        // disable on startup
        selfCollider.enabled = false;
        selfSprite.enabled = false;
        foreach (BoxCollider2D collider in parentColliders)
        {
            collider.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAppeared)
        {
            AttemptAppear();
        }
    }

    private void AttemptAppear()
    {
        // Debug.Log(this.name + " is touching Player!");
        bool appear = true;
        foreach (string flag in requiredFlags)
        {
            if (!GameManager.Instance.GetFlag(flag))
            {
                // flag missing
                appear = false;
            }
        }

        if (appear)
        {
            if (selfCollider != null)
            {
                selfCollider.enabled = true;
            }
            if (selfSprite != null)
            {
                selfSprite.enabled = true;
            }
            if (parentColliders != null)
            {
                foreach (BoxCollider2D collider in parentColliders)
                {
                    collider.enabled = true;
                }
            }

            hasAppeared = true;
        }
    }
}
