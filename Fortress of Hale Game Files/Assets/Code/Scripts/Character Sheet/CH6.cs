using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CH6 : MonoBehaviour
{
    public void PlayBack()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void PlayLeft()
    {
        SceneManager.LoadSceneAsync(39);
    }
    public void PlayRight()
    {
        SceneManager.LoadSceneAsync(35);
    }
}
