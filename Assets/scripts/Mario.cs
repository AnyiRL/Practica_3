using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mario : MonoBehaviour
{

    public float speed;
    public KeyCode leftKey, rightKey, upKey;
    public float LayerCast;
    private Rigidbody2D rb;
    private Vector2 dir;
    private bool isJumping;
    public float jumpForce;
    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;


    }

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKey(leftKey))
        {
            dir = new Vector2(-1, 0);
        }

        else if (Input.GetKey(rightKey))
        {
            dir = new Vector2(1, 0);
        }
        else  
        {
            dir = new Vector2(0, 0);
        }

        RaycastHit2D[] colliders = Physics2D.RaycastAll(transform.position, Vector2.down, rayDistance);
        if (Input.GetKey(upKey))
        {
            isJumping = true;   
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    private void FixedUpdate()
    {
       if( dir != Vector2.zero)
        {
            rb.velocity = dir * speed;
        }
       if (isJumping ) 
        {
           rb.AddForce(new Vector2(0,jumpForce * rb.gravityScale));
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, Vector2.down, rayDistance);
        foreach(RaycastHit2D raycastHit in raycastHits)
        {
            if (raycastHit.collider.gameObject.CompareTag ("Suelo"))
            {
                return true;
            }
        }
        return false;
    }


}
