using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "ScriptObj/Perfil Jugador")]

public class PerfilJugador : ScriptableObject
{
    [Header("Configuraciones de atributos del Jugador.")]
   
    [SerializeField]
    private int vidasIniciales = 5; //Vidas iniciales.

    public int VidasIniciales {  get => vidasIniciales; set => vidasIniciales = value; }

    [Header("Configuraciones de movimiento del Jugador.")]

    [SerializeField]
    float velocidad = 5f; //Velocidad inicial.

    public float Velocidad { get => velocidad; set => velocidad = value; }

    [SerializeField]
    private float fuerzaSalto = 5f; //Fuerza del salto.

    public float FuerzaSalto {  get => fuerzaSalto; set => fuerzaSalto = value;}

    [Header("Configuraciones SFX del Jugador.")] //Sonidos del jugador.
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip collisionSFX;

    public AudioClip JumpSFX {  get => jumpSFX; }

    public AudioClip CollisionSFX { get => collisionSFX; }
}
