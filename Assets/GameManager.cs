using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button playButton;
    public TickSystem tickSystem;
    public EnemySpawner enemySpawner;

    void Start()
    {
        Debug.Log("GameManager Start running");
        if (playButton == null || tickSystem == null || enemySpawner == null)
        {
            Debug.LogError("GameManager: One or more required references are not assigned in the Inspector!");
            return;
        }

        playButton.onClick.AddListener(StartWave);
    }

    void StartWave()
    {
        Debug.Log("Play button clicked — starting wave");
        enemySpawner.SpawnEnemy();
        tickSystem.StartTicking();
        playButton.interactable = false;
    }
}
