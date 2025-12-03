using System;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    private Collider2D Collider;

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.OnBorderHit?.Invoke();
    }
}
