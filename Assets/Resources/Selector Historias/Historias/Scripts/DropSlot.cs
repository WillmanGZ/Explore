using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPanel : MonoBehaviour, IDropHandler
{
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData) //Pa saber cuando el panel le caiga encima
    {
        
        // Obtener el objeto arrastrado
        GameObject itemDragging = DragHandler.itemDragging;

        // Si no hay un objeto arrastrado, salir del método
        if (!itemDragging)
            return;

        // Si el contenedor está vacío, asignar el objeto arrastrado como hijo
        if (transform.childCount == 0)
        {
            itemDragging.transform.SetParent(transform);
            itemDragging.transform.position = transform.position;
            itemDragging.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }
        else // Si el contenedor no está vacío, intercambiar los padres de los objetos
        {
            // Obtener el primer hijo del contenedor
            GameObject currentChild = transform.GetChild(0).gameObject;

            // Intercambiar los padres de los objetos arrastrado y el hijo actual del contenedor
            Transform startParent = DragHandler.startParent;
            Transform currentChildParent = currentChild.transform.parent;

            itemDragging.transform.SetParent(currentChildParent);
            itemDragging.transform.position = currentChildParent.position;
            itemDragging.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;

            currentChild.transform.SetParent(startParent);
            currentChild.transform.position = startParent.position;
            currentChild.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }
    }





    // Update is called once per frame
    void Update()
    {
        if (panel !=null && panel.transform.parent != transform) //Si el panel no es null y se esté haciendo un drag
        {
            panel = null;
        }
    }
}
