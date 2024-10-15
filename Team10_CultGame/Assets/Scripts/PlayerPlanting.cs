using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlanting : MonoBehaviour{
    public GameObject followerPlant;
    public Transform plantPoint;
    public CountFollowers1 CountFollowers1;
    float distanceToPlant;
    public float plantingDistance = 2f;
    public LayerMask plantsLayer;
    bool isNearPlants = false;
    bool plantPossible = false;

    private void Start()
    {
        CountFollowers1 = GameObject.FindWithTag("GameController").GetComponent<CountFollowers1>();

    }
    void Update(){
        if (Input.GetKeyDown("p")){
            // IsNearOtherPlants();
            FollowerCheck();
            if (!isNearPlants && plantPossible){
                PlantFollower();
                CountFollowers1.addPlant();
            }
        } 
    }

    void PlantFollower(){
        Instantiate(followerPlant, plantPoint.position, Quaternion.identity);

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

    /* public void IsNearOtherPlants(){
        Collider2D[] hitPlants = Physics2D.OverlapCircleAll(plantPoint.position, plantingDistance, plantsLayer);
        if (hitPlants.Length == 0){
            Debug.Log("no plants in the way here!: " + hitPlants);
            isNearPlants = false;
        }   else {
            Debug.Log("too close to other plants!: " + hitPlants);
            isNearPlants = true;
        } */

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
