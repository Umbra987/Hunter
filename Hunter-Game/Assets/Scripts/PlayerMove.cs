using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        if (UnityEngine.Input.GetKey("d") || UnityEngine.Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        }
        else if (UnityEngine.Input.GetKey("a") || UnityEngine.Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }

        if (UnityEngine.Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }
}
