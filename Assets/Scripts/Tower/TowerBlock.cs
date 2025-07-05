using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class TowerBlock
{
    public Vector3Int center;
    public List<Vector3Int> cells = new List<Vector3Int>();
    public bool isOccupied = false;

    public TowerBlock(Vector3Int centerCell, int size)
    {
        center = centerCell;
        int offset = size / 2;

        for (int x = -offset; x <= offset; x++)
        {
            for (int y = -offset; y <= offset; y++)
            {
                cells.Add(new Vector3Int(centerCell.x + x, centerCell.y + y, centerCell.z));
            }
        }
    }

    public void DrawGizmo(Tilemap tilemap, Color color)
    {
        Gizmos.color = color;

        foreach (var cell in cells)
        {
            Vector3 worldPos = tilemap.GetCellCenterWorld(cell);
            Gizmos.DrawWireCube(worldPos, tilemap.cellSize);
        }
    }

    public bool Contains(Vector3Int cell)
    {
        return cells.Contains(cell);
    }
}
