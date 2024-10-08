using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountFollowers1 : MonoBehaviour
{

    private GameObject player;
    public int followerCount = 0;
    public int StartFollowerCount = 0;
    public GameObject followerText;
    public UnityEngine.UI.Text followText;
    private string sceneName;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        updateStatsDisplay();
    }

    public void addPlant()
    {
        followerCount++;
        updateStatsDisplay();
    }

    public void updateStatsDisplay(){
    
        //Text followerTextTemp = followerText.GetComponent<Text>();
        followText.text = "FOLLOWERS: " + followerCount + "/8";

      }

}
