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
            RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = GridArea.bounds;
        
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        Vector3 randomWorldPos = new Vector3(x, y);
        
        Vector3Int cell = grid.WorldToCell(randomWorldPos);
        
        Vector3 snappedPos = grid.GetCellCenterWorld(cell);
        
        transform.position = snappedPos;
    }
    

    
}
