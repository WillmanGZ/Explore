using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUB : MonoBehaviour
{
    public GameObject TLPanel;
    public GameObject BDPanel;
    public GameObject C3Panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void TortugaLiebreConfirmar(){
        SceneManager.LoadScene(4);
    }
    
    public void Cerditos3Confirmar(){
        SceneManager.LoadScene(5);
    }

    public void BellaDurmienteConfirmar(){
        SceneManager.LoadScene(6);
    }

    public void TortugaLiebreIcono(){
        TLPanel.SetActive(true);
    }
    
    public void Cerditos3Icono(){
        C3Panel.SetActive(true);
    }

    public void BellaDurmienteIcono(){
        BDPanel.SetActive(true);
    }

    public void TortugaLiebreClose(){
        TLPanel.SetActive(false);
    }
    
    public void Cerditos3Close(){
        C3Panel.SetActive(false);
    }

    public void BellaDurmienteClose(){
        BDPanel.SetActive(false);
    }

    public void BotonBack(){
        SceneManager.LoadScene(1);
    }

}
