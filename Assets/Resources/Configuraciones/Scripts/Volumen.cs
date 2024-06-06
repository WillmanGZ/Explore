using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public GameObject imageMute;
    public Toggle toggle;
    private AudioSource Musica;
    // Start is called before the first frame update
    void Start()
    {
        GameObject MusicObject = GameObject.Find("Musica");
        Musica = MusicObject.GetComponent<AudioSource>();
       int mute = PlayerPrefs.GetInt("musicaOn", 0);
       if (mute == 0)
       {
        Musica.mute = true;
       }

       if (!Musica.mute)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = sliderValue;
        RevisarSiEstoyMute();
    }
    public void RevisarSiEstoyMute()
    {
        if(slider.value == 0)
        {
            imageMute.SetActive(true);
        }
        else
        {
            imageMute.SetActive(false);
        }

    }

    public void Music(){
    //Donde 0 es off y 1 es on
        if (!toggle.isOn)
        {
            Musica.mute = true;
            PlayerPrefs.SetInt("musicaOn", 0);
        }
        else{
            Musica.mute = false;
            PlayerPrefs.SetInt("musicaOn", 1);
        }
        PlayerPrefs.Save();
    }
}