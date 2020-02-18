using UnityEngine;

/// <summary>
/// Player Script
/// Brief: Provides Player Behaviours to the Ball
/// Description: 
/// Jump = Spacebar
/// </summary>
public class Player : MonoBehaviour
{
    public float m_jumpForce = 10f; // Force to increase Y position when Space is pressed
    public Transform m_environment; // Reference to the Environment to move it
    public Color[] m_colors;
    private Rigidbody2D m_rigid;
    private SpriteRenderer m_rend;
    private Vector3 m_originalPos;
    public Color RandomColor
    {
        get
        {
            // Generate random index 
            int randomIndex = Random.Range(0, m_colors.Length);
            // Return Random Color
            return m_colors[randomIndex];
        }
    }
    private void Awake()
    {
        // Getting Components
        m_rigid = GetComponent<Rigidbody2D>();
        m_rend = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        // Recording the Starting Position of the Player for later
        m_originalPos = transform.position;
        // Give player a Random Color
        RandomizeColor();
    }
    // Update is called once per frame
    private void Update()
    {
        // If space button is down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Make the Player Jump
            Jump(m_jumpForce);
        }

        // Get Player's Position
        Vector3 position = transform.position;
        // If position goes heigher than 0
        if (position.y > 0f)
        {
            //  Translate the environment the opposite way
            m_environment.Translate(new Vector3(0, -position.y, 0));
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
        if (other.CompareTag("Death"))
        {
            // If SpriteRender exists
            if (otherRend != null)
            {
                // If color is different to player color
                if (otherRend.color != m_rend.color)
                {
                    // Tell GameManager to Restart Game
                    GameManager.Instance.Restart();
                }
            }
        }
        else if (other.CompareTag("Pickup"))
        {
            // Randomize Player's Color
            RandomizeColor();
            // Deactivate Powerup
            other.gameObject.SetActive(false);
        }
    }
    // Randomizes the Player's Color
    public void RandomizeColor()
    {
        m_rend.color = RandomColor;
    }
    // Makes the Player jump - based on given height
    public void Jump(float jumpHeight)
    {
        // Reset the Velocity to Up x JumpForce
        m_rigid.velocity = Vector2.up * jumpHeight;
    }
    // Restarts the Player back to Default Settings
    public void Restart()
    {
        // Reset the position back to original position
        transform.position = m_originalPos;
    }
}
