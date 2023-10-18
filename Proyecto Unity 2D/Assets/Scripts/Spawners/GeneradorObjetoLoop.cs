using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField] [Range(7f, 10f)] private float tiempoEspera = 7f;
    [SerializeField] [Range(7f, 10f)] private float tiempoIntervalo = 10f;

    private int enemigosGen = 0;
    private int limEnemigos = 3;
    private float tiempoUltGen = 0f;

    private bool esVisible = false;


    void Start()
    {
        tiempoUltGen = Time.time;

        if (esVisible && enemigosGen < limEnemigos)
        {
            InvokeRepeating(nameof(GeneradorObjetoLoop), tiempoEspera, tiempoIntervalo);
        }
    }

    void GenerarObjetoLoop()
    {
        if (esVisible && enemigosGen < limEnemigos && Time.time - tiempoUltGen >= tiempoEspera)
        {
            Instantiate(objetoPrefab, transform.position, Quaternion.identity);

            enemigosGen++;
            tiempoUltGen = Time.time;

            if (enemigosGen >= limEnemigos)
            {
                CancelInvoke(nameof(GenerarObjetoLoop)); //Detiene la generación después de alcanzar el límite.
            }
        }
    }

    private void OnBecameVisible()
    {
        esVisible = true;

        if (enemigosGen < limEnemigos)
        {
            InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
        }
    }

    private void OnBecameInvisible()
    {
        esVisible = false;
    }
}
