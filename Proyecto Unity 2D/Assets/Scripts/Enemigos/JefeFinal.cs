using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JefeFinal : MonoBehaviour
{
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] float tiempoEntreEmbestidas;
    [SerializeField] float tiempoEntreMovimientos;

    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoSpawnProyectil;

    private float tiempoActEspera;
    private int estadoActual;

    //Estados del jefe.
    private const int DispararProyectil = 0;
    private const int Embestir = 1;
    private const int Mover = 2;

    void Start()
    {
        estadoActual = DispararProyectil;
        StartCoroutine(ComportamientoJefe());
    }

    private IEnumerator ComportamientoJefe()
    {
        while (true)
        {
            switch (estadoActual)
            {
                case DispararProyectil:
                    StartCoroutine(Disparar());
                    tiempoActEspera = tiempoEntreDisparos;
                    break;
                case Embestir:
                    StartCoroutine(Embestida());
                    tiempoActEspera = tiempoEntreEmbestidas;
                    break;
                case Mover:
                    StartCoroutine(Movimiento());
                    tiempoActEspera = tiempoEntreMovimientos;
                    break;
            }
            Debug.Log(estadoActual);
            yield return new WaitForSeconds(tiempoActEspera);
            
            ActualizarEstado();
        }
    }

    private IEnumerator Disparar()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(prefabProyectil, puntoSpawnProyectil.position, Quaternion.identity);
        }
    }

    private IEnumerator Embestida()
    {
        float tiempoEmbestida = 2f;
        float tiempoInicio = Time.time;
        float velEmbestida = -10;

        Vector2 posInicial = transform.position;
        Vector2 posObjetivo = new Vector2(transform.position.x + velEmbestida, transform.position.y);

        //Mover hacia adelante.
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posInicial, posObjetivo, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));

            yield return null;
        }

        //Mover hacia atrás.
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posObjetivo, posInicial, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));

            yield return null;
        }
    }

    private IEnumerator Movimiento()
    {
        float tiempoMovimiento = 3f;
        float tiempoInicio = Time.time;
        float velMovimiento = 6f;

        Vector2 posInicial = transform.position;
        Vector2 posObjetivo = new Vector2(transform.position.x, transform.position.y + velMovimiento);

        //Mover hacia la posición objetivo.
        while (Time.time < tiempoInicio + tiempoMovimiento / 2)
        {
            transform.position = Vector2.Lerp(posInicial, posObjetivo, (Time.time - tiempoInicio) / (tiempoMovimiento / 2));

            yield return null;
        }

        //Mover hacia la posición inicial.
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoMovimiento / 2)
        {
            transform.position = Vector2.Lerp(posObjetivo, posInicial, (Time.time - tiempoInicio) / (tiempoMovimiento / 2));

            yield return null;
        }
    }

    private void ActualizarEstado()
    {
        //Actualizar estado según probabilidades.
        estadoActual = Random.Range(0, 3);
    }
}
