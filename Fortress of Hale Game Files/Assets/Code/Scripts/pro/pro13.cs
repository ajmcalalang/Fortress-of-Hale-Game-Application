using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pro13 : MonoBehaviour
{
    public void PlayChpt1()
    {
        SceneManager.LoadSceneAsync(14);
    }

    public void PlayHome()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
