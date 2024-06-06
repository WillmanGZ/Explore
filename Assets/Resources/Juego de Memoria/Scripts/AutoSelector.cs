using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsignarSpriteAleatorio : MonoBehaviour
{public Sprite spriteRojo; // Sprite rojo
    public Sprite spriteAzul; // Sprite azul
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer del objeto

    private static int contadorRojos = 0; // Contador estático para la cantidad de sprites rojos
    private static int contadorAzules = 0; // Contador estático para la cantidad de sprites azules

    void Start()
    {
        // Obtener el componente SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Determinar cuántos de cada tipo hay en total
        int totalContador = contadorRojos + contadorAzules;

        // Probabilidad ajustada en función del balance actual
        float probabilidadRojo = (totalContador > 0) ? (float)contadorAzules / totalContador : 0.5f;
        float randomValue = Random.value;

        // Seleccionar el sprite basado en la probabilidad ajustada
        if (randomValue < probabilidadRojo)
        {
            // Asignar el sprite rojo al objeto
            spriteRenderer.sprite = spriteRojo;
            contadorRojos++;
        }
        else
        {
            // Asignar el sprite azul al objeto
            spriteRenderer.sprite = spriteAzul;
            contadorAzules++;
        }
    }
}
