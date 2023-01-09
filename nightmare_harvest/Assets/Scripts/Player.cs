using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float jumpVelocity;
    private bool isGrounded;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundCheckRadius;
    public Animator animator;
    private bool facingRight = true;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        JumpCheck();

        animator.SetFloat("yVelocity", rigidBody.velocity.y);
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector3(horizontalInput * speed, rigidBody.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if(horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        if(horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }

    public bool GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

         if (!isGrounded)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        return isGrounded;
    }

    void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rigidBody.AddForce(Vector2.up * jumpVelocity);
            Debug.Log("Space");
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
