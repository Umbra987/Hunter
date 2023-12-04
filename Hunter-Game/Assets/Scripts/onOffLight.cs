using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OnOffLight : MonoBehaviour
{
    public GameObject luzDelJugador;
    public Collider2D zonaActivacion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            luzDelJugador.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            luzDelJugador.SetActive(false);
        }
    }
}
