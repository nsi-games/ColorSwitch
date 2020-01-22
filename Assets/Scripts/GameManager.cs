using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // The Singleton Pattern
    public static GameManager Instance = null;


    // Cleans Code: CTRL + K + D (In that order)
    // Folds Code: CTRL + M + O
    // UnFolds Code: CTRL + M + P
    // Multi-Line Select: ALT + SHIFT + (Up / Down Arrows)
    // Rename Reference: CTRL + R + R

    public Player player;
    public Transform environment;

    private void Awake()
    {
        // If Instance exists
        if(Instance != null)
        {
            // Destroy instance
            Destroy(Instance);
        }
        // Set Instance to This
        Instance = this;

        // If Instance == null
        //  Set Instance to This
        // Else
        //  Destroy Instance
        //  Set Instance to This
    }

    // Start is called before the first frame update
    void Start()
    {
        // Make the player jump up 10 units
        player.Jump(10f);
    }

    // Restarts the Game
    public void Restart()
    {
        // Restart the Player
        player.Restart();
        // Restart Environment Positon to Zero
        environment.position = Vector3.zero;
        // Loop over each child of Environment

        // Comment Selection: CTRL + K, CTRL + C
        // UnComment Selection: CTRL + K, CTRL + U
        //for (int i = 0; i < environment.childCount; i++)
        //{
        //    var child = environment.GetChild(i);
        //    child.gameObject.SetActive(true);
        //}

        foreach (Transform child in environment)
        {
            child.gameObject.SetActive(true);
        }
    }
}
