using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguir2 : MonoBehaviour
{
    Vector2 Enemypos;
    public GameObject Mario;
    bool perseguirP;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (perseguirP)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemypos, speed *Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, Enemypos)> 5f)
        {
            perseguirP = false;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.tag.Equals("player"))
        {
            Enemypos = Mario.transform.position;
            perseguirP = true;
        }
    }
}
