using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Enemigo;
    private float currentTime = 0;
    private float maxTime;
    // Start is called before the first frame update
    void Start()
    {
        maxTime = 7;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;    //Time.deltaTime - Tiempo en segundos que tard?en completarse el último frame //currentTime total

        if (currentTime >= maxTime)
        {
            Instantiate(Enemigo, new Vector2(17.72932f, 20), Quaternion.identity);           //Quaternion.identity - rotacion por defcto

            currentTime = 0;

            maxTime = 7;

        }
    }
}
