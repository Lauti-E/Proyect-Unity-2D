using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Jugador : MonoBehaviour
{

    [SerializeField]
    private PerfilJugador perfilJugador;

    public PerfilJugador PerfilJugador { get => perfilJugador; }


    //Eventos del jugador.
    [SerializeField]
    private UnityEvent<int> ModificacionVidas;

    [SerializeField]
    private UnityEvent<string> CambioTexto;

    [SerializeField]
    private int vidasActuales; //Seguimiento de las vidas actuales.
    private int coleccionablesRec = 0; //Contador de coleccionables recolectados.

    private Vector3 posicionInicial; //Almacenará la posición inicial del jugador.

    private bool enTrampa = false; //Variable de estado para verificar si el jugador colisionó con un pincho.
    private bool haGanado = false; //Variable de estado para verificar si el jugador ganó.

    private void Start()
    {
        //Inicializa las vidas actuales.
         vidasActuales = perfilJugador.VidasIniciales;

        //Guardar la posición inicial del jugador al inicio del juego.
        posicionInicial = transform.position;

        ModificacionVidas.Invoke(perfilJugador.VidasIniciales);
        CambioTexto.Invoke(perfilJugador.VidasIniciales.ToString());
    }

    public void ModificarVida(int puntos)
    {
        vidasActuales += puntos;

        if (vidasActuales <= 0)
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
        vidasActuales = perfilJugador.VidasIniciales;
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
        else if (collision.gameObject.CompareTag("Coleccionable"))
        {
           coleccionablesRec++; //Incrementar el contador de coleccionables (frutas).
        }
        else if (collision.gameObject.CompareTag("Meta"))
        {
            if(coleccionablesRec >= 5 && !haGanado)
            {
                haGanado = true;
                Debug.Log("GANASTE!");
            }
        }
    }
}
