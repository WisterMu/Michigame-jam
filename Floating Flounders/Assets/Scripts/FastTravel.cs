using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastTravel : MonoBehaviour
{

    void OnMouseDown()
    {
        if (gameObject.name == "Overworld")
        {
            GameManager.Instance.overworldLocation = new Vector2(-5, 0);
            SceneManager.LoadScene("Overworld");
        }

        if (gameObject.name == "Start")
        {
            SceneManager.LoadScene("Overworld");
        }

        if (gameObject.name == "Back to Menu")
        {
            SceneManager.LoadScene("Title Screen");
        }

        if (gameObject.name == "Home")
        {
            GameManager.Instance.overworldLocation = new Vector2(-18.31f, 4.9f);
            SceneManager.LoadScene("Overworld");
        }

        if (gameObject.name == "Park")
        {
            GameManager.Instance.overworldLocation = new Vector2(-18.25f, -10.46f);
            SceneManager.LoadScene("Overworld");
        }

        if (gameObject.name == "Kai")
        {
            GameManager.Instance.overworldLocation = new Vector2(1.68f, 4.73f);
            SceneManager.LoadScene("Overworld");
        }
    }
}
