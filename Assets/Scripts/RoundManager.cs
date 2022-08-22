using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    private void Awake()
    {
        if (PlayStats.gameHasStarted == false)
        {
            PlayStats.SetNewGameStats();
            PlayStats.gameHasStarted = true;
        }
        else
        {
            PlayStats.SetNewRoundStats();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
