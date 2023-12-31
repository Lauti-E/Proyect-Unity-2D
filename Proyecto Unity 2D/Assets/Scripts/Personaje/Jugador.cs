using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{

    [SerializeField]
    private PerfilJugador perfilJugador;

    [SerializeField]
    private UnityEvent<string> VidasCargadas;

    public PerfilJugador PerfilJugador { get => perfilJugador; }

    [SerializeField]
    private int vidasActuales; //Seguimiento de las vidas actuales.
    private int coleccionablesRec = 0; //Contador de coleccionables recolectados.

    private Vector3 posicionInicial; //Almacenar� la posici�n inicial del jugador.

    private bool enTrampa = false; //Variable de estado para verificar si el jugador colision� con un pincho.
    private bool haGanado = false; //Variable de estado para verificar si el jugador gan�.

    private const string VidasKey = "Vidas"; //Clave para PlayerPrefs.

    private void Start()
    {
        //Inicializa las vidas actuales desde PlayerPrefs.
        vidasActuales = PersistenceManager.Instance.GetInt(VidasKey, perfilJugador.VidasIniciales);

        //Guardar la posici�n inicial del jugador al inicio del juego.
        posicionInicial = transform.position;

        VidasCargadas.Invoke(vidasActuales.ToString());
    }

    public void ModificarVida(int puntos)
    {
        vidasActuales += puntos;

        vidasActuales = Mathf.Max(vidasActuales, 0);

        VidasCargadas.Invoke(vidasActuales.ToString());

        //Guardar las vidas actuales en PlayerPrefs.
        PersistenceManager.Instance.SetInt(VidasKey, vidasActuales);

        if (vidasActuales <= 0)
        {
            //El jugador se qued� sin vidas, descontar un intento.
            GameManager.Instance.DescontarIntento();

            //El jugador se qued� sin vidas, volver a la posicion inicial.
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

        //Restablecer la posici�n del jugador a la posici�n inicial.
        transform.position = posicionInicial;

        //Restablecer las vidas actuales a la cantidad inicial.
        vidasActuales = perfilJugador.VidasIniciales;

        VidasCargadas.Invoke(vidasActuales.ToString());

        //Guardar las vidas iniciales en PlayerPrefs.
        PersistenceManager.Instance.SetInt(VidasKey, perfilJugador.VidasIniciales);
    }

    private bool EstasVivo()
    {
        return vidasActuales > 0;
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
