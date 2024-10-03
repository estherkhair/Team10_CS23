using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb2D;
    private bool FaceRight = true; // determine which way player is facing.
    public static float runSpeed = 10f;
    public float startSpeed = 10f;
    public bool isAlive = true;
    public AudioSource WalkSFX;
    private Vector3 hMove;
    public Transform feet;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public float airDrag = 0.5f; // Drag while in the air


    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.1f, groundLayer);
        Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 2f, enemyLayer);

        if (groundCheck != null || enemyCheck != null)
        {
            return true;
        }

        return false;
    }

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb2D = transform.GetComponent<Rigidbody2D>();
        animator.SetBool("Walk", false); // Ensure the walk animation is off at the start

    }

    void Update()
    {
        if (isAlive)
        {
            // Get horizontal input
            float moveInput = Input.GetAxis("Horizontal");
            hMove = new Vector3(moveInput, 0.0f, 0.0f);

            if (IsGrounded()) {
                Debug.Log("walking");
                rb2D.velocity = new Vector2(hMove.x * runSpeed, rb2D.velocity.y);
            } else
            {
                rb2D.drag = airDrag;
                Debug.Log("flying");
                rb2D.velocity = new Vector2(hMove.x * runSpeed/4, rb2D.velocity.y);

            }
            // Set velocity for smoother movement
            rb2D.velocity = new Vector2(hMove.x * runSpeed, rb2D.velocity.y);

            if (hMove.x != 0 && IsGrounded())
            {
                animator.SetBool("Walk", true);
                // Play walking sound if not already playing
                //  if (!WalkSFX.isPlaying)
                //  {
                //      WalkSFX.Play();
                //  }
            }
            else
            {
                animator.SetBool("Walk", false);
                // WalkSFX.Stop();
            }
            if ((hMove.x < 0 && FaceRight) || (hMove.x > 0 && !FaceRight))
            {
                playerTurn();
            }
        }
    }


    void FixedUpdate()
    {
        //slow down on hills / stops sliding from velocity
        if (hMove.x == 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y);
        }
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