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
        InvokeRepeating("DispararProyectil", 0f, tiempoEntreDisparos);
    }

    private void DispararProyectil()
    {
        Instantiate(proyectilPrefab, puntoSpawnProyectil.position, puntoSpawnProyectil.rotation);
    }
}
