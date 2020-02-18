using UnityEngine;

/// <summary>
/// Brief: Rotates a Sprite with a given Speed
/// Description:
/// Attach Script to object you want to rotate and adjust the Speed variable
/// </summary>
public class Rotator : MonoBehaviour
{
    public float m_speed = 10f;
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.forward, m_speed * Time.deltaTime);
    }
}
