using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Transform environment;
    
    public void Play()
    {
        // In Game
        player.Play();
        player.Jump();
    }

    public void Restart()
    {
        // Restart logic for the player
        player.Restart();

        // Loop through all children in environment
        for (int i = 0; i < environment.childCount; i++)
        {
            Transform child = environment.GetChild(i);
            // Destroy each child
            Destroy(child.gameObject);
        }
    }
}
