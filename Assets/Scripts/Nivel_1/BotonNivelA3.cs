// BotonCambiarNivel.cs (único script para todos los niveles)
using UnityEngine;
using UnityEngine.UI;

public class BotonCambiarNivel : MonoBehaviour
{
    [Header("Configuración")]
    public string targetSceneName = "Nivel3"; // Escena a cargar
    public bool useWinManager = true; // Usar WinManager o cargar directamente
    
    void Start()
    {
        Button boton = GetComponent<Button>();
        
        if (boton == null)
        {
            Debug.LogError("No hay Button en este GameObject");
            return;
        }
        
        boton.onClick.AddListener(OnClickBoton);
        Debug.Log($"Botón {gameObject.name} configurado para cargar: {targetSceneName}");
    }
    
    void OnClickBoton()
    {
        Debug.Log($"Cambiando a: {targetSceneName}");
        
        if (useWinManager)
        {
            // Usar WinManager
            WinManager winManager = FindObjectOfType<WinManager>();
            
            if (winManager == null)
            {
                Debug.Log("Creando WinManager...");
                GameObject winManagerObj = new GameObject("WinManager");
                winManager = winManagerObj.AddComponent<WinManager>();
                DontDestroyOnLoad(winManagerObj);
            }
            
            // Usar método genérico
            winManager.LoadScene(targetSceneName);
        }
        else
        {
            // Cargar directamente
            UnityEngine.SceneManagement.SceneManager.LoadScene(targetSceneName);
        }
    }
    
    // Método para el Inspector
    public void CambiarEscena()
    {
        OnClickBoton();
    }
}