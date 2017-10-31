using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    private Button[] buttonArray;
    public static GameObject selectedDefender; // static jer bude samo jedan selektirani

    public GameObject defenderPrefab;

    private Text costText;
 

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        //GetComponent<SpriteRenderer>().color = Color.black; ****** postavlja sve gumbe u crno ******
        //[UPDATE] u editoru pod komponentom Sprite Renderer postavimo boju crno da ne moramo u kodu dva put isti kod pisati i da ne postanu crni svi tek na klik vec od pocetka

        costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning(name + " has no cost text");
        }

        costText.text = defenderPrefab.GetComponent<Defender>().StartCost.ToString();


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown() //na klik miša ispisuje na što smo kliknuli
    {
        //print(name);
        foreach(Button thisButton in buttonArray) // pretražuje array
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black; // postavlja sve u crno 
        }
        GetComponent<SpriteRenderer>().color = Color.white; //onaj na koji smo kliknuli ide u bijelo
        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }

}
