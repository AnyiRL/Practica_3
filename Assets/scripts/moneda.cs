using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    public float valor = 1;
    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            manager.SumarPuntos(valor);
            Destroy(gameObject);
        }
        
    }
}