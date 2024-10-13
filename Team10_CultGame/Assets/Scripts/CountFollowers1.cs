using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountFollowers1 : GameHandler
{

    private GameObject player;
    public int StartFollowerCount = 10;
    public int followerCount;
    public GameHandler GameHandler;
    public GameObject followerText;
    public UnityEngine.UI.Text followText;
    private string sceneName;
    
    void Start()
    {
        GameHandler = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();
        player = GameObject.FindWithTag("Player"); 
        followerCount = GameHandler.followersNow();
        updateStatsDisplay();
    }

    public void addPlant()
    {
        followerCount++; 
        updateStatsDisplay();
    }

    public void updateStatsDisplay(){
        Text followerTextTemp = followText.GetComponent<Text>();
        followText.text = "FOLLOWERS: " + followerCount + "/10";

      }
}