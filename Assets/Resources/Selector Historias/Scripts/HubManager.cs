using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    public GameObject TLPanel;
    public GameObject BDPanel;
    public GameObject C3Panel;
    public AudioSource Musica;
    /////////////////////////////////////////////////// OPCIONES HISTORIA
    public GameObject panelOpcionesHistorias;
    public GameObject BotonReiniciar;
    public GameObject BotonPausa;
    private String Historia;
    public AudioSource AudioTL;
    private bool TLPause = false;
    ////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        GameObject musicObject = GameObject.Find("Musica");
        Musica = musicObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void TortugaLiebreConfirmar(){
        SceneManager.LoadScene(4);
    }
    
    public void Cerditos3Confirmar(){
        SceneManager.LoadScene(5);
    }

    public void BellaDurmienteConfirmar(){
        SceneManager.LoadScene(6);
    }

    
    public void Cerditos3Icono(){
        C3Panel.SetActive(true);
    }

    public void BellaDurmienteIcono(){
        BDPanel.SetActive(true);
    }

    public void TortugaLiebreClose(){
        TLPanel.SetActive(false);
    }
    
    public void Cerditos3Close(){
        C3Panel.SetActive(false);
    }

    public void BellaDurmienteClose(){
        BDPanel.SetActive(false);
    }

    public void TortugaLiebreIcono(){
        Historia = "TL";
        panelOpcionesHistorias.SetActive(true);
    }

    public void SonidoTL(){ //Cuando opriman el boton de sonido para la historia de tortuga y liebre
        SonidoHistorias(1);
    }
    public void PauseSonido(){
        SonidoHistorias(2);
    }

    public void ReiniciarSonido(){
        SonidoHistorias(3);
    }

    private void SonidoHistorias (int Instruccion){
        if (Historia == "TL")
        {
           switch (Instruccion){

         case 1: //Click en el boton para reproducirlo
            if (!AudioTL.isPlaying) //Si el audio no se está reproduciendo lo reproducirá
            { 
             Musica.Pause();
             AudioTL.Play();
             while(AudioTL.isPlaying){
                
             }
             Musica.UnPause();
            }
         break;   

         case 2: //Click en pause
            if (AudioTL.isPlaying) //Si el audio se está reproduciendo lo pausará.
            {
                AudioTL.Pause();
                TLPause = true;
                Musica.UnPause();
            }
            
            if (TLPause) //Si está pausado lo despausa
            {
                Musica.Pause();
                AudioTL.UnPause();
                TLPause = false;
            }
         break;

         case 3: //Click en reiniciar
            if (AudioTL.isPlaying) //Si el audio se está reproduciendo lo reinicia
            {
                AudioTL.time = 0;
            }
         break;
        } 
        }
    }


    public void BotonBack(){
        SceneManager.LoadScene(1);
    }

}
