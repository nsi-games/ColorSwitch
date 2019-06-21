using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColorAssign : MonoBehaviour
{
    public GameColor gameColor;
    public SpriteRenderer[] renderers;
    
    void Reset()
    {
        AssignColors();    
    }

    void Start()
    {
        AssignColors();
    }

    void AssignColors()
    {
        // Load color Scriptable Object
        gameColor = Resources.Load<GameColor>("Data/GameColor");
        renderers = GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            SpriteRenderer rend = renderers[i];
            rend.color = gameColor.colors[i];
        }
    }
}
