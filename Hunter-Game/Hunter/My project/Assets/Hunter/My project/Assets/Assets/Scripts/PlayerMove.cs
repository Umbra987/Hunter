using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rb2d;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMutiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public BoxCollider2D boxCollider2D;

    public Animator animator;

    public GameObject dustLeft;

    public GameObject dustRight;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        if (UnityEngine.Input.GetKey("d") || UnityEngine.Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

            if (CheckGround.isGrounded==true)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
            
            boxCollider2D.offset = new Vector2(Mathf.Abs(boxCollider2D.offset.x),boxCollider2D.offset.y);

        }
        else if (UnityEngine.Input.GetKey("a") || UnityEngine.Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

            if(CheckGround.isGrounded==true)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
            
            boxCollider2D.offset = new Vector2(-Mathf.Abs(boxCollider2D.offset.x), boxCollider2D.offset.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
            
        }

        if (UnityEngine.Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);

           
        }

        if(CheckGround.isGrounded==false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }
        if(CheckGround.isGrounded==true)
        {
            animator.SetBool("Jump", false);
        }

        if (betterJump)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2d.velocity.y>0 && !UnityEngine.Input.GetKey("space"))
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMutiplier) * Time.deltaTime;
            }
        }
    }
}
