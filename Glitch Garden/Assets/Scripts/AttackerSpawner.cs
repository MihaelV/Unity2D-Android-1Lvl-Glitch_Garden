using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    //u ovaj array ici ce svi attackeri koje mozemo spawnati
    public GameObject[] attackerPrefabArray;

	
	// Update is called once per frame
	void Update () {
        foreach(GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }		
	}


    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPetSeconds = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by rame rate");
        }

        float threshold = spawnsPetSeconds * Time.deltaTime/5;
        //if(Random.value < threshold)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        //isto

        return (Random.value < threshold);

        
       
        

        


        
    }


    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
}
