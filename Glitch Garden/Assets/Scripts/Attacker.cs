using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Range(-1f, 1.5f)]  // ovime ograničiavamo currentSpeed i u inspektoru dobivamo slider koji ide od -1 do 1.5
    private float currentSpeed;
    [Tooltip("Average number of seconds between appearances")]  // ovime dobivamo ovu poruku u inspektoru u poruku se opise za kaj se koristi ta varijabla
    public float seenEverySeconds;


    private GameObject currentTarget;
    private Animator anim;


    

	// Use this for initialization
	void Start () {
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true; // ove dvije linije dodaju rigidBody i oznacavaju da je kinematic

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);


        if (!currentTarget)
        {
            anim.SetBool("IsAttacking", false);
        }
        
	}

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(name + " trigger enter");
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
    //ova funkcija zove se iz animatora u vrijeme udarca
    public void StrikeCurrentTarget(float damange)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamange(damange);
            }
        }



        
        

        Debug.Log(name + " caused damange" + damange);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;

    }
}
