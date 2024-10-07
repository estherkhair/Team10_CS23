using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Player's maximum number of jumps and blocks
    public int maxJumps = 3;
    public int maxBlocks = 5;

    // Current available jumps and blocks
    private int currentJumps;
    private int currentBlocks;

    // UI Elements (optional, can be linked through the inspector)
    public UnityEngine.UI.Text jumpsText;
    public UnityEngine.UI.Text blocksText;

    void Start()
    {
        // Initialize current jumps and blocks
        currentJumps = maxJumps;
        currentBlocks = maxBlocks;

        UpdateUI();
    }

    void UpdateUI()
    {
        if (jumpsText != null)
            jumpsText.text = "Jumps: " + currentJumps;

        if (blocksText != null)
            blocksText.text = "Blocks: " + currentBlocks;
    }

    // Call this method when the player jumps
    public void UseJump()
    {
        if (currentJumps > 0)
        {
            currentJumps--;
            UpdateUI();
            // Add jump logic here
            Debug.Log("Jump used! Remaining jumps: " + currentJumps);
        }
        else
        {
            Debug.Log("No jumps left!");
        }
    }

    // Call this method when the player places a block
    public void UseBlock()
    {
        if (currentBlocks > 0)
        {
            currentBlocks--;
            UpdateUI();
            // Add block placing logic here
            Debug.Log("Block placed! Remaining blocks: " + currentBlocks);
        }
        else
        {
            Debug.Log("No blocks left!");
        }
    }

    public void addBlock()
    {
        currentBlocks++;
    }

    // Method to reset the game state (optional)
    public void ResetGame()
    {
        currentJumps = maxJumps;
        currentBlocks = maxBlocks;
        UpdateUI();
    }
}
