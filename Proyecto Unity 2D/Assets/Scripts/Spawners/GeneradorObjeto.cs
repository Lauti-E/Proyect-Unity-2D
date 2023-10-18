using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjeto : MonoBehaviour
{
    public GameObject[] enemigoPrefabs; //Arreglo que contiene los prefabs.

    private bool generado = false;

    private int enemigosGen = 0; //Contador de enemigos generados.
    public float tiempoEspera = 5f; //Tiempo de espera en segundos.

    private void OnBecameVisible()
    {
        if (!generado && Camera.main.CompareTag("MainCamera"))
        {
            //Iniciar el bucle de generaci�n de enemigos cada 5 segundos.
            InvokeRepeating("GenerarEnemigo", 0f, tiempoEspera);
          
            generado = true;
        }
    }

    private void GenerarEnemigo()
    {
        if (enemigosGen < 3 && enemigoPrefabs.Length > 0)
        {
            //Seleccionar un �ndice aleatorio para el arreglo de prefabs.
            int indiceAleatorio = Random.Range(0, enemigoPrefabs.Length);

            //Genera el enemigo en la posici�n del generador.
            GameObject nuevoEnemigo = Instantiate(enemigoPrefabs[indiceAleatorio], transform.position, Quaternion.identity);

            //Incrementar el contador de enemigos generados.
            enemigosGen++;
        }
    }
}
