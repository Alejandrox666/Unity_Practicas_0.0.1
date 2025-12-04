using UnityEngine;

public class PeopleController : MonoBehaviour
{
    [Header("Objeto de entrega")]
    [SerializeField] private GameObject deliveryObject; 
    
    [Header("Configuración adicional")]
    [SerializeField] private bool useTrigger = true;
    [SerializeField] private KeyCode deliverKey = KeyCode.E;
    
    private bool canDeliver = false;
    
    private void Update()
    {
        // Opción de entregar con tecla
        if (!useTrigger && canDeliver && Input.GetKeyDown(deliverKey))
        {
            DeliverWater();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == deliveryObject)
        {
            Debug.Log("¡Persona en punto de entrega!");
            
            if (useTrigger)
            {
                // Entregar automáticamente al tocar
                DeliverWater();
            }
            else
            {
                // Solo permitir entrega con tecla
                canDeliver = true;
                Debug.Log($"Presiona {deliverKey} para entregar");
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == deliveryObject)
        {
            canDeliver = false;
            Debug.Log("Salió del punto de entrega");
        }
    }
    
    void DeliverWater()
    {
        if (LevelManager3.Instance != null)
        {
            LevelManager3.Instance.TryDeliverWater();
        }
        else
        {
            Debug.LogWarning("LevelManager3.Instance no encontrado");
        }
    }
    
    // Método para forzar entrega desde otro script
    public void ForceDeliver()
    {
        DeliverWater();
    }
}