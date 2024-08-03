using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastTravelStoryTrigger : MonoBehaviour
{
    public TextAsset[] storyDialogues;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Attempting trigger dialogue in Fast Travel!");
        if (GameManager.Instance.GetFlag("FastTravelTutorial"))
        {
            TextManager.Instance.LoadTextFile(storyDialogues[0]);
            TextManager.Instance.UpdateText();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TriggerDialogue();
        }
    }

    void TriggerDialogue()
    {
        if (TextManager.Instance.isActive)  // text currently active, do not reload
        {
            TextManager.Instance.UpdateText();
        }
    }
    
}
