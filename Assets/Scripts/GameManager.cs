using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Transform environment;
    public Animator ui;
    
    public void Play()
    {
        // In Game
        ui.SetBool("InGame", true);
        player.Play();
        player.Jump();
    }

    public void Restart()
    {
        // No longer in game
        ui.SetBool("InGame", false);

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
