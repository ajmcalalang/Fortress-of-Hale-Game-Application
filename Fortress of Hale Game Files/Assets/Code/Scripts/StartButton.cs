using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [Header("References")]
    public Button startButton; // Assign in the inspector
    public EnemySpawner enemySpawner; // Assign in the inspector

    private void Start()
    {
        // Add listener to the button
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        // Start spawning enemies
        enemySpawner.StartSpawning();
        // Optionally, disable the button after starting
        startButton.gameObject.SetActive(false);
    }
}
