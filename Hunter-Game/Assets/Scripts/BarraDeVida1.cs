using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida1 : MonoBehaviour
{
    public Image barraDeVida;
    public float vidaactual;
    public float vidamaxima;

    
    void Update()
    {
        barraDeVida.fillAmount = vidaactual / vidamaxima;
    }
}
