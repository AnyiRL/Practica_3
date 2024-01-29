using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { TIME, POINTS,LIFES};  //enum declarar estructura sirve para facilitar la lectura a otros programadores

    private float time;
    private int points;
    private int lifes;

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
      
        //if (vidasTotales < 1)
        //{
        //    FindAnyObjectByType<Mario>().ResetGame();
        //}
    }
    public float GetTime()
    {
        return time;
    }
    public int GetPoints()
    {
        return points;
    }
    public int GetLifes()
    {
        return lifes;
    }

    //setter establecer, cambiar
    //public void SetTime(float value)   para cambiar tiempo
    //{
    //}

    public void SetPoints(int puntosASumar)
    {
        points += puntosASumar;
    }
    public void Setlifes(int vidasASumar)
    {
        lifes  += vidasASumar;
    }
    
    //public void SumarPuntos( float puntosASumar)
    //{
    //    puntosTotales += puntosASumar;
    //}
    //public void SumarVidas(float vidasASumar)
    //{
    //    vidasTotales += vidasASumar;
    //}
    //public void RestarVidas(float vidasARestar)
    //{
    //    vidasTotales -= vidasARestar;
    //}

    //callback duncion que se va a llamar en el on click de los botoones
    public void LoadScene (string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }
}
// Event System 
