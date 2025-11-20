using System;
using UnityEngine;

public static class GameEvents
{
    public static Action<OnBorderHitArgs> OnBorderHit;

    public struct OnBorderHitArgs
    {
        public bool inBorder;
    }
}
