using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    [SerializeField] [Range(0, 20)] float speed;
    [SerializeField] [Range(0, 20)] float jumpForce;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask whatIsGround;

    Rigidbody2D rb2d;
    float moveInput;
    bool facingRight;
    bool isGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal") * speed;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

        if (moveInput > 0.1f && facingRight)
            Flip();
        else if (moveInput < -0.1f && !facingRight)
            Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveInput, rb2d.velocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}