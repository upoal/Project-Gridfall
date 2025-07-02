using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;

    private Transform target;
    private Vector3 offset;

    public void Initialize(Transform target, Vector3 offset)
    {
        this.target = target;
        this.offset = offset;
    }

    void LateUpdate()
    {
        if (target != null)
        {   
            Debug.Log("Position: " + target.position + " Offset: " + offset);
            transform.position = target.position + offset;
            transform.forward = Camera.main.transform.forward; // Always face camera
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
