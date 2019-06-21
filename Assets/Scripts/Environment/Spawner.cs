using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform environment;
    public int spawnSpace = 10;

    // Store previous and current Y
    private int prevY, currY;
    
    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation, environment);
    }
    void Start()
    {
        currY = Mathf.RoundToInt(environment.position.y);
        prevY = currY;
    }
    void Update()
    {
        currY = Mathf.RoundToInt(environment.position.y);
        if (currY != prevY)
        {
            int result = currY % spawnSpace;
            if (result == 0)
            {
                Spawn();
            }
        }
        prevY = currY;
    }
}
