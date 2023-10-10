using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] private PerfilJugador perfilJugador;

    private Vector3 posicionInicial; //Almacenar� la posici�n inicial del jugador.

    private bool enTrampa = false; //Variable de estado para verificar si el jugador colision� con un pincho.
    private bool haGanado = false; //Variable de estado para verificar si el jugador gan�.

    private void Start()
    {
        //Inicializa las vidas actuales.
         perfilJugador.VidasActuales = perfilJugador.VidasIniciales;

        //Guardar la posici�n inicial del jugador al inicio del juego.
        posicionInicial = transform.position;
    }

    public void ModificarVida(int puntos)
    {
       perfilJugador.VidasActuales += puntos;

        if(perfilJugador.VidasActuales <= 0)
        {
            //El jugador se qued� sin vidas, reiniciar juego.
            ReiniciarJuego();
        }
        else
        {
            Debug.Log("Vidas restantes: " + perfilJugador.VidasActuales);
        }
    }

    private void ReiniciarJuego()
    {
        Debug.Log("Te quedaste sin vidas, vuelve a intentarlo.");
        transform.position = posicionInicial;
        perfilJugador.VidasActuales = perfilJugador.VidasIniciales;
    }

    private bool EstasVivo()
    {
        return perfilJugador.VidasActuales > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa")) // Cambia "Trampa" al tag correcto de tus pinchos
        {
            // Restablecer la posici�n del jugador a la posici�n inicial
            transform.position = posicionInicial;

            ModificarVida(-1); //Restar una vida.

            Debug.Log("Has sido atrapado por la trampa. Vuelve a la posici�n inicial.");
        }
        else if (collision.gameObject.CompareTag("Coleccionable"))
        {
            perfilJugador.ColeccionablesRec++; //Incrementar el contador de coleccionables (frutas).
        }
        else if (collision.gameObject.CompareTag("Meta"))
        {
            if(perfilJugador.ColeccionablesRec >= 5 && !haGanado)
            {
                haGanado = true;
                Debug.Log("GANASTE!");
            }
        }
    }
}
