using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager Instance;

    // IF MAKING 3X3 GROUP TILES, only make a list of the center tiles.
    public List<Vector3Int> pathTiles = new List<Vector3Int>();
    public List<Vector3Int> towerTiles = new List<Vector3Int>();
    public List<TowerBlock> towerBlocks = new List<TowerBlock>();


    public HashSet<Vector3Int> occupiedTiles = new HashSet<Vector3Int>();




    public Tilemap pathTilemap;

    public Tilemap towerTilemap;

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
        pathTiles.Add(new Vector3Int(13, -3, 0));


        foreach (var center in new Vector3Int[] {
        new Vector3Int(-8, 1, 0),
        new Vector3Int(-4, 1, 0),
        new Vector3Int(0, 1, 0),
        new Vector3Int(4, 1, 0),
        new Vector3Int(8, 1, 0)
        })
        {
            TowerBlock block = new TowerBlock(center, 3);
            towerBlocks.Add(block);

            // Optionally populate your master towerTiles list
            towerTiles.AddRange(block.cells);
        }

    }

    public Vector3 GetWorldPos(int index)
    {
        return pathTilemap.GetCellCenterWorld(pathTiles[index]);
    }

    void OnDrawGizmos()
{
    if (towerBlocks == null || towerTilemap == null) return;

    foreach (var block in towerBlocks)
    {
        Color color = block.isOccupied ? Color.red : Color.green;
        block.DrawGizmo(towerTilemap, color);
    }
}

    public Vector3Int[,] CreateBlockAroundCenter(Vector3Int centerCell, int size)
    {
        Vector3Int[,] block = new Vector3Int[size, size];
        int offset = size / 2;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                int tileX = centerCell.x + (x - offset);
                int tileY = centerCell.y + (y - offset);
                Vector3Int tilePos = new Vector3Int(tileX, tileY, centerCell.z);

                block[x, y] = tilePos;

                // Add each individual cell to the towerTiles list
                towerTiles.Add(tilePos);
            }
        }

        return block;
    }

    public TowerBlock GetBlockFromCell(Vector3Int cell)
    {
        foreach (var block in towerBlocks)
        {
            if (block.Contains(cell))
                return block;
        }
        return null;
    }
    
    public void OccupyBlock(TowerBlock block, HashSet<Vector3Int> occupiedTiles)
    {
        foreach (var cell in block.cells)
        {
            occupiedTiles.Add(cell);
        }
        block.isOccupied = true;
    }


}
