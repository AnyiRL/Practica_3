using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidas : MonoBehaviour
{
    public int valor = 1;
    public AudioClip vidaClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            AudioManager.instance.PlayAudio(vidaClip, "lifeSound");
            GameManager.instance.AddLifes(valor);
            Destroy(gameObject);

        }

    }

}
