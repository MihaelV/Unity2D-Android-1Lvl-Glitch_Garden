using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Attacker))] //ako u buducnosti dodamo nekome ovu skriptu ona provjerava ako je on attacker
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); // tražimo i spremamo komponentu Animator => anim
        attacker = GetComponent<Attacker>(); // tražimo i spremamo komponentu Attacker => attacker

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collider)
    {
       

        GameObject obj = collider.gameObject;

        //prekini ako se ne sudaraš s defenderom
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("Jump trigger");
        }else
        {
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
        Debug.Log("Fox is collided with " + collider);
    }



}
