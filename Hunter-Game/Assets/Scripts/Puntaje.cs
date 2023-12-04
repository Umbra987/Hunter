using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;

    public Transform jugadorTransform; // Asigna el objeto del jugador desde el Inspector

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = puntos.ToString("0");

        
        if (puntos == 3)
        {
            TeletransportarJugador(); 
        }
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }

    private void TeletransportarJugador()
    {
        
        if (jugadorTransform != null)
        {
            
            jugadorTransform.position = new Vector3(91.66f, -0.65f, 0);
        }
        else
        {
            Debug.LogError("¡No se ha asignado el objeto del jugador para teletransportación!");
        }
    }
}
