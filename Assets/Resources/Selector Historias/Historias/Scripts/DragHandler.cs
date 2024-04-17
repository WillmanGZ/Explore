using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public static GameObject itemDragging; //Se asigna cada que se haga drag, mientras que no haya drag, la variable será null

    Vector3 startPosition; //Posicion inicial del panel
    public static Transform startParent; //Posicion del parent
    Transform dragParent; //Cada vez que se haga drag, el panel se coloca dentro del panel

    // Start is called before the first frame update
    void Start()
    {
        dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
    }

    public void OnBeginDrag(PointerEventData eventData) //Se llama solo una vez, al empezar el drag
    {
        itemDragging = gameObject;
        startPosition = transform.position; //Coje la posicion del objeto al que está asignado el script
        startParent = transform.parent; //Coje el parent del objeto al que está asignado el script
        transform.SetParent(dragParent);
    }

    public void OnDrag(PointerEventData eventData) //Se llama varias veces mientras se hace el drag
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) //Se llama solo una vez, cuando termine el drag
    {
        itemDragging = null;
        if (transform.parent == dragParent) 
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

}
