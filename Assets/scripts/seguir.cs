using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir : MonoBehaviour
{
    public GameObject tortuga;

    public float speed;
   
 
    void Update()
    {
        
       transform.position = Vector3.MoveTowards(transform.position,tortuga.transform.position,speed);
    }
    
}
