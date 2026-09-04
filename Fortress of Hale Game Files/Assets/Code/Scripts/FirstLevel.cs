using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour
{
    public void PlayHome()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void PlayExit()
    {
        SceneManager.LoadSceneAsync(13);
    }
}
