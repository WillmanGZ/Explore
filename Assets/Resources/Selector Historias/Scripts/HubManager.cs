using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    public GameObject SelectorOpciones;
    public GameObject Reproductor;
    public Text tituloOpciones;

    private void Update() {
      switch (Historias.HistoriaSeleccionada) //Cambia el valor maximo del slider y lo adapta dependiendo de la historia seleccionada
    {
        case "TL":
        tituloOpciones.text = "La tortuga y la liebre";
        break;
        case "BD":
        tituloOpciones.text = "La bella durmiente";
        break;
        case "3C":
        tituloOpciones.text = "Los 3 cerditos";
        break;
    }  
    }
    public void TLIcon(){
        Historias.HistoriaSeleccionada = "TL";
        SelectorOpciones.SetActive(true);
    }

    public void BDIcon(){
        Historias.HistoriaSeleccionada = "BD";
        SelectorOpciones.SetActive(true);
    }

    public void C3Icon(){
        Historias.HistoriaSeleccionada = "3C";
        SelectorOpciones.SetActive(true);
    }

    public void BotonBack(){
        SceneManager.LoadScene(1);
    }

    //Parte del SelectorOpciones
    public void BotonBackOpciones(){
        SelectorOpciones.SetActive(false);
    }

    public void MostrarReproductor(){
        SelectorOpciones.SetActive(false);
        Reproductor.SetActive(true);
    }
}
