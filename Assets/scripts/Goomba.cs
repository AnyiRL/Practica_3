using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public AudioClip goombaClip, marioClip;
    public int valor = 100;
    //private SpriteRenderer _rend;
    //private Vector2 _dir;
    //private float x;

    // Start is called before the first frame update
    void Start()
    {
        //_rend = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        //if(_dir == new Vector2(-1, 0))
        //{
        //    _rend.flipX = true;
      
        //}
        //if (_dir == new Vector2(1, 0))
        //{
        //    _rend.flipX = false;
        //}
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Mario marioComponent = collision.gameObject.GetComponent<Mario>();
        if (collision.gameObject.GetComponent<Mario>() != null)
        {
            marioComponent.ResetGame();
            AudioManager.instance.PlayAudio(marioClip, "MarioMuereSound");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mario>() != null)
        {
            Destroy(gameObject);
            AudioManager.instance.PlayAudio(goombaClip, "goombaMuereSound");
            GameManager.instance.AddPoints(valor);
        }

    }
    
    //singleton accesible para cualquiera, solo existe una instancia  
    

}
