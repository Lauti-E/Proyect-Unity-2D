using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField] [Range(0.5f, 5f)] private float tiempoEspera;
    [SerializeField] [Range(0.5f, 5f)] private float tiempoIntervalo;

    private int enemigosGen = 0;
    private int limEnemigos = 3;

    void Start()
    {
        InvokeRepeating(nameof(GeneradorObjetoLoop), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjetoLoop()
    {
        if (enemigosGen < limEnemigos)
        {
            Instantiate(objetoPrefab, transform.position, Quaternion.identity);

            enemigosGen++;
        }
        else
        {
            CancelInvoke(nameof(GenerarObjetoLoop)); //Detiene la generación después de alcanzar el límite.
        }
    }

}
