using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;

    public void ToggleDeathScreen()
    {
        DeathScreen.SetActive(!DeathScreen.activeSelf);
    }
}
