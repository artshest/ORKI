using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEnemy : Interactable
{
    public void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineColor = Color.red;
        outline.OutlineWidth = 0;
    }

    public override void OnHoverEnter()
    {
        outline.OutlineWidth = 4;
    }
    
    public override void OnHoverExit()
    {
        outline.OutlineWidth = 0;
    }
}
