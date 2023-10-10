using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "ScriptObj/Perfil Jugador")]

public class PerfilJugador : ScriptableObject
{
    [Header("Configuracion de vida del Jugador.")]
    [SerializeField]

    //Vidas iniciales.
    private int vidasIniciales = 5;
    public int VidasIniciales { get => vidasIniciales; set => vidasIniciales = value; }

    //Seguimiento de las vidas actuales.
    private int vidasActuales;
    public int VidasActuales { get => vidasActuales; set => vidasActuales = value; }

    //Contador de coleccionables recolectados.
    private int coleccionablesRec = 0;
    public int ColeccionablesRec { get => coleccionablesRec; set  => coleccionablesRec = value;}

    [Header("Configuracion de velocidad del Jugador.")]
    [SerializeField] 
    
    //Velocidad inicial.
    private float velocidad = 5f;

    public float Velocidad { get => velocidad; set => velocidad = value; }

    [Header("Configuracion de la fuerza del salto del Jugador.")]
    [SerializeField] 
    private float fuerzaSalto = 5f;

    public float FuerzaSalto { get => fuerzaSalto; set => fuerzaSalto = value; }

    [Header("Sonidos del Jugador.")]
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip collisionSFX;

    public AudioClip JumpSFX { get => jumpSFX; }

    public AudioClip CollisionSFX { get => collisionSFX; }
}
