using UnityEngine;

public class WaterDrop2 : MonoBehaviour
{
    [Header("Configuración de la Gota")]
    [SerializeField] private int dropValue = 1;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private GameObject collectEffect;

    [Header("Animación")]
    [SerializeField] private float floatSpeed = 2f;
    [SerializeField] private float floatHeight = 0.3f;
    
    private Vector3 startPosition;
    private bool isCollected = false;

    void Start()
    {
        startPosition = transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360f));
    }

    void Update()
    {
        if (!isCollected)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            transform.Rotate(0, 0, 20f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            CollectDrop();
        }
    }

    private void CollectDrop()
    {
        isCollected = true;

        // IMPORTANTE: Usar LevelManager2 en lugar de LevelManager
        if (LevelManager3.Instance != null)  // ← Cambiado
        {
            LevelManager3.Instance.CollectDrop();  // ← Cambiado
        }

        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, 0.7f);
        }

        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }
}