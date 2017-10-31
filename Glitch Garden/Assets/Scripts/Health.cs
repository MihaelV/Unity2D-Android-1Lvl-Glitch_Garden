using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health=100f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDamange(float damange)
    {
        health -= damange;
        if (health < 0)
        {
            //Optionally trigger animation
            DestroyObject();
        }
    }


    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
