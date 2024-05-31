using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCompleta : MonoBehaviour
{
    public Toggle toggle;
    public Dropdown resolucionesDropDown;
    Resolution[] resoluciones;

    void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }

        RevisarResolucion();
    }

    void Update()
    {

    }

    public void ActiveFULLS(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
{
    resolucionesDropDown.ClearOptions();

    List<string> opciones = new List<string>();

    opciones.Add("1920 x 1080");
    opciones.Add("1280 x 720");
    opciones.Add("950 x 540");

    // Establecer la resolución actual en función de PlayerPrefs
    int resolucionActual = PlayerPrefs.GetInt("numeroResolucion", 1);

    resolucionesDropDown.AddOptions(opciones);
    resolucionesDropDown.value = resolucionActual;
    resolucionesDropDown.RefreshShownValue();
}



    public void CambiarResolucion(int indiceResolucion)
{
    PlayerPrefs.SetInt("numeroResolucion", indiceResolucion);

    Resolution[] resoluciones = Screen.resolutions;
    Resolution resolution;

    switch (indiceResolucion)
    {
        case 0: 
            resolution = new Resolution { width = 1920, height = 1080 };
            break;
        case 1: 
            resolution = new Resolution { width = 1280, height = 720 };
            break;
        case 2: 
            resolution = new Resolution { width = 950, height = 540 };
            break;
        default:
            resolution = resoluciones[indiceResolucion];
            break;
    }

    Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
}

}