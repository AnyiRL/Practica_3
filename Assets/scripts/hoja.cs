using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoja : MonoBehaviour
{
    public int valor = 1;
    public AudioClip hojaClip;

    //private float currentTime = 0;
    //private float maxTime;
    void Start()
    {
       // maxTime = 0;   
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Mario marioComponent = collision.gameObject.GetComponent<Mario>();
        //currentTime += Time.deltaTime;
        if (marioComponent != null )//&& currentTime > maxTime)
        {
            AudioManager.instance.PlayAudio(hojaClip, "hojaSound");
            GameManager.instance.RLifes(valor);
            collision.gameObject.GetComponent<Fades>().Fade();
            
            //manager.RestarVidas(valor);
            //currentTime = 0;
            //maxTime = 0;
        }
        if (collision.gameObject.GetComponent<Goomba>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
    
}
