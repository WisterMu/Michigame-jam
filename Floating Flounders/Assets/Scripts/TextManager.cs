using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText.text = "initial text";
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = Time.deltaTime.ToString();
        
    }
}
