using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjeto : MonoBehaviour
{
    public GameObject enemigoPrefab;

    private bool generado = false;

    private void OnBecameVisible()
    {
        if (!generado && Camera.main.CompareTag("MainCamera"))
        {
            //Iniciar el bucle de generación de enemigos cada 5 segundos.
            InvokeRepeating("GenerarEnemigo", 0f, 5f);

            GenerarEnemigo();
        }
    }

    private void GenerarEnemigo()
    {
        //Genera el enemigo en la posición del generador.
        GameObject nuevoEnemigo = Instantiate(enemigoPrefab, transform.position, Quaternion.identity);

        generado = true;
    }
}
