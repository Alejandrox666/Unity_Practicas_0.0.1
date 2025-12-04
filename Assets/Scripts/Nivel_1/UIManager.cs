using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Referencia de la Lista de Materiales")]
    public TextMeshProUGUI materialsListText;

    [Header("Panel de Game Over")]
    public GameObject gameOverPanel; // Arrastra el panel aquí desde el Inspector

    private void Start()
    {
        // Ocultar el panel de Game Over al inicio
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Inicializa la UI con los requerimientos totales al inicio
        if (LevelManager.Instance != null)
        {
            UpdateAllCounts(0, 0, 0);
        }
    }

    // Método para mostrar el Game Over (solo activa el panel)
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("Mostrando panel de Game Over");
        }
    }

    // Tu método existente (sin cambios)
    public void UpdateAllCounts(int pCollected, int aCollected, int adCollected)
    {
        if (LevelManager.Instance == null) return;

        int pNeeded = LevelManager.Instance.requiredPetreos;
        int aNeeded = LevelManager.Instance.requiredAsfaltico;
        int adNeeded = LevelManager.Instance.requiredAditivos;

        string listContent = "<b>MATERIALES RECOGIDOS:</b>\n";
        
        string baseColor = "<color=#FFFFFF>";
        string completedColor = "<color=#00FF00>";

        string pColor = (pCollected >= pNeeded) ? completedColor : baseColor;
        listContent += $"{pColor}GRAVA (Pétreos): {pCollected} / {pNeeded}</color>\n";

        string aColor = (aCollected >= aNeeded) ? completedColor : baseColor;
        listContent += $"{aColor}BARRIL (Asfáltico): {aCollected} / {aNeeded}</color>\n";

        string adColor = (adCollected >= adNeeded) ? completedColor : baseColor;
        listContent += $"{adColor}CAJA (Aditivos): {adCollected} / {adNeeded}</color>";

        if (materialsListText != null)
        {
            materialsListText.text = listContent;
        }
    }
}