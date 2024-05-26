using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DificultuController : MonoBehaviour
{
    
            private int _rows = 2;
    private int _columns = 2;
    private int _movements = 2;
    private int _difficulty = 2;
    //[SerializeField] GameObject _btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void facil()
    {
        PlayerPrefs.SetInt("_rows", 3);
        PlayerPrefs.SetInt("_columns", 2);
        PlayerPrefs.SetInt("_movements", 8);
        PlayerPrefs.SetInt("_difficulty", 4);

        SceneManager.LoadScene("JuegoMemoria");
    }
    public void Media()
    {
        PlayerPrefs.SetInt("_rows", 4);
        PlayerPrefs.SetInt("_columns", 4);
        PlayerPrefs.SetInt("_movements", 17);
        PlayerPrefs.SetInt("_difficulty", 15);

        SceneManager.LoadScene("JuegoMemoria");
    }

    public void dificil()
    {
        PlayerPrefs.SetInt("_rows", 4);
        PlayerPrefs.SetInt("_columns", 6);
        PlayerPrefs.SetInt("_movements", 20);
        PlayerPrefs.SetInt("_difficulty", 20);

        SceneManager.LoadScene("JuegoMemoria");
    }
}
