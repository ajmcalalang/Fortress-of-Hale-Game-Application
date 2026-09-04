//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyMovement : MonoBehaviour
//{
//    [Header("References")]
//    [SerializeField] private Rigidbody2D rb;

//    [Header("Attributes")]
//    [SerializeField] private float moveSpeed = 2f; // Speed at which the enemy moves
//    [SerializeField] private int damageToPlayer = 10; // Damage to player when enemy reaches the end

//    private Transform target;
//    private int pathIndex = 0;

//    private void Start()
//    {
//        target = levelmanager.main.path[0];
//    }

//    private void Update()
//    {
//        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
//        {
//            pathIndex++;

//            if (pathIndex == levelmanager.main.path.Length)
//            {
//                // Call the player's TakeDamage method
//                FindObjectOfType<PlayerHealth>().TakeDamage(damageToPlayer);

//                // Invoke enemy destruction event and destroy the enemy
//                EnemySpawner.onEnemyDestroy.Invoke();
//                Destroy(gameObject);
//                return;
//            }
//            else
//            {
//                target = levelmanager.main.path[pathIndex];
//            }
//        }
//    }

//    private void FixedUpdate()
//    {
//        Vector2 direction = (target.position - transform.position).normalized;
//        rb.velocity = direction * moveSpeed; // Move the enemy towards the target
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f; // Speed at which the enemy moves
    [SerializeField] private int damageToPlayer = 10; // Damage to player when enemy reaches the end

    private Transform target;
    private int pathIndex = 0;

    private void Start()
    {
        target = levelmanager.main.path[0];
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == levelmanager.main.path.Length)
            {
                // Call the player's TakeDamage method
                FindObjectOfType<PlayerHealth>().TakeDamage(damageToPlayer);

                // Invoke enemy destruction event and destroy the enemy
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = levelmanager.main.path[pathIndex];
            }
        }

        // Rotate the enemy to face the target
        FaceTarget();
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed; // Move the enemy towards the target
    }

    private void FaceTarget()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Convert to degrees
        rb.rotation = angle; // Set the rotation of the Rigidbody2D
    }
}
