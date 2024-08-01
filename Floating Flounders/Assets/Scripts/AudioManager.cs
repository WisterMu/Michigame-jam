using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> musicClips;  // holds bgm, theme songs, etc.
    public List<AudioClip> sfxClips;    // holds sound effects (attacks, damage, etc.)
    public AudioSource audioPlayer;     // plays the actual music
    public AudioListener listener;      // used for controlling volume
    public float volume = 1;

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

    // This is a listener for when the scene changes
    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (currentName == null)
        {
            // Scene1 has been removed
            Debug.Log("Changed Scenes: " + currentName + " --> " + next.name);
        }

        // changes track based on loaded scene
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
    public void SwapMusic(int index)
    {
        audioPlayer.clip = musicClips[index];
        audioPlayer.Play();
        AudioListener.volume = volume;
    }

    // plays a single clip once, does not interrupt music
    public void PlaySoundEffect(int index)
    {
        audioPlayer.PlayOneShot(sfxClips[index]);
    }

    // Note: the volume goes from 0.0 - 1.0
    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
        AudioListener.volume = volume;
    }
}
