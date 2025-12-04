using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager2 : MonoBehaviour
{
    public static LevelManager2 Instance;

    [Header("1. Requerimientos de Gotas de Agua")]
    public int totalDropsRequired = 10;
    public string nextSceneName = "NextLevel";

    [Header("2. Referencias UI")]
    public UIManager2 uiManager;

    [Header("3. Paneles")]
    public GameObject winPanel;
    
    [Header("4. Texto UI")]
    public TextMeshProUGUI dropsText;
    
    [Header("5. Formato del Texto")]
    [SerializeField] private string textFormat = "Gotas: {0}/{1} ({2}%)";

    private int collectedDrops = 0;

    void Awake()
    {
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
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
        UpdateUI();
    }

    public void CollectDrop()
    {
        collectedDrops++;
        UpdateUI();
        Debug.Log($"Gotas recolectadas: {collectedDrops}/{totalDropsRequired}");
        
        // **CAMBIADO: Ya NO se llama a CompleteLevel() aquí**
        // Solo se actualiza la UI
    }

    private void UpdateUI()
    {
        // Actualizar UIManager si existe
        if (uiManager != null)
        {
            uiManager.UpdateDropsUI(collectedDrops);
        }

        // Actualizar texto directamente si está asignado
        if (dropsText != null)
        {
            float percentage = ((float)collectedDrops / totalDropsRequired) * 100f;
            string formattedText = string.Format(textFormat, 
                collectedDrops, 
                totalDropsRequired, 
                percentage.ToString("F1"));
            
            dropsText.text = formattedText;
            UpdateTextColor(dropsText, percentage);
        }
    }

    private void UpdateTextColor(TextMeshProUGUI text, float percentage)
    {
        if (percentage >= 100f)
            text.color = Color.green;
        else if (percentage >= 70f)
            text.color = Color.yellow;
        else if (percentage >= 30f)
            text.color = Color.white;
        else
            text.color = Color.red;
    }

    // **MÉTODO NUEVO: Para ser llamado por la Revolvedora**
    public void TryDeliverWater()
    {
        // Verificar si tiene todas las gotas
        if (collectedDrops >= totalDropsRequired)
        {
            CompleteLevel();
        }
        else
        {
            Debug.Log($"Faltan {totalDropsRequired - collectedDrops} gotas");
            // Opcional: Mostrar mensaje en pantalla
        }
    }

    private void CompleteLevel()
    {
        Debug.Log("¡Nivel Completado! Entregaste el agua a la máquina.");
        ShowWinPanel();
    }

    public void ShowWinPanel()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Debug.Log("¡Mostrando panel de Victoria!");
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("WinPanel no asignado en LevelManager");
        }
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1f;
        
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public int TotalDropsRequired => totalDropsRequired;
    public int CollectedDrops => collectedDrops;
    public float DropPercentage => ((float)collectedDrops / totalDropsRequired) * 100f;
    public bool IsLevelComplete => collectedDrops >= totalDropsRequired;
}