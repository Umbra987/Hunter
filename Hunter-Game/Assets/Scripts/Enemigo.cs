using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDa�o(float da�o)
    {
        vida -= da�o;
        if (vida <= 0)
        {
            Muerte();
        }
        else
        {
            Retroceder();
        }
    }

    private void Retroceder()
    {
        
        Vector3 retrocesoPosition = transform.position - transform.right * 1.5f;

        
        transform.position = retrocesoPosition;
    }

    private void Muerte()
    {
        Object.Destroy(gameObject,0);
    }
}
