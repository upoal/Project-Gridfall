using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject currentEnemy;


    public void SpawnEnemy()
    {
        if (currentEnemy == null)
        {
            currentEnemy = Instantiate(enemyPrefab);
        }
    }
}
