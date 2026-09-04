using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pro1 : MonoBehaviour
{
    public void PlayPro2()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
