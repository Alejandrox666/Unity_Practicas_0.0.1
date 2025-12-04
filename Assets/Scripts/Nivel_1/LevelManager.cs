using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Patrón Singleton: Permite acceder a esta clase desde cualquier otro script
    public static LevelManager Instance; 

    // --- Variables Ajustables en el Inspector ---
    [Header("1. Requerimientos de Asfalto")]
    // Los valores que ajustaste (4, 2, 2)
    public int requiredPetreos = 4;
    public int requiredAsfaltico = 2;
    public int requiredAditivos = 2;
    public string nextSceneName = "NextLevel"; // Nombre de la escena a cargar al completar

    [Header("2. Referencias UI")]
    // Referencia al script UIManager para actualizar el contador en pantalla
    public UIManager uiManager; 

    [Header("3. Panel de Victoria")]
    public GameObject winPanel; // Arrastra el panel You Win aquí desde el Inspector

    // --- Contadores Internos ---
    private int collectedPetreos = 0;
    private int collectedAsfaltico = 0;
    private int collectedAditivos = 0;

    void Awake()
    {
        // Implementación Singleton: Asegura que solo haya una instancia
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Ocultar panel de victoria al inicio
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    // Método llamado por los ítems (AsphaltItem.cs) al ser recogidos
    public void CollectMaterial(AsphaltMaterialType type)
    {
        // 1. Aumentar el contador correcto
        switch (type)
        {
            case AsphaltMaterialType.Petreos:
                collectedPetreos++;
                break;
            case AsphaltMaterialType.Asfaltico:
                collectedAsfaltico++;
                break;
            case AsphaltMaterialType.Aditivos:
                collectedAditivos++;
                break;
        }
        
        // 2. Actualizar la Interfaz de Usuario (UI)
        if (uiManager != null)
        {
            uiManager.UpdateAllCounts(collectedPetreos, collectedAsfaltico, collectedAditivos);
        }

        Debug.Log($"Recolectado: {type} | P: {collectedPetreos}/{requiredPetreos} | A: {collectedAsfaltico}/{requiredAsfaltico} | Ad: {collectedAditivos}/{requiredAditivos}");
    }

    // Método para mostrar el panel de victoria
    public void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Debug.Log("¡Mostrando panel de Victoria!");
        }
        else
        {
            Debug.LogError("WinPanel no asignado en LevelManager");
        }
    }

    // Método llamado por la Revolvedora (RevolvedoraController.cs)
    public bool TryCompleteLevel()
    {
        // 1. Verificar si todos los requerimientos se cumplen
        bool petreosDone = collectedPetreos >= requiredPetreos;
        bool asfalticoDone = collectedAsfaltico >= requiredAsfaltico;
        bool aditivosDone = collectedAditivos >= requiredAditivos;

        if (petreosDone && asfalticoDone && aditivosDone)
        {
            // 2. ¡Nivel Completado!
            Debug.Log("¡Nivel Completado! Mostrando panel de victoria.");
            
            // Mostrar panel de victoria
            ShowWinPanel();
            
            return true;
        }
        else
        {
            // 3. Informar al jugador qué falta
            string missing = "";
            if (!petreosDone) missing += $"- Falta {requiredPetreos - collectedPetreos} Grava (Pétreos). ";
            if (!asfalticoDone) missing += $"- Falta {requiredAsfaltico - collectedAsfaltico} Barril (Asfáltico). ";
            if (!aditivosDone) missing += $"- Falta {requiredAditivos - collectedAditivos} Caja (Aditivos).";
            
            Debug.Log("Aún faltan materiales: " + missing);
            return false;
        }
    }
}