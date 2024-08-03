using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 overworldLocation = new Vector2(-15.69f, 4.9f);

    public List<string> gameStateFlags = new List<string>();   // for indicating game progression
    public bool isMovementFrozen = false;


    // singleton stuff
    public static GameManager Instance { get; private set; }

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

    private void Start() 
    {
        gameStateFlags.Add("Initial");
    }

    public void SetFlag(string flag)
    {
        gameStateFlags.Add(flag);
    }

    public bool GetFlag(string flag)
    {
        return gameStateFlags.Contains(flag);
    }

    public void RemoveFlag(string flag)
    {
        bool success = gameStateFlags.Remove(flag);
        if (!success)
        {
            // flag not found
            Debug.Log("Flag to remove not found: " + flag);
        }
    }

    // Swaps to combat scene
    public void TriggerCombat()
    {
        // swap scenes
        SceneManager.LoadScene("Combat");
    }

    public void SetMovementFrozen(bool state)
    {
        isMovementFrozen = state;
    }
}
