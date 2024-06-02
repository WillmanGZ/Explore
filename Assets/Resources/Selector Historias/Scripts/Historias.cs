using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historias : MonoBehaviour
{
   public Slider Slider;
   public AudioSource HistoriaTL;
   public AudioSource Historia3C;
   public AudioSource HistoriaBD;
   private String HistoriaSeleccionada;

   public void Play(){

   }
   public void Pause(){ //Pausa la reproduccion de la historia

   }

   public void Stop(){ //Detiene la reproduccion de la historia

   }

   private void Update() {
    switch (HistoriaSeleccionada)
    {
        case "TL":
        Slider.value = HistoriaTL.time;
        break;
        case "BD":
        Slider.value = HistoriaTL.time;
        break;
        case "3C":
        Slider.value = HistoriaTL.time;
        break;
    }
   }

}
