using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CH2 : MonoBehaviour
{
    public void PlayBack()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayLeft()
    {
        SceneManager.LoadSceneAsync(35);
    }
    public void PlayRight()
    {
        SceneManager.LoadSceneAsync(37);
    }
}
