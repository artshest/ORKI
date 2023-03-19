using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameClass : MonoBehaviour
{
    [SerializeField]protected string Name;
    [SerializeField]protected int HealthModifier;

    public int GetHealthModifier()
    {
        return HealthModifier;
    }
}
