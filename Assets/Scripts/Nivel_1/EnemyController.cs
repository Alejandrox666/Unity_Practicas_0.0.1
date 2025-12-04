using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables Ajustables en el Inspector
    public float patrolSpeed = 2f;
    public int damageAmount = 10; 
    public float knockbackForce = 5f; 
    
    // NUEVA VARIABLE: Fuerza de empuje para separarse del muro
    public float knockbackEnemy = 0.5f; 

    // Variables internas
    private Rigidbody2D rb2D;
    private Animator animator;
    private int direction = 1; // 1 = derecha, -1 = izquierda

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Patrol();
    }

    void Patrol()
    {
        // 1. Mover el enemigo
        rb2D.velocity = new Vector2(direction * patrolSpeed, rb2D.velocity.y);

        // 2. Controlar Animación
        if (animator != null)
        {
            animator.SetInteger("Direction", direction);
        }
    }

    // Lógica de Colisión (Daño al Player y Giro en el Muro)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. Detección de Muro de Confinamiento (Giro)
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyBlock"))
        {
            // CRÍTICO: El giro
            direction *= -1;
            
            // LÓGICA DE REBOTE AÑADIDA: Empuja al enemigo lejos del muro
            // Esto asegura que la colisión se "rompa" y la inercia cambie.
            if (rb2D != null)
            {
                // Aplica una pequeña fuerza en la dirección opuesta al choque (la nueva 'direction')
                rb2D.AddForce(new Vector2(direction * knockbackEnemy, 0f), ForceMode2D.Impulse);
            }
        }

        // 2. Detección del Player (Daño)
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            
            // Aplicar Knockback al Player
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}