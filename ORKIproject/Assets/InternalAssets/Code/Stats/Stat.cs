using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField] private int value;
    [SerializeField] private int statModifier;

    public int GetModifier()
    {
        return statModifier;
    }

    public void SetModifier(int modifier)
    {
        statModifier += statModifier;
    }
    
    public int GetValue()
    {
        return value;
    }

    public void SetValue(int setV)
    {
        if (-2 < setV | setV < 6)
        {
            value = setV;
        }
    }

    public void StatUp(int statUp)
    {
        value += statUp;
    }
    
    
}
