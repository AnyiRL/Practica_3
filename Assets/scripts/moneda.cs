using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    public int valor = 1;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            GameManager.instance.AddPoints(valor);
            // GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
        
    }
}
