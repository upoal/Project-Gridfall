using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    public Vector3Int currentTilePosition;

    void Start()
    {
        currentHealth = maxHealth;
        EnemyManager.Instance?.RegisterEnemy(this);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Took damage: " + amount);
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died!");
            Die();
        }
    }

    void Die()
    {
        // Play animation, effect, etc.
        EnemyManager.Instance.UnregisterEnemy(this);
        Destroy(gameObject);
    }

    void OnDestroy()
    {   
        if (EnemyManager.Instance != null)
            EnemyManager.Instance.UnregisterEnemy(this);
    }
}
