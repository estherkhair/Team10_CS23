using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerPlanting : MonoBehaviour
{

    public GameObject followerPlant;
    public GameObject wateredPlant;
    public GameObject follower; 
    public Transform plantPoint;
    public CountFollowers1 CountFollowers1;
    float distanceToPlant;
    public float plantingDistance = 2f;
    public LayerMask plantsLayer;
    bool isNearPlants = false;
    bool plantPossible = false;
    bool waterPossible = false;

    private void Start()
    {
        CountFollowers1 = GameObject.FindWithTag("GameController").GetComponent<CountFollowers1>();

    }
    void Update(){
        if (Input.GetKeyDown("p")){
            IsNearOtherPlants();
            FollowerCheck();
            if (!isNearPlants && plantPossible){
                PlantFollower();
                CountFollowers1.addPlant();
            }
        } 
        if (Input.GetKeyDown("t"))
        {
            nearPlants();
            FollowerCheck();
            //if (&& plantPossible) {
                // WaterPlant();
            //}
        }
    }

    void PlantFollower(){
        Instantiate(followerPlant, plantPoint.position, Quaternion.identity);
    }

    void WaterPlant(){
        Instantiate(wateredPlant, plantPoint.position, Quaternion.identity);
    }
    
    void FollowerCheck() {
        if (CountFollowers1.followerCount < 10) {
            plantPossible = true; 
        }
        if (CountFollowers1.followerCount >= 10) {
            plantPossible = false;
            Debug.Log("Max Followers Reached");
        }
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
    }

    public void nearPlants(){
        Collider2D[] hitPlants = Physics2D.OverlapCircleAll(plantPoint.position, plantingDistance, plantsLayer);
        if (hitPlants.Length == 0) {
            Debug.Log("Cannot interact");
        }
        else {
            Debug.Log("interact");
        }
        
    }

        /*
        foreach(Collider2D player in hitPlants){
            //Debug.Log("We hit " + enemy.name);
            isNearPlants = true;
            return;
        }
        isNearPlants = false;
        */
      

      //NOTE: to help see the attack sphere in editor:
      void OnDrawGizmosSelected(){
           if (plantPoint == null) {return;}
            Gizmos.DrawWireSphere(plantPoint.position, plantingDistance);
      }

}