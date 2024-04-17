using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
