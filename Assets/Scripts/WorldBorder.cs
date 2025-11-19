using System;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    private Collider2D Collider;

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.OnBorderHit?.Invoke(new GameEvents.OnBorderHitArgs
            {
                inBorder = false
            });
        }
    }
}
