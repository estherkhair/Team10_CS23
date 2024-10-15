using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer backgroundRenderer;

    public void RestartButton()
    {
        SceneManager.LoadScene("garden");
    }
    void Update() 
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
