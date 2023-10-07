using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Curar : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] int puntos = 1;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.ModificarVida(puntos);
            UnityEngine.Debug.Log("PUNTOS DE VIDA DEL JUGADOR: " + puntos);
        }
    }
}
