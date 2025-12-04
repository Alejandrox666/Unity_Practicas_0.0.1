using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [Header("Botones")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    
    [Header("Sonido Game Over")]
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private float soundVolume = 0.7f;
    
    void Start()
    {
        // Asignar los eventos a los botones
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartLevel);
        
        if (menuButton != null)
            menuButton.onClick.AddListener(GoToMenu);
        
        // Reproducir sonido de Game Over al iniciar (cuando se active el panel)
        PlayGameOverSound();
    }
    
    // Método para reproducir el sonido
    private void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            // Crear un AudioSource temporal para el sonido
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, soundVolume);
        }
        else
        {
            Debug.LogWarning("No hay sonido de Game Over asignado");
        }
    }
    
    // Reiniciar el nivel actual
    public void RestartLevel()
    {
        // Obtener la escena actual y recargarla
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    
    // Ir al menú principal
    public void GoToMenu()
    {
        // Suponiendo que tu escena de menú está en el índice 0
        SceneManager.LoadScene(0);
    }
    
    // Opcional: Para evitar problemas con el Time.timeScale
    private void OnDestroy()
    {
        // Remover los listeners para evitar memory leaks
        if (restartButton != null)
            restartButton.onClick.RemoveListener(RestartLevel);
        
        if (menuButton != null)
            menuButton.onClick.RemoveListener(GoToMenu);
    }
}