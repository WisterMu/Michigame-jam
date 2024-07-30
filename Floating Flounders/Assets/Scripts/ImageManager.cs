using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    public Canvas canvas;

    // singleton stuff
    public static ImageManager Instance { get; private set; }

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
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableDialogue()
    {
        canvas.enabled = true;
    }

    public void DisableDialogue()
    {
        canvas.enabled = false;
    }

    public void UpdateImage()
    {
        // canvas.enabled = true;
    }
}
