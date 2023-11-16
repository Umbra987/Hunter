using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowIA : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private float followDistance = 5f;
    [SerializeField] private float stoppingDistance = 2f;

    private bool isFacingRight = true;
    private Animator animator;

    void Start()
    {
        // Obtén el componente Animator del objeto
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Calcula la dirección y la distancia entre el enemigo y el jugador
        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        // Verifica si el jugador está dentro de la distancia de seguimiento
        if (distance < followDistance && distance > stoppingDistance)
        {
            // Normaliza la dirección para que el movimiento sea suave
            Vector2 normalizedDirection = direction.normalized;

            // Mueve al enemigo en la dirección normalizada
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Voltea al enemigo según la dirección hacia el jugador
            bool isPlayerRight = normalizedDirection.x > 0;
            Flip(isPlayerRight);

            // Activa la animación de "run"
            animator.SetBool("run", true);
        }
        else
        {
            // Desactiva la animación de "run" cuando el enemigo no se está moviendo
            animator.SetBool("run", false);
        }
    }

    private void Flip(bool isPlayerRight)
    {
        if ((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}