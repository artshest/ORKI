using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]private int Level;
    [SerializeField]private int maxHealth;
    [SerializeField]private int curHealth;
    [SerializeField]private int armorClass;
    [SerializeField]private GameClass gameClass;
    
    public Stat Body;
    public Stat Strength;
    public Stat Dexterity;
    public Stat Intelligence;

    public void Awake()
    {
        armorClass = 10 + Dexterity.GetValue();
        gameClass = this.GetComponent<GameClass>();
        maxHealth = gameClass.GetHealthModifier() + 5 + (5 * Body.GetValue());
        if (Level > 1)
        {
            maxHealth += (gameClass.GetHealthModifier() + (5 * Body.GetValue())) * (Level - 1);
        }

        curHealth = maxHealth;
    }

    public int getBody()
    {
        return Body.GetValue();
    }
    
    public int getStrength()
    {
        return Strength.GetValue();
    }
    
    public int getDexterity()
    {
        return Dexterity.GetValue();
    }
    public int getIntelligence()
    {
        return Intelligence.GetValue();
    }
    

    public int getArmorClass()
    {
        return armorClass;
    }

    public void takeDamage(int damage)
    {
        curHealth -= damage;
    }

    public virtual void Die()
    {
        //Нужен для перегрузки
        //Осуществляет смерть персонажа
    }
    
    public virtual void Hit(EnemyStats enemy)
    {
        //Нужен для перегрузки
        //Хитует без оружия
    }
    
    public virtual void Hit(GameObject gameObject, Item item)
    {
        //Нужен для перегрузки
        //Хит с оружием
    }

}

