using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountFollowers1 : MonoBehaviour
{

    private GameObject player;
    public static int followerCount = 8;
    public int StartFollowerCount = 8;
    public GameObject followerText;
    private string sceneName;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player"); 
        updateStatsDisplay();
    }

    public void updateStatsDisplay(){
    
        Text followerTextTemp = followerText.GetComponent<Text>();
        followerTextTemp.text = "FOLLOWERS: " + followerCount;

      }

}
