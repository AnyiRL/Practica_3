using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float PuntosTotales { get { return puntosTotales; } }                         //si se lee desde otro script, se devolvera automaticamente el valor de la variable privada puntosTotales
    private float puntosTotales;
    public float VidasTotales { get { return vidasTotales; } }       
    private float vidasTotales = 3 ;

    
    public void SumarPuntos( float puntosASumar)
    {
        puntosTotales += puntosASumar;
    }
    public void SumarVidas(float vidasASumar)
    {
        vidasTotales += vidasASumar;
    }
    public void RestarVidas(float vidasARestar)
    {
        vidasTotales -= vidasARestar;
    }
    void Update()
    {
        if (vidasTotales < 0)
        {
            FindAnyObjectByType<Mario>().ResetGame();
        }
    }
    
}
