using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelPull : MonoBehaviour, IDropHandler
{
    public GameObject contenedor;
    public void OnDrop(PointerEventData eventData) //Cada vez que caiga un panel en este contenedor, ese panel se haga hijo de ese contenedor
    {
        if (transform.childCount == 0) // Verifica si el contenedor no tiene hijos
        {
            DragHandler.itemDragging.transform.SetParent(transform);
            DragHandler.itemDragging.transform.position = transform.position;
            DragHandler.itemDragging.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }      
    }
}
