using UnityEngine;
using UnityEngine.UI;

public class BotonNivelFinal : MonoBehaviour
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

        // Asignar la función al hacer click
        boton.onClick.AddListener(OnClickBoton);

        Debug.Log($"Botón {gameObject.name} configurado para ir al Final");
    }

    void OnClickBoton()
    {
        Debug.Log($"Botón {gameObject.name} clickeado - Cambiando a escena Final");

        // Buscar el WinManager
        WinManager winManager = FindObjectOfType<WinManager>();

        if (winManager == null)
        {
            Debug.Log("WinManager no encontrado. Creando uno nuevo...");

            GameObject winManagerObj = new GameObject("WinManager");
            winManager = winManagerObj.AddComponent<WinManager>();
            DontDestroyOnLoad(winManagerObj);
        }

        // Usar WinManager para cambiar a la escena Final
        winManager.LoadFinal();
    }

    // Método alternativo asignable desde el Inspector
    public void CambiarAFinal()
    {
        OnClickBoton();
    }
}
