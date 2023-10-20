using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject iconoVidaPrefab;
    [SerializeField] Transform contIconosVida;

    //Lista de corazones.
    private List<GameObject> corazones = new List<GameObject>();

    public void InicializarHUD(int vidasIniciales)
    {
        //Crear los corazones iniciales en el HUD.
        for (int i = 0; i < vidasIniciales; i++)
        {
            GameObject iconoVida = Instantiate(iconoVidaPrefab, contIconosVida);

            corazones.Add(iconoVida);
        }
    }

    public void ActualizarHUD(int vidasActuales)
    {
        //Ocultar o mostrar los corazones según las vidas actuales.
        for (int i = 0; i < corazones.Count; i++)
        {
            if (i < vidasActuales)
            {
                //Mostrar el corazón.
                corazones[i].SetActive(true);
            }
            else
            {
                //Ocultar el corazón.
                corazones[i].SetActive(false);
            }
        }
    }
}
