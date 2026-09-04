using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete : MonoBehaviour
{
    public void PlayRight()
    {
        SceneManager.LoadSceneAsync(42);
    }
}
