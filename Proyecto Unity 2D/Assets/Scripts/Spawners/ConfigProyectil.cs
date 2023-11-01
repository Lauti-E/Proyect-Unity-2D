using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigProyectil : MonoBehaviour
{

    public float velProyectil = 10f; //Velocidad de los proyectiles.

    void Start()
    {
        //Obtener el Rigidbody2D del proyectil.
        Rigidbody2D rbProyectil = GetComponent<Rigidbody2D>();

        //Asignar velocidad inicial al proyectil.
        rbProyectil.velocity = new Vector2(0, -velProyectil);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            //Destruir el proyectil al colisionar con el suelo.
            if (gameObject.CompareTag("Proyectil"))
            {
                Destroy(gameObject);
            }
        }
    }
}
