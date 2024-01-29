using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager1 : MonoBehaviour      //UI unity interfaces
{
    public static GameManager1 instance;

    private float time;
    private int points;

    private void Awake()
    {

        //Singleton         //singleton accesible para cualquiera, solo existe una instancia  
        if (!instance)     // si instance no tiene informacion
        {
            instance = this;    // instance se asigna a este objet.                                 el gameManager querra crearse, si no hay otro antes este sera el principal
            DontDestroyOnLoad(gameObject);        //no se destruye con la carga de escenas 
        }
        else
        {
            Destroy(gameObject);    //se destruye el  gameObject para que no  haya dos o mas gm en el juego
        }
    }
    void Update()
    {
        time += Time.deltaTime;
    }

    //getter obtener valor
    public float GetTime()
    {
        return time;   
    }
    public int GetPoints(int points)
    {
        return points;
    }

    //setter establecer, cambiar
    //public void SetTime(float value)   para cambiar tiempo
    //{
    //}

    public void SetPoints(int value)
    {
        points = value;
    }
}  
