using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : ConfigProyectil
{
    protected override void Inicializacion()
    {
        Vector2 dir = Vector2.left;

        rbProyectil.velocity = dir * velProyectil;
    }
}
