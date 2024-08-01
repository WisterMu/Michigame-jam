using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        audioPlayer.clip = musicClips[0];
        audioPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
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
