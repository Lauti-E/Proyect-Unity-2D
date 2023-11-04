using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConfigProyectil : MonoBehaviour
{
    public float velProyectil = 10f; //Velocidad de los proyectiles.

    protected Rigidbody2D rbProyectil;

    private void Awake()
    {
        rbProyectil = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Inicializacion();
    }

    protected abstract void Inicializacion();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            //Desactivar el proyectil al colisionar con el suelo.
            if (gameObject.CompareTag("Proyectil"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
