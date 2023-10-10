using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjeto : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField] [Range(0.5f, 5f)] private float tiempoEspera;

    private int enemigosGen = 0;
    private int limEnemigos = 3;

    void Start()
    {
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoEspera);
    }

    void GenerarObjeto()
    {
        if(enemigosGen < limEnemigos)
        {
            Instantiate(objetoPrefab, transform.position, Quaternion.identity);

            enemigosGen++;
        }
        else
        {
            CancelInvoke(nameof(GenerarObjeto)); //Detiene la generación después de alcanzar el límite.
        }
    }
}
