using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FollowerPlant : MonoBehaviour{
    public GameObject plantStage1;
    public GameObject plantStage2;
    public GameObject plantStage3;
    public GameObject plantStage4;
    public GameObject followerPrefab;
    public bool isWatered = false;
    public bool isHarvested = false; 


    public float timeToGrow = 1.5f;

    // Start is called before the first frame update
    void Start(){
        //start off hiding all plant stages but 1
        plantStage1.SetActive(true);
        plantStage2.SetActive(false);
        plantStage3.SetActive(false);
        plantStage4.SetActive(false);
    }

    // Update is called once per frame
    IEnumerator GrowPlant(){
        if (isWatered) {
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
        }
        if (isHarvested) {
        Instantiate(followerPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeToGrow);
//after delay, switch to stage 4 (whither)
        plantStage3.SetActive(false);
        plantStage4.SetActive(true);  
        yield return new WaitForSeconds(timeToGrow);      
//after delay, destroy (comment this line out if you want to not be abel to plant in the same place twice)
        //Destroy(gameObject); */
        }
}
    public void WaterPlant() {
        isWatered = true;
        StartCoroutine(GrowPlant());
    }
    public void toHarvest() {
        isWatered = false;
        isHarvested = true;
        StartCoroutine(GrowPlant());
    }
}