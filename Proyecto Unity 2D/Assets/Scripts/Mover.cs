using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    //Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    //Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    //Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private CircleCollider2D miCollider2D;

    private int saltarMask;

    //Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<CircleCollider2D>();

        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }

    //Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        int velX = (int)miRigidbody2D.velocity.x;

        /* Lo hice de esta manera ya que haciéndolo como en el video del aula el flipX se hace invertido. */
        if(moverHorizontal > 0)
        {
            miSprite.flipX = false; //No se invierte.
        }
        else if(moverHorizontal < 0)
        {
            miSprite.flipX = true; //Se invierte.
        }

        miAnimator.SetInteger("Velocidad", velX);
        miAnimator.SetBool("EnAire", !ContactoPiso());

    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }

    private bool ContactoPiso()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }
}