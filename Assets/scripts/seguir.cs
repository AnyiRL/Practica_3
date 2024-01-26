using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class seguir : MonoBehaviour
{
    private GameObject tortuga;
    

    public float speed;
    void Start()
    {
        tortuga = FindAnyObjectByType<Mario>().gameObject;          //recorrer los scripts hasta encontrar a Mario
    }


    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position,tortuga.transform.position,speed*Time.deltaTime);
    }
    
}
