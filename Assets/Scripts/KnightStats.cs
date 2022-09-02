using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightStats : MonoBehaviour
{
    //Default Stats

    public int MaxHealth = 10;
    

    //Variable Stats

    public int currentHealth;
    public int healthDrain;
    public int persistentDamage;
    public bool isKnockedOut;

    public void ResetVariableStats()
    {
        currentHealth = 0;
        healthDrain = 0;
        persistentDamage = 0;
        isKnockedOut = false;
    }
    public void DecreaseHealth(int damageAmount)
    {
        currentHealth -= damageAmount;
        persistentDamage += damageAmount;
    }

    public bool CheckForKnockout()
    {
        if(isKnockedOut)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
