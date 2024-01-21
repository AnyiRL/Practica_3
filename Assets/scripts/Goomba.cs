using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public float speed;
    public KeyCode leftKey, rightKey;
    private SpriteRenderer _rend;
    private Vector2 _dir;
    //private float x;


    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();  
    }

    void Update()
    {
        if(_dir == new Vector2(-1, 0))
        {
            _rend.flipX = true;
      
        }
        if (_dir == new Vector2(1, 0))
        {
            _rend.flipX = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Mario>() != null)
        {

            Destroy(gameObject);
        }
    }
    
}
