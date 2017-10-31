using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject Parent;
    private StarDisplay starDisplay;
    


    private void Start()
    {
        Parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();

        if (!Parent)
        {
            Parent = new GameObject("Defenders");
            //projectileParent.name = "Projectiles";
        }


    }




    //Prvo zelimo ocitavati dodire ili mouse klikove
    private void OnMouseDown()
    {
        //ovime su se ispisivale kordinate za provjeru ako radi
        //print(Input.mousePosition);
        ////print(CalculateWorldPointofMouseClick());
        //print("Zaokruzeni brojevi: "+SnapToGrid(CalculateWorldPointofMouseClick()));
        
        Vector2 pos = CalculateWorldPointofMouseClick();
        Vector2 roundedPos = SnapToGrid(pos);
        GameObject defender = Button.selectedDefender;

        int deffenderCost = defender.GetComponent<Defender>().StartCost;
        if (starDisplay.UseStars(deffenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }

            
        
    }

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRotation = Quaternion.identity;
        GameObject newDef = Instantiate(Button.selectedDefender, roundedPos, zeroRotation) as GameObject;
        //Quaternion.identity ovo mjesto je za rotaciju a ovaj kod znaci default rotacija = 0


        newDef.transform.parent = Parent.transform;
    }
   
    
    //zaokruži broj
    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX, newY;
        newX = Mathf.RoundToInt(rawWorldPos.x);
        newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    //pikseli u world unit (screen to world point )
    Vector2 CalculateWorldPointofMouseClick()
    {
        //x i y kordinate
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        //udaljenost od kamere
        float distanceFromCamera = 10f;


        Vector3 cudo = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(cudo);


        return worldPos;
    }

}
