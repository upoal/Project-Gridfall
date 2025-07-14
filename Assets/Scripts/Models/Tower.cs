using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;

    public GameObject bulletPrefab;


    private void OnEnable()
    {
        TickSystem.OnTickAttackPhase += OnTick;
    }

    private void OnDisable()
    {
        TickSystem.OnTickAttackPhase -= OnTick;
    }

    private void OnTick()
    {
        TryAttackEnemy();
    }

    void TryAttackEnemy()
    {
        if (EnemyManager.Instance == null) return;

        var enemies = EnemyManager.Instance.GetAllEnemies();
        Vector3Int towerCell = PathManager.Instance.towerTilemap.WorldToCell(transform.position);

        foreach (Enemy enemy in enemies)
        {
            Vector3Int enemyCell = PathManager.Instance.pathTilemap.WorldToCell(enemy.transform.position);

            int gridDistance = Mathf.Abs(towerCell.x - enemyCell.x) + Mathf.Abs(towerCell.y - enemyCell.y);

            if (gridDistance <= data.attackRangeInTiles)
            {
                ShootBulletAt(enemy);
                break;
            }
        }
    }

    void ShootBulletAt(Enemy enemy)
    {
        if (bulletPrefab == null)
        {
            Debug.LogError("No bulletPrefab assigned to Tower!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.Initialize(enemy.transform, data.damage);
        }
    }


    void OnDrawGizmosSelected()
    {
        if (data == null || PathManager.Instance == null) return;

        Gizmos.color = Color.red;

        var towerCell = PathManager.Instance.towerTilemap.WorldToCell(transform.position);

        for (int dx = -data.attackRangeInTiles; dx <= data.attackRangeInTiles; dx++)
        {
            for (int dy = -data.attackRangeInTiles; dy <= data.attackRangeInTiles; dy++)
            {
                // Use Manhattan distance for range
                if (Mathf.Abs(dx) + Mathf.Abs(dy) <= data.attackRangeInTiles)
                {
                    var targetCell = towerCell + new Vector3Int(dx, dy, 0);
                    var worldPos = PathManager.Instance.towerTilemap.GetCellCenterWorld(targetCell);

                    // Draw the outline of the *actual grid cell* in world space
                    Vector3 size = PathManager.Instance.towerTilemap.cellSize;
                    Gizmos.DrawWireCube(worldPos, size);
                }
            }
        }
    }




}
