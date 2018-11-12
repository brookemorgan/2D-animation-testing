using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    new SpriteRenderer renderer; // jfc unity remove these legacy properties already
    Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    float Horizontal => Input.GetAxis("Horizontal");
    bool IsMoving => Horizontal != 0;

    public float WalkSpeed = 10;

    void FixedUpdate ()
    {
        animator.SetBool("IsWalking", IsMoving);

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (!IsMoving) return;

        renderer.flipX = Horizontal < 0;

        rb.velocity = new Vector2(Horizontal * WalkSpeed, rb.velocity.y);
        rb.rotation = 0;
        rb.angularVelocity = 0;
	}

    public float JumpForce = 20;
    void Jump()
    {
        animator.SetBool("IsJumping", true);
        rb.AddForce(Vector2.up * JumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("IsJumping", false);
    }
}