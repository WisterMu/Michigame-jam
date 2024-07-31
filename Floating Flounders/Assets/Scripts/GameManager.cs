using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 overworldLocation = new Vector2(0, 0);

    public List<bool> gameStateFlags;   // for indicating game progression

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
        for (int i = 0; i < 100; i++)
        {
            gameStateFlags.Add(false);      // populate flags with 100 bools
        }
    }

    public void SetFlag(int index, bool state)
    {
        gameStateFlags[index] = state;
    }

    public void TriggerCombat()
    {
        // swap scenes
    }
}
