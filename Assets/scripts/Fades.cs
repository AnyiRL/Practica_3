using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fades : MonoBehaviour                                         //Cambia la opacidad del personaje
{
    public float alpha;
    private SpriteRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        
        
    }
    private void Update()
    {
        if (alpha==1)
        {
            StartCoroutine(FadeOut());
        }
        
        if (alpha == 0)
        {
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        Color color = _rend.color;                                         //guarda color 
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f)               //disminyte alpha para que sea cada vez mas transparente
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f);
        }
    }
    IEnumerator FadeIn()
    {
        Color color = _rend.color;
        for (float alpha = 0.0f; alpha <= 1; alpha += 0.01f)               
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f);
        }

    }
}
