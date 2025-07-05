using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    private int enemiesRemainingToSpawn = 0;

    // NEW
    private int spawnRateInTicks = 1;
    private int tickCounter = 0;

    void OnEnable()
    {
        TickSystem.OnTickMovePhase += OnTick;
    }

    void OnDisable()
    {
        TickSystem.OnTickMovePhase -= OnTick;
    }

    // Called by GameManager to start a wave
    public void StartWave(int enemyCount, int spawnRateTicks)
    {
        enemiesRemainingToSpawn = enemyCount;
        spawnRateInTicks = Mathf.Max(1, spawnRateTicks);
        tickCounter = 0;
        Debug.Log($"EnemySpawner: Starting wave with {enemyCount} enemies, spawn rate: every {spawnRateInTicks} ticks.");
    }

    void OnTick()
    {
        if (enemiesRemainingToSpawn <= 0)
            return;

        tickCounter++;

        if (tickCounter >= spawnRateInTicks)
        {
            SpawnEnemy();
            enemiesRemainingToSpawn--;
            tickCounter = 0;
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoint == null)
        {
            Debug.LogError("EnemySpawner: spawnPoint is not assigned!");
            return;
        }

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("EnemySpawner: Spawned enemy!");
    }
}
