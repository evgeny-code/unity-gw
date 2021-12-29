using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class LongClickButton : MonoBehaviour,  IPointerDownHandler, IPointerUpHandler
{
    protected abstract void ClickAction();

    private bool _pressing;

    // Update is called once per frame
    void Update()
    {
        if (_pressing)
        {
            ClickAction();
        }
    }

    
    public void OnPointerDown(PointerEventData eventData)
    {
        _pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressing = false;
    }
}
