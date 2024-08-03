using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMaker : MonoBehaviour
{
    public static SingletonMaker Instance { get; private set; }

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
}
