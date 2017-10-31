using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("autoLevel is disabled");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {
        //Debug.Log("try " + name);   // ispis na konzolu da vidimo ako se funkcija poziva        
        Application.LoadLevel(name); // idemo na drugu scenu
        
    }


    public void QuitRequest()
    {
        //Debug.Log("try Quit");   // ispis na konzolu da vidimo ako se funkcija poziva
        Application.Quit();
    }

    public void LoadNextLevel()
    {        
        Application.LoadLevel(Application.loadedLevel+1);
    }

   

   
}
