using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabeza : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Mario marioComponent = collision.gameObject.GetComponent<Mario>();
        if (collision.gameObject.GetComponent<Mario>() != null)
        {
            
            marioComponent.ResetPosition();

        }
    }
}
