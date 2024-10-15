using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    // Player's maximum number of jumps and blocks
    public int maxBlocks = 10;
    public int maxGlide = 5;

    // Current available jumps and blocks
    public int currentGlides;
    public int currentBlocks;
    public static int gruntNumber;

    // UI Elements (optional, can be linked through the inspector)
    public UnityEngine.UI.Text jumpsText;
    public UnityEngine.UI.Text blocksText;

    void Start()
    {

        // Initialize current jumps and blocks
        currentGlides = maxGlide;
        currentBlocks = maxBlocks;
        gruntNumber = currentBlocks; 

        UpdateUI();
    }

    public int followersNow() {
        int nowFollowers;
        nowFollowers = currentBlocks;
        return nowFollowers;
    }

    void UpdateUI()
    {
        if (jumpsText != null)
            jumpsText.text = "Jumps: " + currentGlides;

        if (blocksText != null)
            blocksText.text = "Blocks: " + currentBlocks;
    }

    public void UseGlide()
    {
        if (currentGlides > 0)
        {
            currentGlides--;
            UpdateUI();
            // Add jump logic here
            Debug.Log("Jump used! Remaining jumps: " + currentGlides);
        }
        else
        {
            Debug.Log("No jumps left!");
        }
    }

    public bool hasGlide()
    {
        if (currentGlides > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool hasBlock()
    {
        if (currentBlocks > 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    // Call this method when the player places a block
    public void UseBlock()
    {
        if (currentBlocks > 0)
        {
            currentBlocks--;
            gruntNumber--;

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
        currentGlides = maxGlide;
        currentBlocks = maxBlocks;
        UpdateUI();
    }
}
