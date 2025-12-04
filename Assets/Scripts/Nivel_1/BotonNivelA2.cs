// BotonNivel2.cs (asignar ESTE al botón)
using UnityEngine;
using UnityEngine.UI;

public class BotonNivel2 : MonoBehaviour
{
    void Start()
    {
        // Obtener el botón
        Button boton = GetComponent<Button>();
        
        if (boton == null)
        {
            Debug.LogError("Este GameObject no tiene un componente Button");
            return;
        }
        
        // Asignar la función al click
        boton.onClick.AddListener(OnClickBoton);
        
        Debug.Log($"Botón {gameObject.name} configurado para Nivel 2");
    }
    
    void OnClickBoton()
    {
        Debug.Log($"Botón {gameObject.name} clickeado - Cambiando a Nivel 2");
        
        // Buscar el WinManager
        WinManager winManager = FindObjectOfType<WinManager>();
        
        if (winManager == null)
        {
            Debug.Log("Creando WinManager...");
            GameObject winManagerObj = new GameObject("WinManager");
            winManager = winManagerObj.AddComponent<WinManager>();
            DontDestroyOnLoad(winManagerObj);
        }
        
        // Usar el WinManager para cambiar de escena
        winManager.LoadNivel2();
    }
    
    // Método alternativo que puedes asignar en el Inspector
    public void CambiarANivel2()
    {
        OnClickBoton();
    }
}