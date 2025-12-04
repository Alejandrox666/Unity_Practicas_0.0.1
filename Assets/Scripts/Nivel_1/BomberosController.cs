using UnityEngine;

public class BomberoController : MonoBehaviour
{
    [Header("Objeto al que debe entregar el agua")]
    [SerializeField] private GameObject deliveryObject; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == deliveryObject)
        {
            Debug.Log("¡Colisión con el objeto asignado!");

            if (LevelManager2.Instance != null)
            {
                LevelManager2.Instance.TryDeliverWater();
            }
        }
    }
}
