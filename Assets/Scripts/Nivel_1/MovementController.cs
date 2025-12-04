using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    // --- MOVIMIENTO ---
    public float movementSpeed = 3.0f;
    public float jumpForce = 8.0f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGrounded = false;
    
    // --- CONTROLES TÁCTILES ---
    [Header("Controles Táctiles")]
    public bool useTouchControls = true; // Activar/desactivar controles táctiles
    private float touchInputX = 0f; // Input horizontal desde toques
    private bool jumpTouch = false; // Salto desde toque
    
    // --- REFERENCIAS ---
    private Rigidbody2D rb2D;
    private Animator animator;
    private Vector2 movement = new Vector2();
    
    // --- ANIMACIONES ---
    private string animationState = "AnimationState";
    enum CharStates {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,
        idleSouth = 5
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ===============================
        // 1. DETECCIÓN DE ENTRADAS
        // ===============================
        
        // RESET de inputs táctiles
        touchInputX = 0f;
        
        // A) INPUT DE TECLADO (PC)
        float keyboardInput = Input.GetAxisRaw("Horizontal");
        
        // B) INPUT TÁCTIL (ANDROID)
        if (useTouchControls && Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // Zona izquierda: mover a la izquierda
                if (touch.position.x < Screen.width * 0.3f)
                {
                    touchInputX = -1f;
                }
                // Zona derecha: mover a la derecha
                else if (touch.position.x > Screen.width * 0.7f)
                {
                    touchInputX = 1f;
                }
                // Zona central: saltar (si se acaba de tocar)
                else if (touch.position.x > Screen.width * 0.3f && 
                        touch.position.x < Screen.width * 0.7f &&
                        touch.phase == TouchPhase.Began)
                {
                    jumpTouch = true;
                }
            }
        }
        
        // Combinar inputs: táctil tiene prioridad si hay toques, si no, teclado
        if (Input.touchCount > 0)
        {
            movement.x = touchInputX;
        }
        else
        {
            movement.x = keyboardInput;
        }
        
        // ===============================
        // 2. SALTO (teclado + táctil)
        // ===============================
        bool jumpKeyPressed = Input.GetButtonDown("Jump");
        
        if ((jumpKeyPressed || jumpTouch) && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            jumpTouch = false; // Resetear salto táctil
        }
        
        // ===============================
        // 3. ACTUALIZAR ANIMACIONES
        // ===============================
        UpdateState();
    }

    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
    }

    private void FixedUpdate()
    {
        // 1. DETECCIÓN DE SUELO
        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        
        // 2. MOVER PERSONAJE
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        // Mantener la velocidad vertical (gravedad/salto) y aplicar horizontal
        rb2D.velocity = new Vector2(movement.x * movementSpeed, rb2D.velocity.y);
    }
    
    // ======================================
    // MÉTODOS PÚBLICOS PARA UI (OPCIONAL)
    // ======================================
    
    // Para botones de UI de movimiento
    public void MoveLeft(bool pressed)
    {
        if (pressed)
            movement.x = -1f;
        else if (movement.x < 0) // Solo reset si ya estaba en izquierda
            movement.x = 0f;
    }
    
    public void MoveRight(bool pressed)
    {
        if (pressed)
            movement.x = 1f;
        else if (movement.x > 0) // Solo reset si ya estaba en derecha
            movement.x = 0f;
    }
    
    // Para botón de salto en UI
    public void JumpButton()
    {
        if (isGrounded)
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }
}