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
            SceneManager.LoadScene("Overworld");

            GameManager.Instance.overworldLocation = new Vector2(10, 0);

        }

        if (gameObject.name == "Start")
        {
            SceneManager.LoadScene("Overworld");
        }
    }
}
