using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class puntos : MonoBehaviour
{
    public GameManager manager;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vidas;

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = manager.GetPoints().ToString();
        vidas.text = manager.GetLifes().ToString();

    }
}
