using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fast_travel : MonoBehaviour
{

    void OnMouseDown()
    {
        if (gameObject.name == "Overworld")
        {
            SceneManager.LoadScene("Overworld");

            GameManager.Instance.overworldLocation = new Vector2(10, 0);

        }
    }
}
