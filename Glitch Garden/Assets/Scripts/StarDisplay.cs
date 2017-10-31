using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))] //obavezna komponenta je Text
public class StarDisplay : MonoBehaviour {

    public Text myText;
    private int StarMoney=150;

    public enum Status {SUCCESS, FAILURE };


	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        UpdateStars();
       
	}
	
	
    public void AddStars(int amount)
    {
        StarMoney += amount;
        UpdateStars();
    }


    public Status UseStars(int amount)
    {
        if (StarMoney >= amount)
        {
            StarMoney -= amount;
            UpdateStars();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateStars()
    {
        myText.text = StarMoney.ToString();
    }
}
