using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private Color nocheColor;

    [SerializeField][Range(4, 128)] private int duracionDia;
    [SerializeField][Range(4, 24)] private int dias;

    private Color diaColor;

    void Start()
    {
        diaColor = camara.backgroundColor;
        StartCoroutine(CambiarColor(duracionDia));
    }

    IEnumerator CambiarColor(float tiempo)
    {
        Color colorDestino = camara.backgroundColor == diaColor ? nocheColor : diaColor;
        float duracionCiclo = tiempo * 0.6f;
        float duracionCambio = tiempo * 0.8f;

        for(int i = 0; i < dias; i++)
        {
            yield return new WaitForSeconds(tiempo);

            float tiempoTransc = 0;

            while (tiempoTransc < duracionCambio)
            {
                tiempoTransc += Time.deltaTime;
                float t = tiempoTransc / duracionCambio;

                float smoothT = Mathf.SmoothStep(0f, 1f, t);
                camara.backgroundColor = Color.Lerp(camara.backgroundColor, colorDestino, smoothT);
                yield return null;
            }

            colorDestino = camara.backgroundColor == diaColor ? nocheColor : diaColor;

        }
    }
}
