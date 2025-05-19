using UnityEngine;
using System.Collections;
using System;

public class TickSystem : MonoBehaviour
{
    public static event Action OnTick;

    private float tickInterval = 1f; // 1 second
    private float timer;

    public void StartTicking()
    {
        enabled = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickInterval)
        {
            timer -= tickInterval;
            OnTick?.Invoke();
        }
    }
}

