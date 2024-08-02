using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 overworldLocation = new Vector2(0, 0);

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

    }

    public void SetFlag(string flag)
    {
        gameStateFlags.Add(flag);
    }

    public bool GetFlag(string flag)
    {
        return gameStateFlags.Contains(flag);
    }

    public void TriggerCombat()
    {
        // swap scenes
    }

    public void SetMovementFrozen(bool state)
    {
        isMovementFrozen = state;
    }
}
