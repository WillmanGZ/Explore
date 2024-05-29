using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void TortugaLiebre(){
        SceneManager.LoadScene(4);
    }
    
    public void Cerditos3(){
        SceneManager.LoadScene(5);
    }

    public void BellaDurmiente(){
        SceneManager.LoadScene(6);
    }

    public void BotonBack(){
        SceneManager.LoadScene(1);
    }

}
