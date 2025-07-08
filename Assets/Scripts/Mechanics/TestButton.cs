// TEMPORARY script on your button
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            Debug.Log("Button clicked!");
        });
    }
}
