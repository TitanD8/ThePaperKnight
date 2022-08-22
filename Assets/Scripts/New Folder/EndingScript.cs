using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This Script manages the final splash page of the prototype for Paper Knight. This will change and be replaced by Credits before the game returns to the main menu.
 */

public class EndingScript : MonoBehaviour
{
    //An array of game objects which are used to determine the possible resolution states.
    public GameObject[] states;

    // On Awake, run Update EndState
    void Awake()
    {
        UpdateEndState();
    }

    public void UpdateEndState()
    {
        //If the player scores 5 before the enemy, then set the win screen to active.
        if(PlayStats.playerScore >= 5)
        {
            states[0].SetActive(true);
        }
        //else if the enemy scores 5 before the player, then set the lose screen to active.
        else
        {
            states[1].SetActive(true);
        }
    }

    // Update is called once per frame, and check to see where mouse position in, and checks if while the mouse is over the collider named background the left mouse button is clicked.
    // if it is set PlayStats bool gameHasStarted to false (this will trigger a reset of the stats in PlayStats when a new game is started.)
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.name == "Background")
            {
                PlayStats.gameHasStarted = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
