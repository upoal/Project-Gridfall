using UnityEngine;
using System.Collections;
using System;

public class TickSystem : MonoBehaviour
{
    public static Action OnTick;
    public float tickInterval = 0.3f; // 1 second per tick
    private bool isTicking = false;

    public void StartTicking()
    {
        if (!isTicking)
            StartCoroutine(TickLoop());
    }

    IEnumerator TickLoop()
    {
        isTicking = true;
        while (true)
        {
            yield return new WaitForSeconds(tickInterval);
            OnTick?.Invoke();
        }
    }
}
