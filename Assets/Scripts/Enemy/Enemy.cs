using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    
    public GameObject healthBarPrefab;
    
    private HealthBar healthBar;

    public Vector3Int currentTilePosition;

    void Start()
    {
        currentHealth = maxHealth;
    
        Debug.Log("Instantiating Health Bar");
        GameObject hb = Instantiate(healthBarPrefab, transform.position, Quaternion.identity);
        hb.transform.SetParent(this.transform);
        healthBar = hb.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        healthBar.Initialize(transform, new Vector3(0, 1f, 0)); // Adjust Y offset as needed
        EnemyManager.Instance?.RegisterEnemy(this);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Took damage: " + amount);
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
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
        Destroy(healthBar.gameObject);
        Destroy(gameObject);
    }

    void OnDestroy()
    {   
        if (EnemyManager.Instance != null)
            EnemyManager.Instance.UnregisterEnemy(this);
    }
}
