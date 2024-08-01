using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public TextManager textManager;
    public ImageManager imageManager;

    // singleton stuff
    public static InputManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Left Mouse Button Clicked");
            HandleLeftClick();
        } 
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleSpace();
        }
    }

    void HandleLeftClick()
    {
        // text.UpdateTextOverride("Testing updated text");
        // TextManager.Instance.UpdateText();
        // imageManager.EnableDialogue();
    }

    void HandleSpace()
    {
        // TextManager.Instance.UpdateText();
    }
}
