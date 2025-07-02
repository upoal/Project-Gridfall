using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public TowerData towerData;
    private GameObject draggingGhost;

    public Camera mainCamera;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (towerData.energyCost > GameManager.Instance.currentEnergy)
        {
            Debug.Log("Not enough energy!");
            // TODO: Optional UI feedback here
            return;
        }

        // Create a transparent ghost of the prefab
        draggingGhost = Instantiate(towerData.towerPrefab);
        draggingGhost.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggingGhost == null) return;

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        draggingGhost.transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggingGhost == null) return;

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        Vector3Int cell = PathManager.Instance.towerTilemap.WorldToCell(worldPos);

        if (PathManager.Instance.towerTilemap.HasTile(cell))
        {
            TowerBlock block = PathManager.Instance.GetBlockFromCell(cell);

            if (block != null && !block.isOccupied)
            {
                if (towerData.energyCost <= GameManager.Instance.currentEnergy)
                {
                    Debug.Log("Drag: Energy reduced by " + towerData.energyCost + ". Current energy: " + GameManager.Instance.currentEnergy);
                    GameManager.Instance.ReduceEnergy(towerData.energyCost);

                    // Place the real tower at center
                    Vector3Int center = block.center;
                    Vector3 placePos = PathManager.Instance.towerTilemap.GetCellCenterWorld(center);
                    GameObject placedTower = Instantiate(towerData.towerPrefab, placePos, Quaternion.identity);

                    // Assign its TowerData
                    Tower tower = placedTower.GetComponent<Tower>();
                    if (tower != null) tower.data = towerData;

                    PathManager.Instance.OccupyBlock(block, PathManager.Instance.occupiedTiles);
                }
            }
        }

        Destroy(draggingGhost);
    }
}
