using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class OnHit : MonoBehaviour
{
    // Is it going to destroy the incoming object?
    public bool destroy = false;
    public string hitTag = "";
    public UnityEvent onTriggerEnter;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        // If hitTag matches incoming object's tag OR hitTag is set to nothing
        if (hitTag == col.tag || hitTag == "")
        {
            // Does the object need to be destroyed?
            if (destroy)
            {
                // Destroy it!
                Destroy(col.gameObject);
            }
            // Run Unity Event
            onTriggerEnter.Invoke();
        }
    }
}
