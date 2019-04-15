using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameColorAssign : MonoBehaviour
{
    public GameColor gameColor;
    private SpriteRenderer[] renderers;
    
    void GetRenderers()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Start()
    {
        GetRenderers();
        for (int i = 0; i < renderers.Length; i++)
        {
            SpriteRenderer rend = renderers[i];
            rend.color = gameColor.colors[i];
        }
    }
}
