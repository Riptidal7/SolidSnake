using System.Collections.Generic;
using UnityEngine;

public class GridChecker : MonoBehaviour
{
    public static HashSet<Vector3Int> occupiedCells = new HashSet<Vector3Int>();

    public static bool IsOccupied(Vector3Int cell)
    {
        return occupiedCells.Contains(cell);
    }

    public static void Add(Vector3Int cell)
    {
        occupiedCells.Add(cell);
    }

    public static void Remove(Vector3Int cell)
    {
        occupiedCells.Remove(cell);
    }

    public static void ClearAll()
    {
        occupiedCells.Clear();
    }
}
