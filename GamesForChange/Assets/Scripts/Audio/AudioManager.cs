using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private string sceneName;
    private string prevSceneName = "MainMenu";
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------Music--------")]
    public AudioClip music;
    public AudioClip birdAmbience;

    [Header("--------SFX--------")]
    public AudioClip woodpecker;


    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        musicSource.clip = music;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //if there is a scene change
        if (prevSceneName != sceneName)
        {
            PlayMusic(sceneName);
        }
        prevSceneName = sceneName;
        sceneName = SceneManager.GetActiveScene().name;
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

    public void PlayMusic(string sceneName)
    {
        if(sceneName == "MainMenu")
        {
            musicSource.clip = music;
            musicSource.Play();
        }
        else
        {
            musicSource.clip = birdAmbience;
            musicSource.Play();
        }
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
