using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarANivel2 : MonoBehaviour
{
    public string nombreNivel2 = "Nivel_2";
    
    void Start()
    {
        // Buscar el botón y asignar el evento
        Button boton = GetComponent<Button>();
        
        if (boton != null)
        {
            boton.onClick.AddListener(IrANivel2);
        }
        else
        {
            Debug.LogError("Este script necesita un componente Button");
        }
    }
    
    void IrANivel2()
    {
        Debug.Log("Cambiando a Nivel 2...");
        
        if (!string.IsNullOrEmpty(nombreNivel2))
        {
            SceneManager.LoadScene(nombreNivel2);
        }
        else
        {
            Debug.LogError("No se especificó nombre de escena para Nivel 2");
        }
    }
}