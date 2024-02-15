using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio : MonoBehaviour
{
    public AudioClip cambioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            marioComponent.Cambio();
            AudioManager.instance.PlayAudio(cambioClip, "cambioSound");
        }

    }
}
