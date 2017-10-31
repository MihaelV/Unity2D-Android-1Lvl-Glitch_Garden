using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimmer : MonoBehaviour {

    private Slider slider;
    public float levelSeconds=100; //TODO make private    
    private AudioSource audioSource;
    private bool IsEndOfLevel=false;
    private LevelManager levelManager;
    private GameObject winLabel;


	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWwin();
        winLabel.SetActive(false);
        audioSource.Stop();


    }
	
	// Update is called once per frame
	void Update () {
        slider.value = Time.timeSinceLevelLoad / levelSeconds; //slider se pomice svaku sekundu
        
        if(Time.timeSinceLevelLoad >= levelSeconds && !IsEndOfLevel)
        {
            HandleWinCondition();
        }
	}

    void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        IsEndOfLevel = true;
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectsArray = GameObject.FindGameObjectsWithTag("Destroy");
        foreach(GameObject g in taggedObjectsArray)
        {
            Destroy(g);
        }
    }



    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    void FindYouWwin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("Please create You Win object");
        }
    }
}
