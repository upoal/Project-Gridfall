using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private int currentIndex = 0;

    void Start()
    {
        transform.position = PathManager.Instance.GetWorldPos(currentIndex);
        TickSystem.OnTick += OnTick;
    }

    void OnDestroy()
    {
        TickSystem.OnTick -= OnTick;
    }

    void OnTick()
    {
        currentIndex++;
        if (currentIndex < PathManager.Instance.pathTiles.Count)
        {
            Vector3 nextPos = PathManager.Instance.GetWorldPos(currentIndex);
            transform.position = nextPos;
        }
        else
        {
            Debug.Log("Enemy reached the end!");
            TickSystem.OnTick -= OnTick;
        }
    }
}
