using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Canvas canvas;

    public List<RawImage> characterPortraits;
    public List<RawImage> enabledPortraits = new List<RawImage>();    // contains currently active characters

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

        // clears all currently enabled portraits
        foreach (RawImage portrait in enabledPortraits)
        {
            portrait.enabled = false;
        }
        enabledPortraits.Clear();
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
        enabledPortraits.Add(characterPortraits[index]);
        RearrangePortraits();
    }

    public void DisableCharacter(string characterName)
    {
        int index = 0;
        while (characterName != characterPortraits[index].name)     // searches for the character to edit
        {
            index++;
        }
        characterPortraits[index].enabled = false;
        enabledPortraits.Remove(characterPortraits[index]);
        RearrangePortraits();   
    }
    
    // this ensures that multiple characters don't fully overlap when they appear / disappear
    void RearrangePortraits()
    {
        // int offset = 0;         // offset for positioning
        Vector3 anchor = new Vector3(7.91f, 1.90f, 95.00f);
        float offset = 0;
        foreach (RawImage character in enabledPortraits)
        {
            if (character.name == "Rovin")
            {
                // this is the MC
            }
            else
            {
                // offset each character portrait from each other
                Debug.Log(character.transform.position);
                character.transform.position = new Vector3(anchor.x + offset, anchor.y, anchor.z);
                offset -= 1f;
            }
        }
    }
}
