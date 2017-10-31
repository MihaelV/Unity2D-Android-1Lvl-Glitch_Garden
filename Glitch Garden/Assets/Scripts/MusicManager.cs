using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource musicSource;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Don't destroy on load: " + name);
    }

    private void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    public void ChangeVolume(float volume)
    {
        musicSource.volume = volume; 
    }

    private void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playin Clip: " + thisLevelMusic);

        if (thisLevelMusic) // ako ima prikvacene pjesme
        {
            musicSource.clip = thisLevelMusic;
            musicSource.loop = true;
            musicSource.Play();

        }
    }



}
