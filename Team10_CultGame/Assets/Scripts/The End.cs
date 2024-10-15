using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("garden");
    }
}
