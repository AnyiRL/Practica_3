using System.Collections;
using System.Collections.Generic;
using TMPro;  // avisa que va a usar una libreria 
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable; 
    private TMP_Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(variable==GameManager.GameManagerVariables.TIME)
        //{
        //    textComponent.text = "Time: " + GameManager.instance.GetTime();
        //}
        //else if(variable == GameManager.GameManagerVariables.POINTS)
        //{
        //    textComponent.text = "Points: " + GameManager.instance.GetPoints();
        //}
        //else
        //{
        //    textComponent.text = "Lifes: " + GameManager.instance.GetLifes();
        //}
        
        switch (variable) 
        {
            case GameManager.GameManagerVariables.TIME:
                textComponent.text = "Time: " + GameManager.instance.GetTime().ToString("F2");
                break;
            case GameManager.GameManagerVariables.COINS:

                textComponent.text = " " + GameManager.instance.GetCoins();
                break;
            case GameManager.GameManagerVariables.LIFES:
                textComponent.text = " " + GameManager.instance.GetLifes();
                break;
            case GameManager.GameManagerVariables.POINTS:
                textComponent.text = " " + GameManager.instance.GetPoints();
                break;
            default:
                break;
           

        }
    }
}
