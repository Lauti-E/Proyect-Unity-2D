using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private HUDController hudController;

    private int intentos; //Intentos que tiene el jugador cada 5 vidas.

    public int IntentosRestantes { get => intentos; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            intentos = 3;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        GameEvents.EnPausa += Pausar;
        GameEvents.EnPlay += Reanudar;
    }

    private void OnDisable()
    {
        GameEvents.EnPausa -= Pausar;
        GameEvents.EnPlay -= Reanudar;
    }

    private void Pausar()
    {
        Time.timeScale = 0;

        Debug.Log("JUEGO PAUSADO.");
    }

    private void Reanudar()
    {
        Time.timeScale = 1;

        Debug.Log("JUEGO REANUDADO.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale != 0)
            {
                GameEvents.TriggerPause();
            }
            else
            {
                GameEvents.TriggerResume();
            }
        }
    }

    public void DescontarIntento()
    {
        intentos--;

        if (intentos <= 0)
        {
            SceneManager.LoadScene(0);

            intentos = 3;
        }
    }
}
