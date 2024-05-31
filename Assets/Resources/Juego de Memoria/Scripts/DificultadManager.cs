using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DificultadManager : MonoBehaviour
{
    
    private int _rows = 2;
    private int _columns = 2;
    private int _movements = 2;
    private int _difficulty = 2;
    public Renderer fondo; //Selecciona un material 3D para fondo
    //[SerializeField] GameObject _btn;
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

    public void facil()
    {
        PlayerPrefs.SetInt("_rows", 3);
        PlayerPrefs.SetInt("_columns", 2);
        PlayerPrefs.SetInt("_movements", 6);
        PlayerPrefs.SetInt("_difficulty", 4);

        SceneManager.LoadScene(8);
    }
    public void Media()
    {
        PlayerPrefs.SetInt("_rows", 4);
        PlayerPrefs.SetInt("_columns", 4);
        PlayerPrefs.SetInt("_movements", 18);
        PlayerPrefs.SetInt("_difficulty", 12);

        SceneManager.LoadScene(8);
    }

    public void dificil()
    {
        PlayerPrefs.SetInt("_rows", 4);
        PlayerPrefs.SetInt("_columns", 6);
        PlayerPrefs.SetInt("_movements", 25);
        PlayerPrefs.SetInt("_difficulty", 17);

        SceneManager.LoadScene(8);
    }

    public void back()
    {
        SceneManager.LoadScene(1);
    }
}
