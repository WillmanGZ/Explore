using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Renderer fondo; //Selecciona un material 3D para fondo
    public AudioSource musica; //Selecciona una fuente de audio, como un archivo .mp3
    public Sprite boton_musica_off;//Sprite del boton musica apagado
    public Sprite boton_musica_on;//Sprite del boton musica encendio
    public Image boton_musica;//Selector del objeto boton musica
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Hace que el objeto 3D se mueva 0.02f unidades en el eje X por segundo
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f,0)* Time.deltaTime;
    }

    public void BotonJugar() //Nos dirije a la escena JuegoSelector
    {
        SceneManager.LoadScene(1);
    }

    public void BotonCreditos() //Muestra los creditos
    {
       Debug.Log("Creditos"); 
    }

    public void BotonSalir() //Hace que se cierre la aplicacion. (Dentro del editor no se ejecuta el QUIT, solamente cuando el juego esté corriendo)
    {
        Debug.Log("Salir");
        Application.Quit();

        
    }

    public void BotonMusica() //Prende o apaga la musica, cambiando sus sprites entre muted y on
    {
        if (musica !=null)
        {
            if(musica.mute == false)
            {
                boton_musica.sprite = boton_musica_off;
                musica.mute = true;
            } 
            else if(musica.mute == true)
            {
                boton_musica.sprite = boton_musica_on;
                musica.mute = false;
            }
            
        }
    }
}
