using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfiguracionesManager : MonoBehaviour
{
    public GameObject panelConfigs;
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

    public void ExitCongifuraciones() //Está en la escena de configuraciones
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    
}
