using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI vidas;

    [SerializeField]
    private TextMeshProUGUI textoPausa;

    [SerializeField]
    private string textoVidas = "Vidas: ";

    [SerializeField]
    GameObject menuConfig;

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

        menuConfig.SetActive(true);
    }

    private void Reanudar()
    {
        Time.timeScale = 1;

        menuConfig.SetActive(false);
    }

    public void ActualizarVidasHUD(string nuevoTexto)
    {
        string textoCompleto = textoVidas + nuevoTexto;
        vidas.text = textoCompleto;
    }

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        textoPausa.text = nuevoTexto;
    }
}
