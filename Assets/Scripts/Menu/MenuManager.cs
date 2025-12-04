using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimpleMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button musicButton;
    public Button exitButton;
    public string gameScene = "Nivel_1";
    
    // Referencia a la música
    private BackgroundMusicController2 musicController;
    
    void Start()
    {
        // Buscar la música
        musicController = FindObjectOfType<BackgroundMusicController2>();
        
        // Configurar botones
        if (playButton != null)
        {
            playButton.onClick.AddListener(Jugar);
        }
        
        if (musicButton != null)
            musicButton.onClick.AddListener(ToggleMusic);
        
        if (exitButton != null)
            exitButton.onClick.AddListener(QuitGame);
    }
    
    void Jugar()
    {
        // Detener la música antes de cambiar de escena
        if (musicController != null)
        {
            musicController.StopBackgroundMusic();
        }
        
        // Cargar la nueva escena
        SceneManager.LoadScene(gameScene);
    }
    
    void ToggleMusic()
    {
        if (musicController != null)
        {
            if (musicController.IsMusicPlaying())
            {
                musicController.StopBackgroundMusic();
                Debug.Log("Música apagada");
            }
            else
            {
                musicController.PlayBackgroundMusic();
                Debug.Log("Música encendida");
            }
        }
    }
    
    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}