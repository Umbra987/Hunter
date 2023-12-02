using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        animator.SetTrigger("Hurt");
        if (vida <= 0)
        {
            Muerte();
        }


    }
    private void Muerte()
    {
        
        Destroy(gameObject);
    }
}
