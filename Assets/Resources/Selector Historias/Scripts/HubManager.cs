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
    public GameObject TextoTL;
    public GameObject TextoBD;
    public GameObject Texto3C;

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

    public void MostrarLectura(){
        switch(Historias.HistoriaSeleccionada){
            case "TL":
                SelectorOpciones.SetActive(false);
                TextoTL.SetActive(true);
            break;

            case "BD":
                SelectorOpciones.SetActive(false);
                TextoBD.SetActive(true);
            break;

            case "3C":
                SelectorOpciones.SetActive(false);
                Texto3C.SetActive(true);
            break;
        }
    }

    //Leer historias
    public void salirLeer(){
        switch(Historias.HistoriaSeleccionada){
            case "TL":
                TextoTL.SetActive(false);
                SelectorOpciones.SetActive(true);
            break;

            case "BD":
                TextoBD.SetActive(false);
                SelectorOpciones.SetActive(true);
            break;

            case "3C":
                Texto3C.SetActive(false);
                SelectorOpciones.SetActive(true);
            break;
        }
    }

    public void ConfirmarBoton(){
        switch(Historias.HistoriaSeleccionada){
            case "TL":
                SceneManager.LoadScene(4);
            break;

            case "BD":
                SceneManager.LoadScene(6);
            break;

            case "3C":
                SceneManager.LoadScene(5);;
            break;
        }
    }
}
