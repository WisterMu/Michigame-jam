using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> musicClips;
    public List<AudioClip> sfxClips;
    public AudioSource audioPlayer;

    // singleton stuff
    public static AudioManager Instance { get; private set; }

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

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;

        SwapMusic(0);   // start playing title music
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);

        if (next.name == "Overworld")
        {
            SwapMusic(1);
        }
        else if (next.name == "Fast Travel")
        {
            SwapMusic(2);
        }
        else
        {
            SwapMusic(3);
        }
    }

    // swaps music, interrupts previous music
    void SwapMusic(int index)
    {
        audioPlayer.clip = musicClips[index];
        audioPlayer.Play();
    }

    // plays a single clip once, does not interrupt music
    void PlaySoundEffect(int index)
    {
        audioPlayer.PlayOneShot(sfxClips[index]);
    }
}
