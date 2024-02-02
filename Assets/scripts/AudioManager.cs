using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private List<GameObject> audioList;


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);    //se destruye el  gameObject para que no  haya dos o mas gm en el juego
        }
    }

    private void Start()
    {
        audioList = new List<GameObject>();
    }

    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false,float volumne = 1.0f)           //valor por defecto, tiene que estar en la ultima parte y no pueden estar intercalados 
    {
        GameObject audioObject = new GameObject(gameObjectName);
        audioObject.transform.SetParent(transform);           //hace que los objetos son hijos del game manager
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();            //aniado componente AudioSource 
        audioSourceComponent.clip = audioClip;                                                 //le asignamos clip, volumen y loop al componente
        audioSourceComponent.volume = volumne;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play();                                                           //darle a empezar
        audioList.Add(audioObject);                                                   

        return audioSourceComponent;
    }

    public void ClearAudios()
    {
        foreach (GameObject audioObject in audioList)
        {
            Destroy(audioObject);
        }
        audioList.Clear();
    }
}


    
