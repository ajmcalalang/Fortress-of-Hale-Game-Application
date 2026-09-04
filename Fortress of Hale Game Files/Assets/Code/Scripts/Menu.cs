using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyGUI;
    [SerializeField] TextMeshProUGUI HealthGUI;
    [SerializeField] TextMeshProUGUI WaveGUI;

    public PlayerHealth playerHealth;
    public EnemySpawner currentWavez;
    private void OnGUI()
    {
        currencyGUI.text = "$" + levelmanager.main.currency.ToString();
        HealthGUI.text = playerHealth.GetCurrentHealth().ToString();
        WaveGUI.text = "WAVE: " + currentWavez.GetCurrentWave().ToString() + "/" + currentWavez.GetCurrentWaveToWin().ToString();
    }

    public void SetSelected() { 

    }
}
