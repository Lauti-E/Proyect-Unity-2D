using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI vidas;

    [SerializeField]
    private string textoVidas = "Vidas: ";

    public void ActualizarVidasHUD(string nuevoTexto)
    {
        string textoCompleto = textoVidas + nuevoTexto;
        vidas.text = textoCompleto;
    }
}
