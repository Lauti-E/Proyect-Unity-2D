using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private int vidasIniciales = 5;
    private int vidasActuales; //Seguimiento de las vidas actuales.
    private Vector3 posicionInicial; //Almacenará la posición inicial del jugador.
    private bool enTrampa = false; //Variable de estado para verificar si el jugador colisionó con un pincho.

    private void Start()
    {
        //Inicializa las vidas actuales.
        vidasActuales = vidasIniciales;

        //Guardar la posición inicial del jugador al inicio del juego.
        posicionInicial = transform.position;
    }

    public void ModificarVida(int puntos)
    {
        vidasActuales += puntos;

        if(vidasActuales <= 0)
        {
            //El jugador se quedó sin vidas, reiniciar juego.
            ReiniciarJuego();
        }
        else
        {
            Debug.Log("Vidas restantes: " + vidasActuales);
        }
    }

    private void ReiniciarJuego()
    {
        Debug.Log("Te quedaste sin vidas, vuelve a intentarlo.");
        transform.position = posicionInicial;
        vidasActuales = vidasIniciales;
    }

    private bool EstasVivo()
    {
        return vidasActuales > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa")) // Cambia "Trampa" al tag correcto de tus pinchos
        {
            // Restablecer la posición del jugador a la posición inicial
            transform.position = posicionInicial;

            ModificarVida(-1); //Restar una vida.

            Debug.Log("Has sido atrapado por la trampa. Vuelve a la posición inicial.");
        }
        else if (collision.gameObject.CompareTag("Meta"))
        {
            Debug.Log("GANASTE!");
        }
    }
}
