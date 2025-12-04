using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    // Singleton para acceder desde cualquier lugar
    private static WinManager instance;
    public static WinManager Instance { get { return instance; } }
    
    [Header("Escenas")]
    public string nivel1Scene = "Nivel_1";
    public string nivel2Scene = "Nivel_2";
    public string nivel3Scene = "Nivel3";  
    public string menuScene = "Menu";

    // 👉 NUEVO: Campo para la escena Final
    public string finalScene = "Final";
    
    void Awake()
    {
        // Configurar singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("WinManager inicializado");
    }
    
    // Métodos públicos para cambiar de escena
    public void LoadNivel1()
    {
        CambiarEscena(nivel1Scene);
    }
    
    public void LoadNivel2()
    {
        CambiarEscena(nivel2Scene);
    }
    
    public void LoadNivel3()
    {
        CambiarEscena(nivel3Scene);
    }
    
    public void LoadMenu()
    {
        CambiarEscena(menuScene);
    }

    // 👉 NUEVO: Método para cargar la escena Final
    public void LoadFinal()
    {
        CambiarEscena(finalScene);
    }
    
    // MÉTODO GENÉRICO
    public void LoadScene(string sceneName)
    {
        CambiarEscena(sceneName);
    }
    
    private void CambiarEscena(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Nombre de escena vacío");
            return;
        }
        
        Debug.Log($"WinManager: Cambiando a {sceneName}");
        
        var music = FindObjectOfType<BackgroundMusicController2>();
        if (music != null)
        {
            music.StopBackgroundMusic();
        }
        
        SceneManager.LoadScene(sceneName);
    }
    
    public bool SceneExists(string sceneName)
    {
        return Application.CanStreamedLevelBeLoaded(sceneName);
    }
}
