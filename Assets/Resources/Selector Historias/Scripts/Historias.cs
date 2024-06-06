using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historias : MonoBehaviour
{
   public Text Titulo;
   public Slider Slider;
   public AudioSource HistoriaTL;
   public AudioSource Historia3C;
   public AudioSource HistoriaBD;
   static public String HistoriaSeleccionada = "TL";
   public GameObject SelectorOpciones;
    public GameObject Reproductor;

   private void Update() {
    switch (HistoriaSeleccionada) //Cambia el valor maximo del slider y lo adapta dependiendo de la historia seleccionada
    {
        case "TL":
        Slider.value = HistoriaTL.time;
        Slider.maxValue = HistoriaTL.clip.length;
        Titulo.text = "La tortuga y la liebre";
        break;
        case "BD":
        Slider.value = HistoriaBD.time;
        Slider.maxValue = HistoriaBD.clip.length;
        Titulo.text = "La bella durmiente";
        break;
        case "3C":
        Slider.value = Historia3C.time;
        Slider.maxValue = Historia3C.clip.length;
        Titulo.text = "Los 3 cerditos";
        break;
    }
    
   }
   public void Play(){
    switch (HistoriaSeleccionada){
        case "TL":
            if (!HistoriaTL.isPlaying)
            {
                HistoriaTL.Play();
            }
        break;

        case "BD":
            if (!HistoriaBD.isPlaying)
            {
                HistoriaBD.Play();
            }
        break;

        case "3C":
            if (!Historia3C.isPlaying)
            {
                Historia3C.Play();
            }
        break;
    }
   }
   public void Pause(){ //Pausa la reproduccion de la historia
    switch (HistoriaSeleccionada) 
    {
        case "TL":
            if (HistoriaTL.isPlaying)
            {
                HistoriaTL.Pause();
            }
        break;

        case "BD":
            if (HistoriaBD.isPlaying)
            {
            HistoriaBD.Pause(); 
            }
        break;

        case "3C":
            if (true)
            {
                Historia3C.Pause();
            }
        break;
    }
   }

   public void Stop(){ //Detiene la reproduccion de la historia
    switch (HistoriaSeleccionada) 
    {
        case "TL":
            HistoriaTL.Stop();
        break;

        case "BD":
            if (HistoriaBD.isPlaying)
            {
            HistoriaBD.Stop(); 
            }
        break;

        case "3C":
            if (true)
            {
                Historia3C.Stop();
            }
        break;
    }
   }

   public void CambiarTiempo(){ //Para que segun se mueva el slider se ajuste al tiempo
    switch (HistoriaSeleccionada)
    {
        case "TL":
        HistoriaTL.time = Slider.value;
        break;
        case "BD":
        HistoriaBD.time = Slider.value;
        break;
        case "3C":
        Historia3C.time = Slider.value;
        break;
    }
   }

   public void BackReproductor(){
    Reproductor.SetActive(false);
    SelectorOpciones.SetActive(true);
   }
}
