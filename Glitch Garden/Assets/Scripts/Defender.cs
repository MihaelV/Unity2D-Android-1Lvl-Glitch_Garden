using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defender : MonoBehaviour {


    private StarDisplay starDisplay;
    public int StartCost= 100;



    private void Start()
    {       
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
       
    }
    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

    
}
