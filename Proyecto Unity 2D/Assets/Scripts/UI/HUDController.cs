using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text textoVidas;
    [SerializeField] private Jugador jugador;

    private void Start()
    {
        if (jugador == null)
        {
            Debug.LogError("El jugador no est� asignado en el Inspector.");
        }
    }

    private void Update()
    {
        textoVidas.text = "Vidas: " + j
    }
}
