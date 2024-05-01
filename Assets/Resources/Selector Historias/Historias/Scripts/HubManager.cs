using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    public AudioSource musica;
     public Sprite boton_musica_off;//Sprite del boton musica apagado
    public Sprite boton_musica_on;//Sprite del boton musica encendio
    public Image boton_musica;//Selector del objeto boton musica
    void Awake()
    {
    DestroyObjectByName("Musica Menu");
    }
    
    // Start is called before the first frame update
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
    public void TortugaLiebre(){
        SceneManager.LoadScene(3);
    }
    
    public void Cerditos3(){
        SceneManager.LoadScene(4);
    }

    public void BellaDurmiente(){
        SceneManager.LoadScene(5);
    }

    public void BotonBack(){
        SceneManager.LoadScene(1);
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
}
