using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    public override void Hit(EnemyStats enemy)
    {
        //просчитать бросок на попадание
        int hitModifier = getStrength();
        int hitValue = Random.Range(1, 20) + hitModifier;
        int enemyAC = enemy.getArmorClass() ;
        
        int damage;
        if (hitValue >= enemyAC  & hitValue < enemyAC + 10)
        {
            damage = Random.Range(1, 6) + Random.Range(1, 6) + getStrength();
            enemy.takeDamage(damage);
            Debug.Log("Ты попал с роллом " + hitValue + " против КД " + enemy.getArmorClass() + "с уроном " + damage);
        }
        else if (hitValue >= enemyAC + 10)
        {
            damage = (Random.Range(1, 6) + Random.Range(1, 6) + getStrength()) * 2;
            enemy.takeDamage(damage);
            
            Debug.Log("КРИТИЧЕСКИЙ УДАР Ты попал с роллом " + hitValue + " против КД " + enemy.getArmorClass() + "с уроном " + damage);
        }
        else
        {
            Debug.Log("Ты промазал с роллом " + hitValue + " против КД " + enemy.getArmorClass());
        }



    }
}
