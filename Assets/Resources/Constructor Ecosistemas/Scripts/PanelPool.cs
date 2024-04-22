using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelPool : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) //Pa saber cuando el panel le caiga encima
    {
        if (transform.childCount == 0) // Verifica si el contenedor no tiene hijos
        {
            DragHandler.itemDragging.transform.SetParent(transform);
            DragHandler.itemDragging.transform.position = transform.position;
            DragHandler.itemDragging.GetComponent<RectTransform>().sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }
    }

    }
