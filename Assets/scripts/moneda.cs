using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    public int valor = 1;
    public AudioClip coinClip;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            AudioManager.instance.PlayAudio(coinClip, "coinSound");
            GameManager.instance.AddCoins(valor);
            // GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
        
    }
}
