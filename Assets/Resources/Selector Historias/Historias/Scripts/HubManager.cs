using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUB : MonoBehaviour
{
    void Awake()
    {
    DestroyObjectByName("Musica Menu");
    }
    
    // Start is called before the first frame update
    void Start()
    {

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
}
