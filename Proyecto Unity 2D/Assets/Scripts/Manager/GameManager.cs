using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int intentos; //Intentos que tiene el jugador cada 5 vidas.
    private int puntosDescIntento = 5; //Puntos de vida para descontar un intento.

    public int IntentosRestantes { get => intentos; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            intentos = 5;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DescontarIntento()
    {
        intentos--;

        SceneManager.LoadScene(0);

        if (intentos <= 0)
        {
            //Agrega 5 intentos.
            intentos += 5;
        }
    }
}
