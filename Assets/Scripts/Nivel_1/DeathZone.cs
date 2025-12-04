using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador cayó en la zona de muerte
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Jugador cayó en la zona de muerte!");
            
            // Obtener el componente PlayerHealth del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            
            if (playerHealth != null)
            {
                // Matar al jugador instantáneamente
                playerHealth.TakeDamage(playerHealth.maxHealth); // Daño igual a la vida máxima
            }
            else
            {
                Debug.LogError("No se encontró PlayerHealth en el jugador");
            }
        }
    }
}