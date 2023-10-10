using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GeneradorObjetoAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosPrefabs;
    [SerializeField][Range(0.5f, 5f)] private float tiempoEspera;
    [SerializeField][Range(0.5f, 5f)] private float tiempoIntervalo;

    private int enemigosGen = 0;
    private int limEnemigos = 3;

    void Start()
    {
        InvokeRepeating(nameof(GeneradorObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoAleatorio()
    {
        if(enemigosGen < limEnemigos)
        {
            int indexAleatorio = Random.Range(0, objetosPrefabs.Length);
            GameObject prefabAleatorio = objetosPrefabs[indexAleatorio];
            Instantiate(prefabAleatorio, transform.position, Quaternion.identity);

            enemigosGen++;
        }
        else
        {
            CancelInvoke(nameof(GenerarObjetoAleatorio)); //Detiene la generación después de alcanzar el límite.
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena.");
        CancelInvoke(nameof(GenerarObjetoAleatorio));
    }

    private void OnBecameVisible()
    {
        Debug.Log("El SpriteRenderer es visible por las cámaras en la escena.");
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoEspera, tiempoIntervalo);
    }
}
