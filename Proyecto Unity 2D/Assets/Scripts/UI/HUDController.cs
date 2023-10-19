using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contIconosVida;

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        Debug.Log("SE LLAMA: " + nuevoTexto);

        miTexto.text = nuevoTexto;
    }

    public void ActualizarVidasHUD(int vidas)
    {
        Debug.Log("ESTAS ACTUALIZANDO VIDAS.");

        if (ContenedorVacio())
        {
            CargarContenedor(vidas);
            return;
        }

        if(CantidadIconosVidas() > vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
    }

    private bool ContenedorVacio()
    {
        return contIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas()
    {
        return contIconosVida.transform.childCount;
    }

    private void CargarContenedor(int cantidadIconos)
    {
        for(int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contIconosVida.transform);
    }

    private void EliminarUltimoIcono()
    {
        Transform cont = contIconosVida.transform;

        GameObject.Destroy(cont.GetChild(cont.childCount - 1).gameObject);
    }
}
