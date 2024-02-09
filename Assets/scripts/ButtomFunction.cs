using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomFunction : MonoBehaviour
{
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }

    public void LoadScene (string sceneName)
    {
        GameManager.instance.LoadScene(sceneName);
    }
}
