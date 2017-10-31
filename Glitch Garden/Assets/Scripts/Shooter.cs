using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile,gun;
    private GameObject projectileParent;
    private Animator animator;
    private AttackerSpawner myLaneSpawner;


    void Start()
    {
        //napravi proditelja ako je potrebno
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
            //projectileParent.name = "Projectiles";
        }

        animator = GameObject.FindObjectOfType<Animator>();
        SetMyLaneSpawner();        
    }


    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    //prolazi kroz sve spawnere i provjerava ako se u toj traci nalazi defender koji ce onda pucati
    void SetMyLaneSpawner()
    {
        AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawn in spawnerArray)
        {
            if(spawn.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawn;
                return;
            }
        }
        Debug.LogWarning(name + " can't find spawner in lane");
    }



    bool IsAttackerAheadInLane()
    {
        //ako nema attackera exit
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        //ako ima attackera jesu li oni ispred mene
        foreach(Transform attacker in myLaneSpawner.transform) {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        //Attacker in lane, but behind us
        return false;
    }
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
        
    }
       

    


}
