using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour
{
    public void Quitting()
    {
        Application.Quit();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
