using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Y position threshold for falling off
    public float fallThreshold = -10f;

    void Update()
    {
        // Check if the player's Y position is below the fall threshold
        if (transform.position.y < -50)
        {
            // Load the Game Over scene
            SceneManager.LoadScene("August End");
        }
    }
}