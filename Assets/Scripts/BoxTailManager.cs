using System.Collections.Generic;
using UnityEngine;

public class BoxTailManager : MonoBehaviour
{
    public Grid grid;
    public List<Transform> TailBoxes;
    public Transform TailBoxPrefab;

    private List<Vector3Int> positionHistory;
    private Vector3Int lastHeadCell;

    private void Start()
    {
        TailBoxes = new List<Transform>();
        positionHistory = new List<Vector3Int>();
        TailBoxes.Add(transform);
    }

    private void FixedUpdate()
    {
        Vector3Int headCell = grid.WorldToCell(TailBoxes[0].position);

        if (headCell != lastHeadCell)
        {
            lastHeadCell = headCell;
            positionHistory.Insert(0, headCell);

            // Move tail segments
            for (int i = 1; i < TailBoxes.Count; i++)
            {
                int index = i * GameParameters.GapDistance;
                if (index < positionHistory.Count)
                {
                    Vector3 worldPos = grid.GetCellCenterWorld(positionHistory[index]);
                    TailBoxes[i].position = worldPos;
                }
            }
        }

        if (positionHistory.Count > 10000)
            positionHistory.RemoveRange(10000, positionHistory.Count - 10000);
    }

    private void Grow()
    {
        Transform newSegment = Instantiate(TailBoxPrefab);
        Vector3Int lastCell = grid.WorldToCell(TailBoxes[TailBoxes.Count - 1].position);
        newSegment.position = grid.GetCellCenterWorld(lastCell);

        TailBoxes.Add(newSegment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
            Grow();
    }
}