 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public AudioClip jumpClip, walkClip, idleClip, escaleraUpClip, escaleraDclip;
    public int maxJump = 2;

    private float currentTime = 0;
    private SpriteRenderer _rend;
    private Rigidbody2D rb;
    private Vector2 dir;                 
    private bool _intentionToJump;
    private Animator _animator;
    private Vector3 originalPosition;
    private bool onStair;
    private float originalSpeed;
    private int currentJumps = 0;    //index
    private character character;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _rend = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        originalPosition = transform.position;
        originalSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        dir = Vector2.zero;

        MoveX();
        
        if (Input.GetKey(leftKey))
        {
                _rend.flipX = true;
                dir = new Vector2(-1, 0);
        }
        else if (Input.GetKey(rightKey))
        {
                _rend.flipX = false;
                dir = new Vector2(1, 0);
        }

        if (Input.GetKeyDown(jumpKey))
        {
            _intentionToJump = true;
        }
        if(dir != Vector2.zero)                     //andando                           //#region #endregion para ordenar el codigo
        {
            _animator.SetBool("isWalking", true);
            AudioManager.instance.PlayAudio(walkClip, "walkSound");
            //_animator.Play("walk");
        }
        else                                        //parados
        {
            _animator.SetBool("isWalking", false);
            //_animator.Play("walk");
        }
        currentTime += Time.deltaTime;                            //Time.deltaTime - Tiempo en segundos que tarda en completarse el último frame //currentTime total
        if (currentTime >= 2.5f)
        {
            _animator.SetBool("idle", true);
            currentTime = 0;
            AudioManager.instance.PlayAudio(idleClip, "idleSound");
        }

        if(onStair)
        {
            Escalera();
        }

        character = new Cowboy("mago", 100);
        _rend.sprite = character.GetSprite();

    }
    public void MoveX()
    {
        if (Input.GetKey(leftKey))
        {
            _rend.flipX = true;
            dir = new Vector2(-1, 0);
        }
        else if (Input.GetKey(rightKey))
        {
            _rend.flipX = false;
            dir = new Vector2(1, 0);
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
            nVel.y = currentYVel + nVel.y;
            rb.velocity = nVel;
        } 
       
       if (_intentionToJump && (grnd || currentJumps < maxJump -1))        
        {
                _animator.Play("jump");
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpForce * rb.gravityScale), ForceMode2D.Impulse);
                currentJumps++;           //index = 1
                AudioManager.instance.PlayAudio(jumpClip, "jumpSound");
        }  
        _intentionToJump = false;
        _animator.SetBool("isGrounded",grnd);                       // optimizar
    
    }
    public void Escalera()

    {
        dir = Vector2.zero;
        if (Input.GetKey(upKey))
        {
            _animator.Play("subir");
            dir = new Vector2(0, 1);
            AudioManager.instance.PlayAudio(escaleraUpClip, "upSound");
            speed = originalSpeed / 10;

        }
        else if (Input.GetKey(downKey))
        {
            _animator.Play("bajar");
            dir = new Vector2(0, -1);
            AudioManager.instance.PlayAudio(escaleraDclip, "DSound");
            speed = originalSpeed / 10;
        }
        else if(Input.GetKey(rightKey) || Input.GetKey(leftKey))
        {
            MoveX();
            speed = originalSpeed;
        }
       

    }
    

    private bool IsGrounded()
    {
        RaycastHit2D collision = Physics2D.Raycast(transform.position, Vector2.down, rayDistance,groundMask);  
        if (collision)
        {
            currentJumps = 0;
            return true;        
        }
        return false;
    }
    public void ResetPosition()
    {
        transform.position = originalPosition;
        _animator.Play("start");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentTime += Time.deltaTime;
        if (collision.gameObject.GetComponent<Goomba>() != null)
        {
            _animator.Play("death");
            
            if (currentTime == currentTime + 3)
            {
                ResetGame();
            }
            
        }
    }
    

    public void SetOnStair(bool value)
    {
        onStair = value;
        if(value)
        {
            rb.gravityScale = 0;
            
        }
        else
        {
            rb.gravityScale = 1;
            speed = originalSpeed;
        }
    }

    public bool GetOnStair()
    {
        return onStair; 
    }
    public void Cambio()
    {
        SceneManager.LoadScene("sprite 1");
        _animator.Play("start");
        
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene("sprite");
        _animator.Play("start");
        GameManager.instance.Reset();
    }
    
    public void Final()
    {
        
        _animator.Play("final");
        Debug.Log("YouWin");
    }
}
