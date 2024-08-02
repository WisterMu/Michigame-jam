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

    public void UpdateImage(string name, string emotion)
    {
        RawImage selectedPortrait = characterPortraits[0];  // rovin as default for avoiding errors
        foreach (RawImage portrait in enabledPortraits)
        {
            if (portrait.name == name)
            {
                // this is the character to edit
                selectedPortrait = portrait;
            }
        }
        
        Debug.Log("Showing emotion: " + emotion + " on " + name);
        ImageLibrary library = selectedPortrait.GetComponent<ImageLibrary>();
        Texture2D newSprite = library.GetTexture2D(emotion);
        selectedPortrait.texture = newSprite;

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
        Vector3 anchor = new Vector3(320, 40, 0);
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
                // Debug.Log(character.transform.position);
                character.transform.localPosition = new Vector3(anchor.x + offset, anchor.y, anchor.z);
                offset -= 60;
            }
        }
    }

    public void BringToFront(string name)
    {
        foreach (RawImage portrait in enabledPortraits)
        {
            // lock the y position because it was causing issues for some reason
            Vector3 oldPosition = portrait.transform.localPosition;
            oldPosition.y = 40;     
            portrait.transform.localPosition = oldPosition;

            // change the character's color and layering to show who's talking
            if (portrait.name == name)
            {
                // this is the character to bring to front
                // Debug.Log("Whited out " + portrait.name);
                portrait.color = Color.white;
                portrait.canvas.sortingOrder = 3;   // in front of everything EXCEPT canvas
            }
            else
            {
                // set this character behind the others
                // Debug.Log("Grayed out " + portrait.name);
                Color grayedOut = new Color(0.3f, 0.3f, 0.3f);
                portrait.color = grayedOut;
                portrait.canvas.sortingOrder = 2;   // directly behind speaker
            }
        }
    }
}
