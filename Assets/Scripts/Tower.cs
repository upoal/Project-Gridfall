using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage;
    public float attackRange;
    
    private void OnEnable()
    {
        TickSystem.OnTick += TryAttackEnemy;
    }

    private void OnDisable()
    {
        TickSystem.OnTick -= TryAttackEnemy;
    }

   void TryAttackEnemy()
    {
        if (EnemyManager.Instance == null)
        {
            Debug.LogWarning("EnemyManager.Instance is null");
            return;
        }

        var enemies = EnemyManager.Instance.GetAllEnemies();

        foreach (Enemy enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            Debug.Log($"Enemy at {enemy.transform.position}, Tower at {transform.position}, Distance: {distance}, Range: {attackRange}");

            if (distance <= attackRange)
            {
                Debug.Log("Attacking enemy!");
                enemy.TakeDamage(damage);
                break;
            }
        }
    }


}

