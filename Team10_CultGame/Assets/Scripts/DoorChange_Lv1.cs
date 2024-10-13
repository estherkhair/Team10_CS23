using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitSimple : MonoBehaviour
{

    public string NextLevel = "garden";
    public CountFollowers1 CountFollowers1;
    
    void Start() {
        CountFollowers1 = GameObject.FindWithTag("GameController").GetComponent<CountFollowers1>();
    }
    


    public void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (other.gameObject.tag == "Player" && sceneName == "garden" && CountFollowers1.followerCount == 10)
        {
            
            SceneManager.LoadScene(NextLevel);
        }
    }

}