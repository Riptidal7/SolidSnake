using System;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    private Collider2D Collider;

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameEvents.OnBorderHit?.Invoke(new GameEvents.OnBorderHitArgs
        {
            inBorder = false
        });
    }
}
