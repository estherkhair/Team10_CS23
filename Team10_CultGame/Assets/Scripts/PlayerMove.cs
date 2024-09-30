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

            // Set velocity for smoother movement
            rb2D.velocity = new Vector2(hMove.x * runSpeed, rb2D.velocity.y);

            if (hMove.x != 0)
            {
                animator.SetBool("Walk", true);
                // Play walking sound if not already playing
                //  if (!WalkSFX.isPlaying)
                //  {
                //      WalkSFX.Play();
                //  }
                Debug.Log("Walking");
            }
            else
            {
                animator.SetBool("Walk", false);
                // WalkSFX.Stop();
                Debug.Log("Not Walking");
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