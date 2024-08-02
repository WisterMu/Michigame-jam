using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this is just used for storing the various images related to this object
public class ImageLibrary : MonoBehaviour
{
    public List<Texture2D> textureLibrary;

    public Texture2D GetTexture2D(string emotion)
    {
        if (emotion == "Neutral")
        {
            return textureLibrary[0];
        }
        if (emotion == "Smiling")
        {
            return textureLibrary[1];
        }
        if (emotion == "Confused")
        {
            return textureLibrary[2];
        }
        if (emotion == "Angry")
        {
            return textureLibrary[3];
        }
        if (emotion == "Scared")
        {
            return textureLibrary[4];
        }
        return textureLibrary[0];   // neutral is default
    }
}
