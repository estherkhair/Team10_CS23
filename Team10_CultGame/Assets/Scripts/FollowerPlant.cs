using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerPlant : MonoBehaviour{
    public GameObject plantStage1;
    public GameObject plantStage2;
    public GameObject plantStage3;
    public GameObject plantStage4;
    public GameObject followerPrefab;


    public float timeToGrow = 1.5f;

    // Start is called before the first frame update
    void Start(){
        //start off hiding all plant stages but 1
        plantStage1.SetActive(true);
        plantStage2.SetActive(false);
        plantStage3.SetActive(false);
        plantStage4.SetActive(false);

        StartCoroutine(GrowPlant());
    }

    // Update is called once per frame
    IEnumerator GrowPlant(){
        yield return new WaitForSeconds(timeToGrow);
    //after delay, switch to stage 2
        plantStage1.SetActive(false);
        plantStage2.SetActive(true);
        plantStage3.SetActive(false);
        yield return new WaitForSeconds(timeToGrow);
//after delay, switch to stage 3
        plantStage1.SetActive(false);
        plantStage2.SetActive(false);
        plantStage3.SetActive(true);
        yield return new WaitForSeconds(timeToGrow);
//after delay, spawn follower:
        Instantiate(followerPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeToGrow);
//after delay, switch to stage 4 (whither)
        plantStage3.SetActive(false);
        plantStage4.SetActive(true);  
        yield return new WaitForSeconds(timeToGrow);      
//after delay, destroy (comment this line out if you want to not be abel to plant in the same place twice)
        //Destroy(gameObject);
    }
}
