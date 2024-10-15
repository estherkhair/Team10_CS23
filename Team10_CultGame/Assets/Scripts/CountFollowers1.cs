using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountFollowers1 : MonoBehaviour
{

    private GameObject player;
    public int StartFollowerCount = 0;
    public int followerCount = 0;
    public int glideCount = 0;
    public int StartGlideCount = 0;
    public GameHandler GameHandler;
    public GameObject followerText;
    public UnityEngine.UI.Text followText;
    public UnityEngine.UI.Text glideText; 
    private string sceneName;
    
    void Start()
    {
        GameHandler = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();
        player = GameObject.FindWithTag("Player"); 
        followerCount = GameHandler.followersNow();
        glideCount = GameHandler.glideNow();

        updateStatsDisplay();
    }

    public void addPlant()
    {
        followerCount++; 
        updateStatsDisplay();
    }

    public void addGlide()
    {
        glideCount++;
        updateStatsDisplay();

    }

    public void updateStatsDisplay(){
        Text followerTextTemp = followText.GetComponent<Text>();
        followText.text = "Followers: " + followerCount + "/10";

        Text glideTextTemp = glideText.GetComponent<Text>();
        glideText.text = "Glides: " + glideCount + "/5";

      }
}