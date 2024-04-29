using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDatos : MonoBehaviour
{
    // Dictionary to pair animals with fun facts
    private Dictionary<string, string> animalFunFacts = new Dictionary<string, string>()
    {
        { "León", "Soy el único felino que vive en manada." },
        { "Hormiga", "Puedo levantar hasta 50 veces mi propio peso." },
        { "Águila", "Tengo la vista más aguda de todas las aves." },
        { "Rinoceronte", "Mi piel es tan dura que las balas pueden rebotar en ella." },
        { "Perro", "Soy el mejor amigo del hombre." },
        { "Pez Payaso", "Soy un maestro del camuflaje y puedo cambiar de color." }
    };

    // References to UI elements
    public Text animalNameText;
    public Text funFactText;

    void Start()
    {
        InvokeRepeating("ShowRandomData", 0, 30);
    }

    void ShowRandomData()
    {
        // Generate random animal name
        string randomAnimalName = GetRandomAnimalName();

        // Get fun fact for the selected animal
        string funFact = animalFunFacts[randomAnimalName];

        // Update UI elements
        animalNameText.text = "Animal: " + randomAnimalName;
        funFactText.text = "Dato Curioso: " + funFact;
    }

    private string GetRandomAnimalName()
    {
        // Create a list of animal names (keys) from the dictionary
        List<string> animalNames = new List<string>(animalFunFacts.Keys);

        // Generate random index within the list
        int randomIndex = Random.Range(0, animalNames.Count);

        // Return the randomly selected animal name
        return animalNames[randomIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
