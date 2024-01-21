using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidas : MonoBehaviour
{
    public float valor = 1;
    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            manager.SumarVidas(valor);
            Destroy(gameObject);
        }

    }
}
