using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    private bool faceRight = true; // Determine which way player is facing
    public static float runSpeed = 10f;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool isAlive = true;
    public AudioSource jumpSFX;
    public AudioSource walkSFX;

    private Vector3 hMove;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb2D = transform.GetComponent<Rigidbody2D>();
        animator.SetBool("Walk", false); // Ensure the walk animation is off at the start
    }
    private bool IsGrounded()
    {
        // Check if the player is grounded or on an enemy
        return Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(feet.position, 0.1f, enemyLayer);
    }
    private void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        animator.SetBool("Jump", true);

        if (jumpSFX != null)
        {
            jumpSFX.Play();
        }
    }


    private void FixedUpdate()
    {
        // Slow down on hills / stops sliding from velocity
        if (hMove.x == 0 && IsGrounded())
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y);
        }
    }

    private void PlayerTurn()
    {
        // Switch player facing direction
        faceRight = !faceRight;

        // Multiply player's x local scale by -1 to flip
        Vector3 theScale = transform.localScale;
        theScale.x = faceRight ? Mathf.Abs(theScale.x) : -Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }



void Update()
    {
        if (isAlive)
        {
            // Get horizontal input
            float moveInput = Input.GetAxis("Horizontal");
            hMove = new Vector3(moveInput, 0.0f, 0.0f);

            // Set velocity for smoother movement
            if (IsGrounded())
            {
                rb2D.velocity = new Vector2(hMove.x * runSpeed, rb2D.velocity.y);

                // Walking Animation
                if (hMove.x != 0)
                {
                    animator.SetBool("Walk", true);
                   //\\ if (!walkSFX.isPlaying)
                   //{
                        walkSFX.Play();
                    }
                }
                else
                {
                    animator.SetBool("Walk", false);
                   // walkSFX.Stop();
                }
            }
            else
            {
                // Allow limited air control
                rb2D.velocity = new Vector2(hMove.x * (runSpeed * 0.5f), rb2D.velocity.y);
            }

            // Handle player turning
            if ((hMove.x < 0 && faceRight) || (hMove.x > 0 && !faceRight))
            {
                PlayerTurn();
            }

            // Handle jumping
            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                Jump();
            }
        }
    }


