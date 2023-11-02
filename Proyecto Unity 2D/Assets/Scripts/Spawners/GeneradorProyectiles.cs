using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorProyectiles : MonoBehaviour
{
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] int poolSize = 1;

    [SerializeField] GameObject proyectilPrefab;
    [SerializeField] Transform puntoSpawnProyectil;

    private List<GameObject> proyectilPool = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject proyectil = Instantiate(proyectilPrefab, puntoSpawnProyectil.position, Quaternion.identity);

            //Desactiva el proyectil en la pool.
            proyectil.SetActive(false);
            proyectilPool.Add(proyectil);
        }

        //Iniciar el bucle de disparo de proyectiles.
        StartCoroutine(DispararProyectil());
    }

    IEnumerator DispararProyectil()
    {
        while (true)
        {
            //Busca un proyectil inactivo en la pool.
            GameObject proyectil = proyectilPool.Find(p => !p.activeSelf);

            if (proyectil != null)
            {
                proyectil.transform.position = puntoSpawnProyectil.position;

                ConfigProyectil proyectilConfig = proyectil.GetComponent<ConfigProyectil>();

                if (proyectilConfig != null)
                {
                    //Establece la velocidad del proyectil.
                    proyectilConfig.velProyectil = 10f;
                }
                proyectil.SetActive(true);
            }
            //Esperar el tiempo entre disparos.
            yield return new WaitForSeconds(tiempoEntreDisparos);
        }
    }
}
