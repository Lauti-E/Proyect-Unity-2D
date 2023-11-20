using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;
    [SerializeField] private TMP_InputField myInput;

    private void Start()
    {
        //Asignar valores iniciales.
        //Barra de volumen.
        mySlider.value = PersistenceManager.Instance.GetFloat("MusicVolumem");

        //Casilla de marca de voluemn ON/OFF.
        myToggle.isOn = PersistenceManager.Instance.GetBool("Music");

        //Caja de texto para el nombre.
        myInput.text = PersistenceManager.Instance.GetString("Username");
    }
}
