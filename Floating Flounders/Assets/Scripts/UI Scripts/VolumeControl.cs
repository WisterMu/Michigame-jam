using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ChangeVolume(volumeSlider.value);
        }
    }
}
