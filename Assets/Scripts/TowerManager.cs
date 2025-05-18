using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class TowerPlacementManager : MonoBehaviour
{
    public Tilemap towerTilemap;
    public GameObject towerPrefab;
    private Camera mainCamera;

    private HashSet<Vector3Int> occupiedPositions = new HashSet<Vector3Int>();

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Debug.Log("Mouse clicked");

            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = towerTilemap.WorldToCell(mouseWorldPos);
            Debug.Log("Clicked Cell: " + cellPos);

            if (towerTilemap.HasTile(cellPos))
            {
                Debug.Log("Valid buildable tile");

                if (!occupiedPositions.Contains(cellPos))
                {
                    Debug.Log("Placing tower");
                    Vector3 placePos = towerTilemap.GetCellCenterWorld(cellPos);
                    Instantiate(towerPrefab, placePos, Quaternion.identity);
                    occupiedPositions.Add(cellPos);
                }
                else
                {
                    Debug.Log("Tile already occupied");
                }
            }
            else
            {
                Debug.Log("Not a buildable tile");
            }
        }
    }
}
