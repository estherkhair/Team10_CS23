using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public bool FaceRight = true; // Determine which way player is facing.
    public float runSpeed = 15f;
    public static float airControlSpeed = 6f; // Speed for horizontal movement in the air
    public float jumpForce = 5f;
    public bool isAlive = true;
    public AudioSource WalkSFX;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool canJump = false;
    public GameObject blockPrefab; // Assign your BlockPrefab in the inspector
    public float distanceFromPlayer = 1.0f; // Distance to place the block
    private GameHandler gameHandler; // Reference to the GameHandler

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);
        return groundCheck != null || enemyCheck != null;
    }

    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        animator = gameObject.GetComponentInChildren<Animator>();
        rb2D = transform.GetComponent<Rigidbody2D>();
        animator.SetBool("Walk", false); // Ensure the walk animation is off at the start
        animator.SetBool("Jump", false);

    }

    void Update()
    {
        if (isAlive)
        {
            // Check if grounded and update jump capability
            canJump = IsGrounded();

            // Get horizontal input
            float moveInput = Input.GetAxis("Horizontal");
            Vector3 hMove = new Vector3(moveInput, 0.0f, 0.0f);

            // Handle jumping
            if (IsGrounded())
            {
                animator.SetBool("Jump", false);
                rb2D.velocity = new Vector2(hMove.x * runSpeed, rb2D.velocity.y);
                animator.SetBool("Walk", hMove.x != 0);

                // Play walking sound if not already playing
                if (hMove.x != 0 && WalkSFX != null && !WalkSFX.isPlaying)
                {
                    WalkSFX.Play();
                }
            }
            else
            {
                rb2D.velocity = new Vector2(hMove.x * airControlSpeed, rb2D.velocity.y); // Use air control speed in air
            }
            if (Input.GetButtonDown("Jump") && canJump)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                animator.SetBool("Jump", true);
                // Optionally play jump sound
                // if (JumpSFX != null) JumpSFX.Play();
            }

            // Handle player turning
            if ((hMove.x < 0 && FaceRight) || (hMove.x > 0 && !FaceRight))
            {
                playerTurn();
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                if (gameHandler.hasBlock())
                {
                    CreateBlock();
                }
            }
        }
    }

    void FixedUpdate()
    {
        // Slow down on hills / stops sliding from velocity
        if (IsGrounded() && rb2D.velocity.x == 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y);
        }
    }
    public void CreateBlock()
    {
        // Get the player's current position
        Vector3 playerPosition = feet.position;
        Vector3 blockPosition;
        gameHandler.UseBlock();

        if (FaceRight)
        {
            blockPosition = playerPosition + Vector3.right * distanceFromPlayer;

        }
        else
        {
            blockPosition = playerPosition + Vector3.left * distanceFromPlayer;

        }
        // Calculate the position for the new block (to the left)

        // Instantiate the block at the calculated position
        Instantiate(blockPrefab, blockPosition, Quaternion.identity);
    }

    private void playerTurn()
    {
        // Switch player facing label
        FaceRight = !FaceRight;

        // Multiply player's x local scale by -1 to flip
        Vector3 theScale = transform.localScale;
        theScale.x = FaceRight ? Mathf.Abs(theScale.x) : -Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }
}
