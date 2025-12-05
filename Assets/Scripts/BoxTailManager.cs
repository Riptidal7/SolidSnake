using System.Collections.Generic;
using UnityEngine;

public class BoxTailManager : MonoBehaviour
{
    public Grid grid;
    public List<Transform> TailBoxes;
    public Transform TailBoxPrefab;
    public List<Vector3Int> positionHistory;
    
    private Vector3Int lastHeadCell;

    private void Awake()
    {
        TailBoxes = new List<Transform>();
        positionHistory = new List<Vector3Int>();
        TailBoxes.Add(transform);
        
        Vector3Int startCell = grid.WorldToCell(transform.position);
        GridChecker.Add(startCell);
        lastHeadCell = startCell;
    }

    private void FixedUpdate()
    {
        Vector3Int headCell = grid.WorldToCell(TailBoxes[0].position);

        if (headCell != lastHeadCell)
        {
            GridChecker.Remove(lastHeadCell);
            
            GridChecker.Add(headCell);

            lastHeadCell = headCell;
            positionHistory.Insert(0, headCell);
            
            for (int i = 1; i < TailBoxes.Count; i++)
            {
                int index = i * GameParameters.GapDistance;
                if (index < positionHistory.Count)
                {
                    Vector3Int cell = positionHistory[index];
                    Vector3 worldPos = grid.GetCellCenterWorld(cell);
                    
                    Vector3Int oldCell = grid.WorldToCell(TailBoxes[i].position);
                    GridChecker.Remove(oldCell);
                    
                    TailBoxes[i].position = worldPos;
                    
                    GridChecker.Add(cell);
                }
            }
        }
        
        if (positionHistory.Count > 10000)
            positionHistory.RemoveRange(10000, positionHistory.Count - 10000);

    }

    private void Grow()
    {
        Transform newSegment = Instantiate(TailBoxPrefab);
        
        newSegment.position = new Vector3(9999f, 9999f, 0f);

        TailBoxes.Add(newSegment);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
            Grow();
        if (other.CompareTag("Tail"))
        {
            GameEvents.OnTailHit?.Invoke();
        }
    }
    
    public void ResetSnake()
    {
        // Reset grid
        GridChecker.ClearAll();

        // Destroy all tail except head
        for (int i = 1; i < TailBoxes.Count; i++)
            Destroy(TailBoxes[i].gameObject);

        TailBoxes.Clear();
        TailBoxes.Add(transform);

        // Clear position history
        positionHistory.Clear();

        // Reset head position
        Vector3Int startCell = grid.WorldToCell(transform.position);
        lastHeadCell = startCell;
        GridChecker.Add(startCell);
    }

}