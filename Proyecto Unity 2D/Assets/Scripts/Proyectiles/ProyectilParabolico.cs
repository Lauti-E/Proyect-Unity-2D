using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilParabolico : ConfigProyectil
{
    [SerializeField]
    [Range(0f, 90f)]
    private float angulo = 45f;

    protected override void Inicializacion()
    {
        float anguloRadianes = (angulo - 90f) * Mathf.Deg2Rad;

        Vector2 velDisparo = new Vector2(-Mathf.Cos(anguloRadianes) * velProyectil, Mathf.Sin(anguloRadianes) * velProyectil);

        rbProyectil.velocity = velDisparo;
    }
}
