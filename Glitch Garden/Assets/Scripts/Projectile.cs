using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime); // s ovime pomicemo projectile desno
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();  // attacker = colider od gameobjekta kojeg se udara i dobiti komponentu tog attckera
        Health health = collision.gameObject.GetComponent<Health>(); // imamo attacker i health komponente


        if(attacker && health)
        {
            health.DealDamange(damange); // projectile zadaje damange attackeru i uništava se
            Destroy(gameObject); // uništavamo projectile
        }
    }

}
