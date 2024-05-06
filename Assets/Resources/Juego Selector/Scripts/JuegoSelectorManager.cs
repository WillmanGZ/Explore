using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuegoSelectorManager : MonoBehaviour
{   
    public Renderer fondo; //Selecciona un material 3D para fondo
    public AudioSource musica;
     public Sprite boton_musica_off;//Sprite del boton musica apagado
    public Sprite boton_musica_on;//Sprite del boton musica encendio
    public Image boton_musica;//Selector del objeto boton musica
    // Start is called before the first frame update

    void Awake()
    {
        GameObject musica_anterior = GameObject.Find("Musica Menu");

        if (musica_anterior != null){
            musica = musica_anterior.GetComponent<AudioSource>();
            Destroy(musica_anterior);
        }

    }
    void Start()
    {

        if (musica != null)
        {
            // Establecer el sprite del botón según el estado de mute
            ActualizarEstadoMusica();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        //Hace que el objeto 3D se mueva 0.02f unidades en el eje X por segundo
       fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f,0)* Time.deltaTime; 
    }
    private void ActualizarEstadoMusica()
    {
        if (musica.mute)
        {
            boton_musica.sprite = boton_musica_off;
        }
        else
        {
            boton_musica.sprite = boton_musica_on;
        }
    }

    public void BotonMusica()
    {
        if (musica != null)
        {
            // Cambiar el estado de mute y actualizar el sprite del botón
            musica.mute = !musica.mute;
            ActualizarEstadoMusica();
        }
    }
    public void botonBack(){
        SceneManager.LoadScene(0);
    }
    public void SelectorHistorias() //Muestra el contenedor en caso de no estar en la escena y muestra los minijuegos de español
    {
        SceneManager.LoadScene(2);
    }

}
