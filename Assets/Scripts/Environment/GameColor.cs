using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameColor-Data", menuName = "ScriptableObjects/GameColor", order = 1)]
public class GameColor : ScriptableObject
{
    public Color[] colors = new Color[4];
}
