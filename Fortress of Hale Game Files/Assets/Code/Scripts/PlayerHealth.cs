using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public delegate void OnPlayerDeath();
    

    private void Start()
    {
        ResetPlayerHealth();
    }

    public void ResetPlayerHealth() 
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene(33);


    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
