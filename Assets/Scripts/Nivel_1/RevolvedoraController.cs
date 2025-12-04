using UnityEngine;

public class RevolvedoraController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Llamar al LevelManager para verificar si gana
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.TryCompleteLevel();
            }
        }
    }
}