using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWolf : MonoBehaviour
{
    public int Da�o;

    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            print("Da�o");
        }
    }
}
