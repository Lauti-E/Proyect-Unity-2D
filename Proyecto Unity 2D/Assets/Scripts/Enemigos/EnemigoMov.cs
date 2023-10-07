using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMov : MonoBehaviour
{
    public float vel = 2.0f; //Velocidad de movimiento del enemigo.
    public float tiempDir1 = 2.0f; //Tiempo que el enemigo se moverá en la dirección 1.
    public float tiempDir2 = 2.0f; //Tiempo que el enemigo se moverá en la dirección 2.
    private bool enDir1 = true; //Indica si el enemigo se mueve en la dirección 1.

    void Start()
    {
        StartCoroutine(CambiarDireccion());
    }

    void Update()
    {
        if (enDir1)
        {
            //Moverse en la dirección 1 (arriba).
            transform.Translate(Vector2.up * vel * Time.deltaTime);
        }
        else
        {
            //Moverse en la dirección 2 (abajo).
            transform.Translate(Vector2.down * vel * Time.deltaTime);
        }
    }

    private IEnumerator CambiarDireccion()
    {
        yield return new WaitForSeconds(tiempDir1);

        //Cambiar la dirección.
        enDir1 = !enDir1;

        //Esperar antes de cambiar nuevamente la dirección.
        yield return new WaitForSeconds(tiempDir2);

        //Reiniciar la corutina para seguir cambiando entre las dos direcciones.
        StartCoroutine(CambiarDireccion());
    }
}
