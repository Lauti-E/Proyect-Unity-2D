using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> coleccionables;
    [SerializeField] private GameObject bolsa;
    public int limiteCol = 5; //L�mite de coleccionables.
    
    private Jugador jugador; //Referencia al script del jugador.

    private bool ganaste = false;

    private void Awake()
    {
        coleccionables = new List<GameObject>();
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Coleccionable")) { return; }

        //Verificar si se alcanz� el l�mite de coleccionables en el inventario.
        if(coleccionables.Count < limiteCol)
        {
            GameObject nuevoColeccionable = collision.gameObject;
            nuevoColeccionable.SetActive(false);

            coleccionables.Add(nuevoColeccionable);
            nuevoColeccionable.transform.SetParent(bolsa.transform);

            //Informar al jugador que recolect� un coleccionable (Fruta).
            Debug.Log("Fruta conseguida, ahora tienes: " + coleccionables.Count + " en tu inventario.");

            if(coleccionables.Count == 5) 
            {
                ganaste = true;
                Debug.Log("5 Frutas conseguidas, puedes llegar a la meta!");
            }
        }
        else
        {
            //Muestra un mensaje en la consola indicando que se alcanz� el l�mite.
            Debug.Log("Ya alcanzaste el l�mite de frutas en tu inventario (" + limiteCol + ").");
        }
    }
} 
