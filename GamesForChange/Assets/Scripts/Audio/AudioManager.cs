using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------Music--------")]
    public AudioClip birdAmbience;

    [Header("--------SFX--------")]
    public AudioClip woodpecker;


    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = birdAmbience;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    /*
     How to add sfx in other scripts

    fields------------------

    AudioManager audioManager;

    method------------------

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    where you want the clip to be played ----------------------------
    audioManager.PlaySFX(audioManager.woodpecker);

     
     */
}
