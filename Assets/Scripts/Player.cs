using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // (BROWSERS) Refresh: CTRL + R
    // (BROWSERS) Clear Cache Refresh: CTRL + SHIFT + R

    public float jumpForce = 10f; // Force to increase Y position when Space is pressed
    public Transform environment; // Reference to the Environment to move it
    public Color[] colors;

    private Rigidbody2D rigid;
    private SpriteRenderer rend;
    private Vector3 originalPos;

    // PascalCasing = Everything Else
    // camelCasing = Variables
    public Color RandomColor
    {
        get
        {
            // Generate random index 
            int randomIndex = Random.Range(0, colors.Length);
            // Return Random Color
            return colors[randomIndex];
        }
    }

    void Awake()
    {
        // Getting Components
        rigid = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Recording the Starting Position of the Player for later
        originalPos = transform.position;
        // Give player a Random Color
        RandomizeColor();
    }

    // Update is called once per frame
    void Update()
    {
        // If space button is down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Make the Player Jump
            Jump(jumpForce);
        }

        // Get Player's Position
        Vector3 position = transform.position;
        // If position goes heigher than 0
        if (position.y > 0f)
        {
            //  Translate the environment the opposite way
            environment.Translate(new Vector3(0, -position.y, 0));
            //  Cap the Player's position to Camera's Y
            position.y = 0f;
        }
        // Apply the new Position
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try getting 'SpriteRender' from Other
        var otherRend = other.GetComponent<SpriteRenderer>();
        switch (other.tag)
        {
            case "Death":
                // If SpriteRender exists
                if (otherRend != null)
                {
                    // If color is different to player color
                    if (otherRend.color != rend.color)
                    {
                        // Tell GameManager to Restart Game
                        GameManager.Instance.Restart();
                    }
                }
                break;
            case "Pickup":
                // Randomize Player's Color
                RandomizeColor();
                // Deactivate Powerup
                other.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }

    // Randomizes the Player's Color
    public void RandomizeColor()
    {
        rend.color = RandomColor;
    }

    // Makes the Player jump - based on given height
    public void Jump(float jumpHeight)
    {
        // Reset the Velocity to Up x JumpForce
        rigid.velocity = Vector2.up * jumpHeight;
    }

    // Restarts the Player back to Default Settings
    public void Restart()
    {
        // Reset the position back to original position
        transform.position = originalPos;
    }
}
