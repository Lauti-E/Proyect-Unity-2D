using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    private Vector3 posicionInicial; //Almacenará la posición inicial del jugador.
    private bool enTrampa = false; //Variable de estado para verificar si el jugador colisionó con un pincho.

    private void Start()
    {
        //Guardar la posición inicial del jugador al inicio del juego.
        posicionInicial = transform.position;
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;

        Debug.Log(EstasVivo());
    }

    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa")) // Cambia "Trampa" al tag correcto de tus pinchos
        {
            // Restablecer la posición del jugador a la posición inicial
            transform.position = posicionInicial;
            Debug.Log("Has sido atrapado por la trampa. Vuelve a la posición inicial.");
        }
        else if (collision.gameObject.CompareTag("Meta"))
        {
            Debug.Log("GANASTE!");
        }
    }
}
