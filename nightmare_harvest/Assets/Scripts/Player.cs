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

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        JumpCheck();
    }

    private void FixedUpdate()
    {
        HorizontalMovement();
    }

    void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector3(horizontalInput * speed, rigidBody.velocity.y);
    }

    public bool GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
}
