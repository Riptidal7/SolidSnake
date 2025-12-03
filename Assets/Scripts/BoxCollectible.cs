using UnityEngine;

public class BoxCollectible : MonoBehaviour
{
    public BoxCollider2D GridArea;
    public Grid grid;
    
    
    void Start()
    {
        RandomizePosition();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RandomizePosition();
            GameEvents.OnBoxCollected?.Invoke();
        }
    }

    private void RandomizePosition()
    {
        Bounds bounds = GridArea.bounds;

        for (int i = 0; i < 200; i++)
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            Vector3 randomWorldPos = new Vector3(x, y);
        
            Vector3Int cell = grid.WorldToCell(randomWorldPos);
        
            if (!GridChecker.IsOccupied(cell))
            {
                Vector3 snappedPos = grid.GetCellCenterWorld(cell);
                transform.position = snappedPos;

                GridChecker.Add(cell);
                return;
            }
        }
    }

    

    
}
