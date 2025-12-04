using UnityEngine;

public class IntroPanelController : MonoBehaviour
{
    [Header("Referencias de Paneles")]
    public GameObject panelPrincipal;    // Primer panel (instrucciones asfalto)
    public GameObject panelObjetivo;     // Segundo panel (objetivos del nivel)
    
    void Start()
    {
        // Pausar el juego inmediatamente al inicio
        Time.timeScale = 0f;
        
        // Configurar estado inicial de los paneles
        if (panelPrincipal != null)
        {
            panelPrincipal.SetActive(true);  // Mostrar primer panel
        }
        
        if (panelObjetivo != null)
        {
            panelObjetivo.SetActive(false);  // Ocultar segundo panel
        }
    }

    // Método para ir al siguiente panel (llamado por el botón "Siguiente")
    public void ShowNextPanel()
    {
        // Ocultar panel principal
        if (panelPrincipal != null)
        {
            panelPrincipal.SetActive(false);
        }
        
        // Mostrar panel objetivo
        if (panelObjetivo != null)
        {
            panelObjetivo.SetActive(true);
        }
        
        Debug.Log("Cambiando al panel de objetivos");
    }

    // Método para comenzar el juego (llamado por el botón "Comenzar")
    public void StartGame()
    {
        // Reanudar el juego
        Time.timeScale = 1f;
        
        // Ocultar todos los paneles
        if (panelPrincipal != null)
        {
            panelPrincipal.SetActive(false);
        }
        
        if (panelObjetivo != null)
        {
            panelObjetivo.SetActive(false);
        }
        
        Debug.Log("¡Juego iniciado!");
    }
}