using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy instance;

    private void Awake()
    {
        // Verificar si ya existe una instancia
        if (instance == null)
        {
            // Mantener este objeto cuando se cambie de escena
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            // Si ya existe otra instancia, destruir este objeto
            Destroy(this.gameObject);
        }
    }
}

