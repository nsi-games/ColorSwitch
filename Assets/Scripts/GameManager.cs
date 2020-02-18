using UnityEngine;

/// <summary>
/// Brief: Provides GameManagement to current Scene
/// Description:
/// Attach this script to an empty GameObject in the scene
/// Must have the following variables referenced:
/// - Player
/// - Environment
/// </summary>
public class GameManager : MonoBehaviour
{
    // The Singleton Pattern
    public static GameManager Instance = null;
    public Player m_player;
    public Transform m_environment;
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
    }
    // Restarts the Game
    public void Restart()
    {
        // Restart the Player
        m_player.Restart();
        // Restart Environment Positon to Zero
        m_environment.position = Vector3.zero;
        // Loop over each child of Environment
        foreach (Transform child in m_environment)
        {
            child.gameObject.SetActive(true);
        }
    }
}
