using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager Instance;

    public List<Vector3Int> pathTiles = new List<Vector3Int>();

    public Tilemap pathTilemap;

    void Awake()
    {
        Instance = this;

        // Manually define a path (example: right → down)
        pathTiles.Add(new Vector3Int(-14, -3, 0));
        pathTiles.Add(new Vector3Int(-8, -3, 0));
        pathTiles.Add(new Vector3Int(-4, -3, 0));
        pathTiles.Add(new Vector3Int(0, -3, 0));
        pathTiles.Add(new Vector3Int(4, -3, 0));
        pathTiles.Add(new Vector3Int(8, -3, 0));
    }

    public Vector3 GetWorldPos(int index)
    {
        return pathTilemap.GetCellCenterWorld(pathTiles[index]);
    }
}
