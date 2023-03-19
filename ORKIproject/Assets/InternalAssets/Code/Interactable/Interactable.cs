using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Outline))]
public abstract class Interactable : MonoBehaviour
{
    public float interactRadius = 7f;
    protected Outline outline;
    
    
    public virtual void OnHoverEnter() //При наведении мыши на объект
    {
        //Нужен для перегрузки
    }
    public virtual void OnHoverExit() //При отводе мыши от объекта
    {
        //Нужен для перегрузки
    }

    /*private void OnMouseEnter()
    {
        this.OnHoverEnter();
        Debug.Log("Навелся");
    }

    private void OnMouseExit()
    {
        this.OnHoverExit();
        Debug.Log("Увелся");
    }*/
}
