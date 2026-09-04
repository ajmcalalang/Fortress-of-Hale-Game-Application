using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayPro()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void PlayMedics()
    {
        SceneManager.LoadSceneAsync(35);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

}
