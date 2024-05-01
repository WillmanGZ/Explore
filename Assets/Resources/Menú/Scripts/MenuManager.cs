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

    void Awake()
    {
        GameObject musica_anterior = GameObject.Find("Musica Menu1");

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

    void DestroyObjectByName(string nombreObjeto)
    {
        GameObject objetoBuscado = GameObject.Find(nombreObjeto);

        if (objetoBuscado != null)
        {
            // El objeto fue encontrado, destruirlo
            Destroy(objetoBuscado);
        }
        else
        {
            // El objeto no fue encontrado
            Debug.LogWarning("El objeto con nombre '" + nombreObjeto + "' no se encontró en la escena.");
        }
    }
}
