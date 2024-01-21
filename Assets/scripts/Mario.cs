 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Mario : MonoBehaviour
{

    public float speed;
    public KeyCode leftKey, rightKey, jumpKey;
    public float LayerCast;
    public float jumpForce;
    public float rayDistance;
    public KeyCode upKey, downKey;
    public LayerMask groundMask;   //capa de colisiones

    private float currentTime = 0;
    private SpriteRenderer _rend;
    private Rigidbody2D rb;
    private Vector2 dir;                 
    private bool _intentionToJump;
    private Animator _animator;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        originalPosition = transform.position;
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
        if(dir != Vector2.zero)                     //andando                           //#region #endregion para ordenar el codigo
        {
            _animator.SetBool("isWalking", true);
        }
        else                                        //parados
        {
            _animator.SetBool("isWalking", false);
        }
        currentTime += Time.deltaTime;                            //Time.deltaTime - Tiempo en segundos que tarda en completarse el �ltimo frame //currentTime total
        if (currentTime >= 2.5f)
        {
            _animator.SetBool("idle", true);
            currentTime = 0;

        }
        

    }

    private void OnDrawGizmos()                                      //gizmos=Lineas guias
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);                                     
    }

    private void FixedUpdate()
    {
        bool grnd = IsGrounded();
       if( dir != Vector2.zero)
        {
            float currentYVel = rb.velocity.y;                            //para que la velocidad de la caida sea constante
            Vector2 nVel = dir * speed;
            nVel.y = currentYVel;
            rb.velocity = nVel;
        } 
       
       if (_intentionToJump && grnd) 
        {
            _animator.Play("jump");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0,jumpForce * rb.gravityScale), ForceMode2D.Impulse);

        }
        _animator.SetBool("isGrounded",grnd);                       // optimizar
    }
    //private void OnTriggerEnter2D(Collider2D collision)                   // Collider qui�n se ha chocado

    //{
    //    dir = new Vector2(0,0);
    //    if (collision.GetComponent<Escalera>() != null && Input.GetKey(upKey))
    //    {
    //        dir = new Vector2(0, 1);
    //        rb.gravityScale = 0;
    //    }
    //    if (collision.GetComponent<Escalera>() != null && Input.GetKey(downKey))
    //    {
    //        dir = new Vector2(0, -1);
    //        rb.gravityScale = 0;
    //    }

    //}
    

    private bool IsGrounded()
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance,groundMask);  //
        if (collision)
        {
            return true;
        }
        return false;
    }
    public void ResetPosition()
    {
        transform.position = originalPosition;
        _animator.Play("start");

    }
    //public void ResetGame()
    //{
    //    _animator.Play("death");
    //    SceneManager.LoadScene("Mario");
    //}



}
