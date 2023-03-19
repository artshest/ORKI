using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InteractableItem : Interactable
{

    public void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 0;
    }

    public override void OnHoverEnter()
    {
        outline.OutlineWidth = 2;
    }
    
    public override void OnHoverExit()
    {
        outline.OutlineWidth = 0;
    }
}
