using UnityEngine;

public class BoxCollectible : MonoBehaviour
{
    public GameObject TailBox;
    public Transform SnakeHead;
    
    private Collider2D Collider;
    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AddBoxToSnake(collision);
        Destroy(gameObject);
    }

    private void AddBoxToSnake(Collision2D collision)
    {
        BoxTailManager tail = SnakeHead.GetComponent<BoxTailManager>();

        if (tail == null)
        {
            Debug.LogError("No BoxTailManager found in SnakeHead parent!");
            return;
        }

        Vector3 spawnPosition;

        if (tail.TailBoxes.Count == 0)
        {
            spawnPosition = SnakeHead.position - SnakeHead.right * GameParameters.TailSegmentSeparation;
        }
        else
        {
            Transform lastSegment = tail.TailBoxes[tail.TailBoxes.Count - 1];
            spawnPosition = lastSegment.position;
        }
        
        GameObject newTail = Instantiate(TailBox, spawnPosition, Quaternion.identity);
        newTail.transform.SetParent(SnakeHead);

        tail.TailBoxes.Add(newTail.transform);
    }

    
}
