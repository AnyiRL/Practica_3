 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mario : MonoBehaviour
{

    public float speed;
    private SpriteRenderer _rend;
    public KeyCode leftKey, rightKey, jumpKey;
    public float LayerCast;
    public float jumpForce;
    public float rayDistance;
    
    private Rigidbody2D rb;
    private Vector2 dir;
    public LayerMask groundMask;                       //capa de colisiones
    private bool _intentionToJump;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        dir = Vector2.zero;
        if (Input.GetKey(leftKey))
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }
        else if (Input.GetKey(rightKey))
        {
            _rend.flipX= false;
            dir = new Vector2(1, 0);
        }
        _intentionToJump = false;
        if (Input.GetKey(jumpKey))
        {
            _intentionToJump = true;   
        }
        if(dir != Vector2.zero)                     //andando                           //#region #endregion
        {
            _animator.SetBool("isWalking", true);
        }
        else                                        //parados
        {
            _animator.SetBool("isWalking", false);
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
            rb.velocity = new Vector2(rb.velocity.x, 0);
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
