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
        GameObject instantiatedTailBox = Instantiate(TailBox, SnakeHead.position, Quaternion.identity);
        instantiatedTailBox.transform.parent = transform;
        Destroy(gameObject);
    }
    
}
