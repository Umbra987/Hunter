using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWolf : MonoBehaviour
{
    [SerializeField] private float vidaW;
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
        vidaW -= daño;
        animator.SetTrigger("Hurt");
        if (vidaW <= 0)
        {
            Invoke("Muerte", 10);
            Invoke("Credito", 5);
        }


    }

    private void Muerte()
    {

        Destroy(gameObject);
    }

    private void Credito()
    {
        SceneManager.LoadScene("Creditos");
    }
}
