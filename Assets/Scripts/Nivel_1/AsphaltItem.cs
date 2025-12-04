using UnityEngine;

public class AsphaltItem : MonoBehaviour
{
    // Usa el enum definido globalmente en Enums.cs
    [Header("Tipo de Material")]
    public AsphaltMaterialType materialType; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ya no hay ambigüedad. LevelManager.Instance ve el mismo enum global.
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.CollectMaterial(materialType);
            }

            Destroy(gameObject); 
        }
    }
}