using UnityEngine;
using TMPro;

public class UIManager3 : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI dropsText; // SOLO UN TEXTO AHORA
    
    [Header("Panel de Game Over")]
    public GameObject gameOverPanel;

    [Header("Formato del Texto")]
    [SerializeField] private string textFormat = "Gotas: {0}/{1} ({2}%)";
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color highPercentageColor = Color.yellow;
    [SerializeField] private Color completeColor = Color.green;

    void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        UpdateDropsUI(0);
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("Mostrando panel de Game Over");
        }
    }

    // Método para mostrar gotas y porcentaje en un solo texto
    public void UpdateDropsUI(int dropsCollected)
    {
        if (LevelManager3.Instance == null) return;

        int totalDropsNeeded = LevelManager3.Instance.TotalDropsRequired;
        float percentage = ((float)dropsCollected / totalDropsNeeded) * 100f;
        
        // Formatear el texto
        string formattedText = string.Format(textFormat, 
            dropsCollected, 
            totalDropsNeeded, 
            percentage.ToString("F1")); // F1 = un decimal
        
        if (dropsText != null)
        {
            dropsText.text = formattedText;
            
            // Cambiar color según progreso
            if (percentage >= 100f)
                dropsText.color = completeColor;
            else if (percentage >= 50f)
                dropsText.color = highPercentageColor;
            else
                dropsText.color = normalColor;
        }
    }
    
    public void RefreshUI()
    {
        if (LevelManager3.Instance != null)
        {
            UpdateDropsUI(LevelManager3.Instance.CollectedDrops);
        }
    }
}