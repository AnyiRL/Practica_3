 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mario : MonoBehaviour
{

    public float speed;
    public KeyCode leftKey, rightKey, jumpKey;
    public float LayerCast;
    private Rigidbody2D rb;
    private Vector2 dir;
    public float jumpForce;
    public float rayDistance;
    public LayerMask groundMask;                       //capa de colisiones
    private bool _intentionToJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        dir = Vector2.zero;
        if (Input.GetKey(leftKey))
        {
            dir = new Vector2(-1, 0);
        }
        else if (Input.GetKey(rightKey))
        {
            dir = new Vector2(1, 0);
        }
        _intentionToJump = false;
        if (Input.GetKey(jumpKey))
        {
            _intentionToJump = true;   
        }
        
    }

    private void OnDrawGizmos()                                      //gizmos=Lineas guias
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);                                     
    }

    private void FixedUpdate()
    {
       if( dir != Vector2.zero)
        {
            float currentYVel = rb.velocity.y;                            //para que la velocidad de la caida sea constante
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel;
            rb.velocity = nVel;
        }
       if (_intentionToJump && IsGrounded()) 
        {
           rb.AddForce(new Vector2(0,jumpForce * rb.gravityScale), ForceMode2D.Impulse);

        }
        
    }

    private bool IsGrounded()
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance,groundMask);  //
        if (collision)
        {
            return true;
        }
        return false;
    }


}
