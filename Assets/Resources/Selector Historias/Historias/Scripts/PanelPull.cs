using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelPull : MonoBehaviour, IDropHandler
{
    public GameObject contenedor;
    public void OnDrop(PointerEventData eventData) //Cada vez que caiga un panel en este contenedor, ese panel se haga hijo de ese contenedor
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
            currentChild.GetComponent<RectTransform>().sizeDelta = startParent.GetComponent<RectTransform>().sizeDelta;
        }      
    }
}
