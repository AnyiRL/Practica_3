using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class final : MonoBehaviour
{
    public AudioClip finClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mario marioComponent = collision.GetComponent<Mario>();
        if (marioComponent != null)
        {
            marioComponent.Final();
            AudioManager.instance.PlayAudio(finClip, "finSound");
        }

    }
}
