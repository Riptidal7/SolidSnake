using UnityEngine;

public class ExtractionZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.OnExtraction?.Invoke();
        }
    }
}
