using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour{
    public GameObject followerPlant;
    public Transform plantPoint;

    float distanceToPlant;
    public float plantingDistance = 5f;
    public LayerMask plantsLayer;
    bool isNearPlants = false;

    void Update(){
        if (Input.GetKeyDown("p")){
            IsNearOtherPlants();
            if (!isNearPlants){
                PlantFollower();
            }
        } 
    }

    void PlantFollower(){
        Instantiate(followerPlant, plantPoint.position, Quaternion.identity);
    }

    public void IsNearOtherPlants(){
        Collider2D[] hitPlants = Physics2D.OverlapCircleAll(plantPoint.position, plantingDistance, plantsLayer);
        if (hitPlants.Length == 0){
            Debug.Log("no plants in the way here!: " + hitPlants);
            isNearPlants = false;
        }   else {
            Debug.Log("too close to other plants!: " + hitPlants);
            isNearPlants = true;
        }

        /*
        foreach(Collider2D player in hitPlants){
            //Debug.Log("We hit " + enemy.name);
            isNearPlants = true;
            return;
        }
        isNearPlants = false;
        */
      }

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (plantPoint == null) {return;}
            Gizmos.DrawWireSphere(plantPoint.position, plantingDistance);
      }

}
