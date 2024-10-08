using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountFollowers1 : MonoBehaviour
{

    private GameObject player;
    public int StartFollowerCount = 8;
    public int followerCount;
    public GameObject followerText;
    public UnityEngine.UI.Text followText;
    private string sceneName;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        followerCount = GameHandler.gruntNumber;
        updateStatsDisplay();
    }

    public void addPlant()
    {
        followerCount++; 
        updateStatsDisplay();
    }

    public void updateStatsDisplay(){
        Text followerTextTemp = followText.GetComponent<Text>();
        followText.text = "FOLLOWERS: " + followerCount + "/8";

      }
}