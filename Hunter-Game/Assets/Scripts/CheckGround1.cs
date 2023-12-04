using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround1 : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Terrain"))
        {
            isGrounded = false;
        }

    }
}
