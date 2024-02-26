using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comentarios : MonoBehaviour
{
    public float fuerzaGolpe;
    private Rigidbody rigidbody;
    private bool puedeMoverse = true ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //En el sitio de movimiento 
    // Si no puede moverse salir de la funcion
    //if (puedeMoverse == !) return; y sale de la funcion 
    public void AplicarGolpe()  //si tocas el enemigo, te golpea para atras. 
    {
        puedeMoverse = false ;
        Vector2 direccionGolpe;
         if(rigidbody.velocity.x> 0)
        {
            direccionGolpe = new Vector2(-1, 1);
        }
        else
        {
            direccionGolpe = new Vector2(1,1);
        }

        rigidbody.AddForce(direccionGolpe * fuerzaGolpe);
        //StartCoroutine(EsperarYActivarMovimiento());
    }
}
//
//IEnumerator EsperarYActivarMovimiento()
//{
//    yield return new WaitForSeconds(0.1f);
//    while(!Suelo())
//    {
//        yield return null;
//    }
//    puedeMoverse = true;
//}

//ir al sitio del enemigo y aplicarGolpe collision.gameObject.GetComponent<>().AplicarGolpe
//enemigo
//demtro del collision 
//if (!puedeAtacar) return;
//  puedeAtacar = false; para que ataque una vez
//Color color = rb.color;
//color.a= 0.5f;
//rb.color = color
// Invoke("ReactivarAtaque", coolDownAtaque)//tiempo publico


// void ReactivarAtaque()
//{
//puedeAtacar = true;
//Color color = rb.color;
//color.a= 1;
//rb.color = color


//Vector3 direction = personaje.transform.position- transform.position
//if (direction >= 0.0f) 
//transform.localScale = new Vector3 (1.0f,1,1)
//else 
//transform.localScale = new Vector3 (-1,1,1)

//Mathf.Abs()s


//Vector3 direction = personaje.transform.position- transform.position
//if (direction >= 0.0f) 
//transform.localScale = new Vector3 (1.0f,1,1)
//else 
//transform.localScale = new Vector3 (-1,1,1)
