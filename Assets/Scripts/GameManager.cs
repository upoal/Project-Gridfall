using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Gameplay References")]
    public Button playButton;
    public TickSystem tickSystem;
    public EnemySpawner enemySpawner;

    [Header("Lives System")]
    public int startingLives = 10;
    public int currentLives;
    public Text livesText; 

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Debug.Log("GameManager Start running");

        if (playButton == null || tickSystem == null || enemySpawner == null)
        {
            Debug.LogError("GameManager: One or more required references are not assigned in the Inspector!");
            return;
        }

        playButton.onClick.AddListener(StartWave);

        // Initialize lives
        currentLives = startingLives;
        UpdateLivesUI();
    }

    void StartWave()
    {
        Debug.Log("Play button clicked — starting wave");
        enemySpawner.SpawnEnemy();
        tickSystem.StartTicking();
        playButton.interactable = false;
    }

    public void ReduceLives(int amount)
    {
        currentLives -= amount;
        Debug.Log("Lives reduced by " + amount + ". Current lives: " + currentLives);
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
            // TODO: Implement game over UI or logic
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = currentLives.ToString();
        }
    }
}
