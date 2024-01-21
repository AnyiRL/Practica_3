using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir : MonoBehaviour
{
    public GameObject tortuga;
    public GameObject enemigo;
    public float speed;
   
 
    void Update()
    {
       
        enemigo.transform.position = Vector3.MoveTowards(enemigo.transform.position,tortuga.transform.position,speed);
    }
    
}
