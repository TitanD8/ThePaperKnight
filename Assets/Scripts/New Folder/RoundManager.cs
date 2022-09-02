using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayStats.gameHasStarted == false) // if the game has not started
        {
            PlayStats.SetNewGameStats(); // then call the Set New Game Stats function from PlayStats.cs
            PlayStats.gameHasStarted = true; // Set the variable gameHasStarted to true in PlayStats.cs
        }
        else if (PlayStats.gameHasStarted == true) //if the game has already started.
        {
            PlayStats.SetNewRoundStats(); //Set the stats for the next round. (Call Set New Round Stats function from PlayStats.cs)
        }
    }
}
