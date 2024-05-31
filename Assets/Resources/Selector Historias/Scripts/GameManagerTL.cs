using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerTL : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;


    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;


    public GameObject contenedor1;
    public GameObject contenedor2;
    public GameObject contenedor3;
    public GameObject contenedor4;
    public GameObject contenedor5;
    public GameObject contenedor6;

    private List<GameObject> contenedores = new List<GameObject>();
    System.Random ramdom = new System.Random();

    public GameObject AvisoCorrecto;
    public GameObject AvisoIncorrecto;

    public GameObject Desenfoque;

    public GameObject Instrucciones;

    private int puntaje;

     // Start is called before the first frame update
    void Start()
    {
        asignarPosiciones();
        puntaje = 100;
    }
    
    public void asignarPosiciones() //Lista de los contenedores, para luego asignarle hijos aleatorios
    {
        contenedores.Add(contenedor1);
        contenedores.Add(contenedor2);
        contenedores.Add(contenedor3);
        contenedores.Add(contenedor4);
        contenedores.Add(contenedor5);
        contenedores.Add(contenedor6);
        
        List<int> numeros = new List<int> { 0, 1, 2, 3, 4, 5};
        int[] index = new int[6];
        
        for (int i = 0; i < 6; i++)
        {
            int indice = ramdom.Next(0, numeros.Count);
            index[i] = numeros[indice]; 
            numeros.RemoveAt(indice);
        }
        Transform padre1 = contenedores[index[0]].transform;
        panel1.transform.SetParent(padre1);
        panel1.transform.position = contenedores[index[0]].transform.position;
        panel1.GetComponent<RectTransform>().sizeDelta = contenedores[index[0]].GetComponent<RectTransform>().sizeDelta;

        Transform padre2 = contenedores[index[1]].transform;
        panel2.transform.SetParent(padre2);
        panel2.transform.position = contenedores[index[1]].transform.position;
        panel2.GetComponent<RectTransform>().sizeDelta = contenedores[index[1]].GetComponent<RectTransform>().sizeDelta;

        Transform padre3 = contenedores[index[2]].transform;
        panel3.transform.SetParent(padre3);
        panel3.transform.position = contenedores[index[2]].transform.position;
        panel3.GetComponent<RectTransform>().sizeDelta = contenedores[index[2]].GetComponent<RectTransform>().sizeDelta;

        Transform padre4 = contenedores[index[3]].transform;
        panel4.transform.SetParent(padre4);
        panel4.transform.position = contenedores[index[3]].transform.position;
        panel4.GetComponent<RectTransform>().sizeDelta = contenedores[index[3]].GetComponent<RectTransform>().sizeDelta;

        Transform padre5 = contenedores[index[4]].transform;
        panel5.transform.SetParent(padre5);
        panel5.transform.position = contenedores[index[4]].transform.position;
        panel5.GetComponent<RectTransform>().sizeDelta = contenedores[index[4]].GetComponent<RectTransform>().sizeDelta;

        Transform padre6 = contenedores[index[5]].transform;
        panel6.transform.SetParent(padre6);
        panel6.transform.position = contenedores[index[5]].transform.position;
        panel6.GetComponent<RectTransform>().sizeDelta = contenedores[index[5]].GetComponent<RectTransform>().sizeDelta;

    }
    public void ComprobarPosiciones(){
        if (panel1.transform.position == slot1.transform.position && panel2.transform.position == slot2.transform.position && panel3.transform.position == slot3.transform.position && panel4.transform.position == slot4.transform.position && panel5.transform.position == slot5.transform.position && panel6.transform.position == slot6.transform.position)
        {   
            StartCoroutine(Mensaje(true));
        }
        else
        {
            StartCoroutine(Mensaje(false));
        }
    }

    public void BotonSalirCorrecto(){
        SceneManager.LoadScene(3);
    }

    public void BotonBack(){
        SceneManager.LoadScene(3);
    }

    public void BotonReiniciarIncorrecto(){
        AvisoIncorrecto.SetActive(false);
        asignarPosiciones();
    }

    public void BotonInstrucciones(){
        Instrucciones.SetActive(true);
    }
    public void BotonSalirInstrucciones(){
        Instrucciones.SetActive(false);
    }

    public void BotonSalirReintentar()
    {
        asignarPosiciones();
        Desenfoque.SetActive(false);
        AvisoIncorrecto.SetActive(false);

    }

    public void RestarPuntaje(){
        if (puntaje > 50)
        {
            puntaje = puntaje - 10;
        } 
        else if (puntaje>20 && puntaje < 50)
        {
            puntaje = puntaje - 5;
        }
        else if (puntaje <=20 && puntaje > 5)
        {
            puntaje = puntaje - 3;
        }
    }

   

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Mensaje(bool Condicion)
    {
        if (Condicion)
        {
            Desenfoque.SetActive(true);
            AvisoCorrecto.SetActive(true);
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(3);
        }
        else
        {
            Desenfoque.SetActive(true);
            AvisoIncorrecto.SetActive(true);
        }
        
    }

    
}
