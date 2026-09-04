using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;
    [SerializeField] private float enemiesPerSecondCap = 15f;
    [SerializeField] private float wavesToWin = 20f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timesSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private float eps; //enemies per second 
    private bool isSpawning = false;


    private void Awake() {

        onEnemyDestroy.AddListener(EnemyDestroyed);

    }

    public void StartSpawning()
    {
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning) return; // Prevent spawning if game is won

        timesSinceLastSpawn += Time.deltaTime;

        if (timesSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timesSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void EnemyDestroyed() {

        enemiesAlive--;
    
    }
    private IEnumerator StartWave(){

        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true; 
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();
    }

    private void EndWave() { 
        
        isSpawning = false;
        timesSinceLastSpawn = 0f;

        if (currentWave >= wavesToWin)
        {
            WinGame();
            return;
        }

        currentWave++;
        StartCoroutine(StartWave());

    }

    private void WinGame() 
    {
        Debug.Log("You have defeated wave 20! You win!");
        
        SceneManager.LoadScene(41);
    }

    private void SpawnEnemy() {

        int index = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[index];
        Instantiate(prefabToSpawn, levelmanager.main.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave() {

        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    
    }

    private float EnemiesPerSecond()
    {

        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f, enemiesPerSecondCap);

    }

    public int GetCurrentWave()
    {
        return currentWave;
    }

    public float GetCurrentWaveToWin()
    {
        return wavesToWin;
    }

}
