using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    [Header("Configuración de Rebote")]
    [SerializeField] private float bounceHeight = 2f;
    [SerializeField] private float bounceSpeed = 3f;
    
    private Vector3 startPosition;
    private float bounceTimer;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Temporizador cíclico de 0 a 1
        bounceTimer += Time.deltaTime * bounceSpeed;
        if (bounceTimer > Mathf.PI * 2) bounceTimer = 0f;
        
        // Movimiento sinusoidal (suave arriba y abajo)
        float yOffset = Mathf.Sin(bounceTimer) * bounceHeight;
        transform.position = startPosition + new Vector3(0f, yOffset, 0f);
    }
}