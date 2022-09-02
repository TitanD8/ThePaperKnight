using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayStats
{
    //Player Stats
    public static int maxStamina = 10; 
    public static int currentStamina;
    public static int playerScore;
    public static int persistantDamage;
    public static int hitFactor;

    //Enemy Stats
    public static int enemyMaxStamina = 10;
    public static int enemyCurrentStamina;
    public static int enemyScore;
    public static int enemyPersistantDamage;
    public static int enemyHitFactor;

    //Game State Stats
    public static bool gameHasStarted = false;
    public static bool lanceIsCradled = false;
    public static int roundNumber = 0;
    public static bool playerKnockout = false;
    public static bool enemyKnockout = false;


    //Functions
    public static void IncreaseHitFactor()
    {
        if(hitFactor < 2) // if hitFactor is less than 2
        {
            hitFactor += 1; // add one to the current value of hitFactor.
        }
    }

    public static void DecreaseHitFactor()
    {
        if (hitFactor > 0) //if hit factor is greater than zero
        {
            hitFactor -= 1; // decrease the current value of hitFactor by 1
        }

    }

    public static int GetEnemyHitFactor()
    {
        enemyHitFactor = Random.Range(0, 3); // Generate a random number between 0 and 2 (int in non-inclusive of highest number) and set is enemyHitFactor
        return enemyHitFactor; //returns enemyHitFactor value
    }

    public static void SetNewGameStats()
    {
        //Reset Player Stats
        currentStamina = maxStamina; //Sets currentStamina to the value of maxStamina
        playerScore = 0; // Sets playerscore to 0
        persistantDamage = 0; // Sets persistantDamage to 0
        hitFactor = 0; // sets hitfactor = 0;

        //Reset Enemy Stats
        enemyCurrentStamina = enemyMaxStamina;
        enemyScore = 0;
        enemyPersistantDamage = 0;
        enemyHitFactor = 0;
    }

    public static void SetNewRoundStats()
    {
        //set Player Stats for next round
        currentStamina = maxStamina - persistantDamage;
        hitFactor = 0;

        //set Enemy Stats for next round
        enemyCurrentStamina = enemyMaxStamina - enemyPersistantDamage;
        enemyHitFactor = 0;
    }

    public static void UpdateScoreAndDamage()
    {
        if (enemyHitFactor == 1)
        {


            Debug.Log("Player's Stamina Before: " + currentStamina);
            currentStamina = currentStamina - enemyHitFactor - 1;
            Debug.Log("Player's Stamina After: " + currentStamina);

            Debug.Log("Player's Persistant Damage Before: " + persistantDamage);
            persistantDamage += enemyHitFactor + 1;
            Debug.Log("Player's Persistant Damage After: " + persistantDamage);
        }
        else if (enemyHitFactor == 2)
        {
            Debug.Log("CRITICAL HIT!");
            Debug.Log("Player's Stamina Before: " + currentStamina);
            currentStamina = currentStamina - enemyHitFactor - 2;
            Debug.Log("Player's Stamina After: " + currentStamina);

            Debug.Log("Player's Persistant Damage Before: " + persistantDamage);
            persistantDamage += enemyHitFactor + 2;
            Debug.Log("Player's Persistant Damage After: " + persistantDamage);
        }

        if (hitFactor == 1)
        {
            Debug.Log("Enemy's Stamina Before: " + enemyCurrentStamina);
            enemyCurrentStamina = enemyCurrentStamina - hitFactor - 1;
            Debug.Log("Enemy's Stamina after: " + enemyCurrentStamina);

            Debug.Log("Enemy's Persistant Damage Before: " + enemyPersistantDamage);
            enemyPersistantDamage += hitFactor + 1;
            Debug.Log("Enemy's Persistant Damage After: " + enemyPersistantDamage);
        }
        else if (hitFactor == 2)
        {
            Debug.Log("CRITICAL HIT!");
            Debug.Log("Enemy's Stamina Before: " + enemyCurrentStamina);
            enemyCurrentStamina = enemyCurrentStamina - hitFactor - 2;
            Debug.Log("Enemy's Stamina after: " + enemyCurrentStamina);

            Debug.Log("Enemy's Persistant Damage Before: " + enemyPersistantDamage);
            enemyPersistantDamage += hitFactor + 2;
            Debug.Log("Enemy's Persistant Damage After: " + enemyPersistantDamage);
        }

        if (enemyCurrentStamina > 0 && currentStamina > 0)
        {
            Debug.Log("Player's Score Before: " + playerScore);
            playerScore = playerScore + hitFactor;
            Debug.Log("Player's Score After: " + playerScore);

            Debug.Log("Enemy's Score Before: " + enemyScore);
            enemyScore = enemyScore + enemyHitFactor;
            Debug.Log("Enemy's Score Before: " + enemyScore);
        }
        else if(enemyCurrentStamina <= 0)
        {
            playerScore += 3;
            enemyKnockout = true;
        }
        else if(currentStamina <= 0)
        {
            enemyScore += 3;
            playerKnockout = true;
        }

        if(playerScore > 5)
        {
            playerScore = 5;
        }
        if (enemyScore > 5)
        {
            enemyScore = 5;
        }
    }
}
