using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ResolutionManager : MonoBehaviour
{
    public LanceController playerLance; // A public variable to hold a reference to the LanceController script. Is set in inspector.
    public LanceController enemyLance; // A public variable to hold a reference to the LanceController script. Is set in inspector.

    public UnityEvent StopMoving; //A Unity Event named "StopMoving". Defined in the inspector.

    public Animator playerAnimator; //A Public variable to hold a reference to the players animator component. Set in the Inspector.
    public Animator enemyAnimator;  //A Public variable to hold a reference to the enemy's animator component. Set in the Inspector.

    void Awake()
    {
        
        playerLance.StrikeCheck(); //Call the strike check function from LanceController.cs (Sets player's lance position)
        enemyLance.EnemyStrikeCheck(PlayStats.GetEnemyHitFactor()); //call the enemy strike check function from LanceController.cs and uses the return value of the GetEnemyHitFactor Function from PlayStats.cs (Sets the enemy's lance position)
    }

    public void  CheckKOStatus()
    {
        if (PlayStats.playerKnockout == true) // if the variable playerKnockout from PlayStats.cs is equal to true;
        {
            playerAnimator.SetBool("KnockedOut", true); //set the player's animator variable KnockedOut to true
            ApplyResolution(); // then call the ApplyResolution Function, see details below.
        }
        else if (PlayStats.enemyKnockout == true) // else if the variable enemyKnockout from PlayStats.cx is equal to true
        {
            enemyAnimator.SetBool("E_KnockedOut", true); //set the enemy's animator variable KnockedOut to true
            ApplyResolution(); // then call the ApplyResolution Function, see details below.
        }
        else
        {
            ApplyResolution(); //else just call the ApplyResolution Function, see details below.
        }
    }

    public void ApplyResolution()
    {
        StopMoving.Invoke(); //Invoke unity event StopMoving (Calls Stop function from xScroller.cs)
        PlayStats.UpdateScoreAndDamage(); //Calls UpdateScoreAndDamage function from PlayStats.cs
        StartCoroutine("MoveToNextRound"); //Starts the coroutine called "MoveToNextRound"
    }

    IEnumerator MoveToNextRound()
    {
        yield return new WaitForSeconds(2); // wait for 2 seconds before continuing
        if (PlayStats.playerScore >= 5 || PlayStats.enemyScore >= 5) // if either the player's or the enemy's scores are greater than or equal to 5
        {
            SceneManager.LoadScene(3); //Load the Exit splash scene (3)
        }
        else
        {
            SceneManager.LoadScene(1); //Load back to the gameplay scene (1)
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckKOStatus(); //on collision call CheckKOStatus function, see details above.
    }
}
