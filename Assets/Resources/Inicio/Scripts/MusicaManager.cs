using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    public static MusicaManager instance = null;
    void Awake()
    {
        // Verifica si ya existe una instancia de MusicManager
        if (instance == null)
        {
            // Si no existe, esta es la instancia única
            instance = this;
            // No destruir este objeto al cargar nuevas escenas
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            // Si ya existe una instancia, destruye este objeto duplicado
            Destroy(gameObject);
        }
    }
}
