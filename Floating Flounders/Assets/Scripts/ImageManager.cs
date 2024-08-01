using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Canvas canvas;

    public List<RawImage> characterPortraits;

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

        foreach (RawImage portrait in characterPortraits)
        {
            portrait.enabled = false;   // disable all characters on start
        }
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

    public void EnableCharacter(string characterName)
    {
        int index = 0;
        while (characterName != characterPortraits[index].name)     // searches for the character to edit
        {
            index++;
        }
        characterPortraits[index].enabled = true;
    }

    public void DisableCharacter(string characterName)
    {
        int index = 0;
        while (characterName != characterPortraits[index].name)     // searches for the character to edit
        {
            index++;
        }
        characterPortraits[index].enabled = false;
    }
}
