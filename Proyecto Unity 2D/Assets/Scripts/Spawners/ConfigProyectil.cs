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

        //Asignar velocidad inical al proyectil.
        rbProyectil.velocity = transform.right * velProyectil;
    }
}
