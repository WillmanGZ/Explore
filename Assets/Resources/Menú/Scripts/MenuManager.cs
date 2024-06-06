using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuegoSelectorManager : MonoBehaviour
{   
    public Renderer fondo; //Selecciona un material 3D para fondo

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

    public void botonBack(){
        SceneManager.LoadScene(0);
    }

    public void SelectorHistorias() //Muestra el contenedor en caso de no estar en la escena y muestra los minijuegos de español
    {
        SceneManager.LoadScene(3);
    }

    public void MemoryGame()
    {
        SceneManager.LoadScene(7);
    }

}
