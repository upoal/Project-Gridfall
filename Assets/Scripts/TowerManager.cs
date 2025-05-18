using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class TowerPlacementManager : MonoBehaviour
{
    public Tilemap buildableTilemap;
    public GameObject towerPrefab;
    private Camera mainCamera;


    public HashSet<Vector3Int> occupiedTiles = new HashSet<Vector3Int>();


    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");

            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;  // flatten z coordinate, cuz of isometric z as y

            // clicked cell
            Vector3Int cellPos = buildableTilemap.WorldToCell(mouseWorldPos);   
            cellPos.z = 0;

            Debug.Log("Clicked Cell: " + cellPos);
            Debug.Log("Using tilemap: " + buildableTilemap.name);

            if (buildableTilemap.HasTile(cellPos))
            {
                Debug.Log("Valid buildable tile");

                TowerBlock block = PathManager.Instance.GetBlockFromCell(cellPos);

                if (block != null && !block.isOccupied)
                {
                    Debug.Log("Placing tower");
                    // Place tower at center
                    Vector3Int center = block.center;
                    Vector3 worldPos = buildableTilemap.GetCellCenterWorld(center);
                    Instantiate(towerPrefab, worldPos, Quaternion.identity);
                    PathManager.Instance.OccupyBlock(block, occupiedTiles);
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
        }
    }
    
    private Vector3Int GetBlockCenter(Vector3Int clicked)
    {
        // Snap the cell coordinates to the nearest multiple of 3
        int centerX = Mathf.FloorToInt((clicked.x + 1) / 3f) * 3;
        int centerY = Mathf.FloorToInt((clicked.y + 1) / 3f) * 3;
        return new Vector3Int(centerX, centerY, 0);
    }


}

