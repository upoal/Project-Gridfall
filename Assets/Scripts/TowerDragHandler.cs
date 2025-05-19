using UnityEngine;
using UnityEngine.EventSystems;

public class TowerDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject towerPrefab;
    private GameObject draggingTower;

    public Camera mainCamera;

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingTower = Instantiate(towerPrefab);
        // draggingTower.GetComponent<Collider2D>().enabled = false; // So it doesn't block raycasts
        draggingTower.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f); // Transparent
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        draggingTower.transform.position = worldPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        Vector3Int cell = PathManager.Instance.towerTilemap.WorldToCell(worldPos);

        if (PathManager.Instance.towerTilemap.HasTile(cell))
            {
                Debug.Log("Valid buildable tile");

                TowerBlock block = PathManager.Instance.GetBlockFromCell(cell);

                if (block != null && !block.isOccupied)
                {
                    Debug.Log("Placing tower");
                    // Place tower at center
                    Vector3Int center = block.center;
                    Vector3 placePos = PathManager.Instance.towerTilemap.GetCellCenterWorld(center);
                    Instantiate(towerPrefab, placePos, Quaternion.identity);
                    PathManager.Instance.OccupyBlock(block, PathManager.Instance.occupiedTiles);
                }
                else
                {
                    Debug.Log("Block already occupied");
                }
            }
            else
            {
                Debug.Log("Not a buildable tile");
            }

        Destroy(draggingTower);
    }
}
