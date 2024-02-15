using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameManagerVariables { COINS,TIME,LIFES,POINTS};  //enum declarar estructura sirve para facilitar la lectura a otros programadores

    private float time;
    private int coins;
    private int lifes = 3;
    private int enemy;
    private int initialCoins, initialLifes, initialEnemy;

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

    void Start()
    {
        initialCoins = coins;
        initialLifes = lifes;
        initialEnemy = enemy;
        
    }

    public void Reset()
    {
        coins = initialCoins;
        lifes = initialLifes;
        enemy = initialEnemy;
    }


    void Update()
    {
        time += Time.deltaTime;
    }
    public float GetTime()
    {
        return time ;
    }
    public int GetCoins()
    {
        return coins;
    }
    public int GetLifes()
    {
        return lifes;
    }
    public int GetPoints()
    {
        return enemy;
    }

    //setter establecer, cambiar
    //public void SetTime(float value)   para cambiar tiempo
    //{
    //}

    public void AddCoins(int monedasASumar)
    {
        coins += monedasASumar;
    }
    public void AddLifes(int vidasASumar)
    {
        lifes  += vidasASumar;
    }
    public void RLifes(int vidasARestar)
    {
        lifes -= vidasARestar;
        if (lifes <=0)
        {
            FindAnyObjectByType<Mario>().ResetGame();
        }
    }
    public void AddPoints(int puntosASumar)
    {
        enemy += puntosASumar;
    }



    //callback funcion que se va a llamar en el on click de los botoones
    public void LoadScene (string sceneName)
    {
        Debug.Log("Start");
        SceneManager.LoadScene (sceneName);
        AudioManager.instance.ClearAudios();                //audiomanager, limpia todos los sonidos que estan sonando
    }

    public void ExitGame()
    {
        Debug.Log("Exit!!");
        Application.Quit ();
    }
}
// Event System 
