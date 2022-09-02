using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Match : State
{
    public Match(StateController stateContoller) : base (stateContoller)
    {

    }

    public override IEnumerator Start()
    {
        Time.timeScale = 1;
        yield break;
    }

    public override IEnumerator Check()
    {
        KnightStats player = GameObject.FindWithTag("Player").GetComponent<KnightStats>();

        /*
         * I Need to create a repeating check until the player has reached their final position.
         * This check need to record:
         * - The Number of successfully collected nodes
         * - The HitFactor for the player (and eventually enemy)
         * - The Number of missed nodes
         */
        yield break;
    }
}
