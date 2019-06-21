using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Transform environment;
    public GameColor gameColor;
    public Color[] colors = new Color[4];

    private Rigidbody2D rigid;
    private SpriteRenderer rend;

    private Vector3 originalPos;

    void Reset()
    {

    }

    void AssignColor()
    {

    }


    public void Restart()
    {
        transform.position = originalPos;
        Stop(); // Stop the player from moving
    }

    public void Play()
    {
        // Enabled Rigidbody
        rigid.isKinematic = false;
    }
    public void Stop()
    {
        // Disables Rigidbody
        rigid.isKinematic = true;
        // Remove any velocity
        rigid.velocity = Vector2.zero;
    }
    public void Jump()
    {
        // Reset velocity to flying up
        rigid.velocity = Vector2.up * jumpForce;
    }

    void Start()
    {
        // Record start positon
        originalPos = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (rigid.isKinematic)
        {
            return;
        }

        // If mouse button is down
        if (Input.GetButtonDown("Fire1"))
        {
            Jump();
        }

        // Get player's position
        Vector3 position = transform.position;
        // If position goes higher than 0
        if (position.y > 0f)
        {
            // Translate the environment the opposite way
            environment.Translate(new Vector3(0, -position.y, 0));
            // Cap the player's position
            position.y = 0f;
        }
        // Apply player's position
        transform.position = position;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Get the other object's SpriteRenderer
        SpriteRenderer otherRend = col.GetComponent<SpriteRenderer>();

        switch (col.tag)
        {
            case "ColorChanger":
                // Randomize color
                int randomIndex = Random.Range(0, colors.Length);
                rend.color = colors[randomIndex];
                // Destroy the col GameObject
                Destroy(col.gameObject);
                break;
            case "Circle:":
                // If other color is not the same as our color
                if (otherRend.color != rend.color)
                {
                    // Game Over!
                    print("Game Over!");
                }
                break;
            default:
                break;
        }
    }
}
