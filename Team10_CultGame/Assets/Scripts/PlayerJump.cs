using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpForce = 20f;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public bool canJump = false;
    public bool isAlive = true;
    public AudioSource JumpSFX;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded to reset the jump
        if (IsGrounded())
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        // Allow jump if the player is alive and can jump
        if (Input.GetButtonDown("Jump") && canJump && isAlive)
        {
            Jump();
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    public void Jump()
    {
        // Reset jump times since the player is jumping
        rb.velocity = Vector2.up * jumpForce;
        animator.SetBool("Jump", true);
        // JumpSFX.Play(); // Uncomment to enable sound
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 2f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);

        if (groundCheck != null || enemyCheck != null)
        {
            return true;
        }

        return false;
    }
}
