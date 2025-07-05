using UnityEngine;
using System;

public class TickSystem : MonoBehaviour
{
    public static event Action OnTickMovePhase;
    public static event Action OnTickAttackPhase;

    private float tickInterval = 1f; 
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

            // Move phase first
            OnTickMovePhase?.Invoke();

            // Attack phase after
            OnTickAttackPhase?.Invoke();
        }
    }
}
