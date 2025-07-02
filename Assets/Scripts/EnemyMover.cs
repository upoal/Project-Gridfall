using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private int currentIndex = 0;

    void Start()
    {
        transform.position = PathManager.Instance.GetWorldPos(currentIndex);
        TickSystem.OnTickMovePhase += OnTick;
    }

    void OnDestroy()
    {
        TickSystem.OnTickMovePhase -= OnTick;
    }

    void OnTick()
    {
        currentIndex++;
        if (currentIndex < PathManager.Instance.pathTiles.Count)
        {
            Vector3 nextPos = PathManager.Instance.GetWorldPos(currentIndex);
            transform.position = nextPos;
            Debug.Log("Enemy moved to: " + nextPos);
        }
        else
        {
            Debug.Log("Enemy reached the end!");
            GameManager.Instance.ReduceLives(1);
            Destroy(gameObject);
            TickSystem.OnTickMovePhase -= OnTick;
        }
    }
}
