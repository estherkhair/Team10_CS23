using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEscape : MonoBehaviour
{

     void Update(){
        
        if (Input.GetKey("escape")){
            QuitGame();
        }
     }

     public void QuitGame(){
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
        }
}
