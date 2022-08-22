using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ResolutionManager : MonoBehaviour
{
    public LanceController playerLance;
    public LanceController enemyLance;

    public UnityEvent StopMoving;

    public Animator playerAnimator;
    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        playerLance.StrikeCheck();
        enemyLance.EnemyStrikeCheck(PlayStats.GetEnemyHitFactor());
        
    }

    public void  CheckKOStatus()
    {
        if (PlayStats.playerKnockout == true)
        {
            playerAnimator.SetBool("KnockedOut", true);
            Debug.Log("knockedout");
            ApplyResolution();
        }
        else if (PlayStats.enemyKnockout == true)
        {
            enemyAnimator.SetBool("E_KnockedOut", true);
            Debug.Log("knockedout");
            ApplyResolution();
        }
        else
        {
            ApplyResolution();
        }
    }

    public void ApplyResolution()
    {
        StopMoving.Invoke();
        PlayStats.UpdateScoreAndDamage();
        StartCoroutine("MoveToNextRound");
    }

    IEnumerator MoveToNextRound()
    {
        yield return new WaitForSeconds(2);
        if (PlayStats.playerScore >= 5 || PlayStats.enemyScore >= 5)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckKOStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
