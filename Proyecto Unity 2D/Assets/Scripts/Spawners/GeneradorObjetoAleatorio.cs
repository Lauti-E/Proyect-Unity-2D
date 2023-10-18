using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GeneradorObjetoAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosPrefabs;
    [SerializeField] [Range(7f, 10f)] private float tiempoEspera = 7f;
    [SerializeField] [Range(7f, 10f)] private float tiempoIntervalo = 10f;

    private int enemigosGen = 0;
    private int limEnemigos = 3;
    private float tiempoUltGen = 0f;

    private bool esVisible = false;

    void Start()
    {
        tiempoUltGen = Time.deltaTime;

        if (esVisible && enemigosGen < limEnemigos)
        {
            InvokeRepeating(nameof(GeneradorObjetoAleatorio), tiempoEspera, tiempoIntervalo);
        }
    }

    void GenerarObjetoAleatorio()
    {
        if (esVisible && enemigosGen < limEnemigos && Time.time - tiempoUltGen >= tiempoEspera)
        {
            int indexAleatorio = Random.Range(0, objetosPrefabs.Length);
            GameObject prefabAleatorio = objetosPrefabs[indexAleatorio];
            Instantiate(prefabAleatorio, transform.position, Quaternion.identity);

            enemigosGen++;
            tiempoUltGen = Time.time;

            if (enemigosGen >= limEnemigos)
            {
                CancelInvoke(nameof(GenerarObjetoAleatorio)); //Detiene la generación después de alcanzar el límite.
            }
        }
    }

    private void OnBecameInvisible()
    {
        esVisible = true;

        Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena.");
        CancelInvoke(nameof(GenerarObjetoAleatorio));
    }

    private void OnBecameVisible()
    {
        esVisible = false;

        Debug.Log("El SpriteRenderer es visible por las cámaras en la escena.");
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }
}
