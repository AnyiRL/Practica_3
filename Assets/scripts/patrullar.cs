using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distMinima;
    private float minDist;
    private SpriteRenderer _rend;
    private int siguientePaso;

    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        Girar();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position) < minDist)
        {
            siguientePaso += 1;
            if(siguientePaso >= puntosMovimiento.Length)
            {
                siguientePaso = 0;
            }
            Girar();
        }
    }
    private void Girar()
    {
        if (transform.position.x < puntosMovimiento[siguientePaso].position.x)
        {
            _rend.flipX = true;
        }
    }
}
