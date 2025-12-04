using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject pausePanel;
    public Button pauseButton;
    public Button resumeButton;
    public Button restartButton;
    public Button menuButton;
    public Button musicToggleButton; // Este es el botón de música del panel
    
    [Header("Control de Música")]
    public BackgroundMusicController musicController; // Tu controlador existente
    
    [Header("Configuración")]
    public bool isPaused = false;
    public string menuScene = "Menu";
    
    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
        
        if (pauseButton != null)
            pauseButton.onClick.AddListener(TogglePause);
        else
            Debug.LogError("PauseButton no asignado");
        
        if (resumeButton != null)
            resumeButton.onClick.AddListener(ResumeGame);
        
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
        else
            Debug.LogWarning("RestartButton no asignado");
        
        if (menuButton != null)
            menuButton.onClick.AddListener(GoToMenu);
        
        // ===== NUEVO: Conectar botón de música =====
        if (musicToggleButton != null)
        {
            // Buscar el controlador si no está asignado
            if (musicController == null)
                musicController = FindObjectOfType<BackgroundMusicController>();
            
            if (musicController != null)
            {
                // Conectar el botón al método del controlador
                musicToggleButton.onClick.AddListener(musicController.ToggleMusic);
                Debug.Log("Botón de música conectado al controlador");
            }
            else
            {
                Debug.LogWarning("No se encontró BackgroundMusicController");
            }
        }
        // ==========================================
        
        Time.timeScale = 1f;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
        
        Debug.Log($"Juego {(isPaused ? "Pausado" : "Reanudado")}");
    }
    
    void PauseGame()
    {
        Time.timeScale = 0f;
        
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            Debug.LogError("PausePanel no asignado");
        }
        
        // La música sigue sonando normalmente
        // NO usar: AudioListener.pause = true;
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
        
        // La música ya está sonando normalmente
        // NO usar: AudioListener.pause = false;
        
        isPaused = false;
    }
    
    void RestartLevel()
    {
        Debug.Log("Reiniciando nivel...");
        
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
    
    void GoToMenu()
    {
        Time.timeScale = 1f;
        
        WinManager winManager = FindObjectOfType<WinManager>();
        if (winManager != null)
        {
            winManager.LoadMenu();
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(menuScene);
        }
    }
    
    public void LogPauseState()
    {
        Debug.Log($"Pausa: {isPaused}, TimeScale: {Time.timeScale}, Panel activo: {pausePanel.activeSelf}");
    }
}