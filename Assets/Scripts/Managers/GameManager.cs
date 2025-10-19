using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int lives = 3;
    public int score = 0;
    public float respawnDelay = 2f;
    
    [Header("UI References")]
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    
    // Events
    public static System.Action<int> OnScoreChanged;
    public static System.Action<int> OnLivesChanged;
    public static System.Action OnGameOver;
    
    // Private variables
    private bool isGamePaused = false;
    private bool isGameOver = false;
    
    // Singleton pattern
    public static GameManager Instance { get; private set; }
    
    void Awake()
    {
        // Singleton implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        InitializeGame();
    }
    
    void Update()
    {
        HandleInput();
    }
    
    private void InitializeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;
        isGameOver = false;
        
        // Initialize UI
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        if (pausePanel != null)
            pausePanel.SetActive(false);
        
        // Trigger initial events
        OnScoreChanged?.Invoke(score);
        OnLivesChanged?.Invoke(lives);
    }
    
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameOver) return;
            
            if (isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    
    public void AddScore(int points)
    {
        if (isGameOver) return;
        
        score += points;
        OnScoreChanged?.Invoke(score);
    }
    
    public void LoseLife()
    {
        if (isGameOver) return;
        
        lives--;
        OnLivesChanged?.Invoke(lives);
        
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(RespawnPlayer());
        }
    }
    
    private System.Collections.IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);
        
        // Find and respawn player
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            // Reset player position to spawn point
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            if (spawnPoint != null)
            {
                player.transform.position = spawnPoint.transform.position;
            }
            
            // Reset player velocity
            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.velocity = Vector2.zero;
            }
        }
    }
    
    public void GameOver()
    {
        isGameOver = true;
        OnGameOver?.Invoke();
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        // Optionally pause the game
        Time.timeScale = 0f;
    }
    
    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }
    
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }
    
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}