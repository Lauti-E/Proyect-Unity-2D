using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> coleccionables;
    [SerializeField] private GameObject bolsa;
    public int limiteCol = 5; //Límite de coleccionables.

    private void Awake()
    {
        coleccionables = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Coleccionable")) { return; }

        //Verificar si se alcanzó el límite de coleccionables en el inventario.
        if(coleccionables.Count < limiteCol)
        {
            GameObject nuevoColeccionable = collision.gameObject;
            nuevoColeccionable.SetActive(false);

            coleccionables.Add(nuevoColeccionable);
            nuevoColeccionable.transform.SetParent(bolsa.transform);

            Debug.Log("Fruta conseguida, ahora tienes: " + coleccionables.Count + " en tu inventario.");
        }
        else
        {
            Debug.Log("Ya alcanzaste el límite de frutas en tu inventario (" + limiteCol + ").");
        }
    }
} 
