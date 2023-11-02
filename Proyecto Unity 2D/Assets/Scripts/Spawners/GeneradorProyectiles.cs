using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProyectiles : MonoBehaviour
{
    [SerializeField] float tiempoEntreDisparos;

    [SerializeField] GameObject proyectilPrefab;
    [SerializeField] Transform puntoSpawnProyectil;

    private void Start()
    {
        //Iniciar el bucle de disparo de proyectiles.
        StartCoroutine(DispararProyectil());
    }

    IEnumerator DispararProyectil()
    {
        while (true)
        {
            //Instanciar un proyectil en el punto de spawn.
            GameObject nuevoProyectil = Instantiate(proyectilPrefab, puntoSpawnProyectil.position, Quaternion.identity);

            //Establecer la velocidad del proyectil usando el script "ConfigProyectil".

            ConfigProyectil proyectil = nuevoProyectil.GetComponent<ConfigProyectil>();
            if (proyectil != null)
            {
                proyectil.velProyectil = 10f;
            }

            //Esperar el tiempo entre disparos.
            yield return new WaitForSeconds(tiempoEntreDisparos);
        }
    }
}
