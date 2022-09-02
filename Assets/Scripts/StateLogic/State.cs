using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateController StateController;
    
    public State(StateController stateController)
    {
        StateController = stateController;
    }

    public virtual IEnumerator Start()
    {

        //Set any stats required for this state.
        yield break;
    }
    
    public virtual IEnumerator Check()
    {

        //Check any changes to the stats while in the State.
        yield break;
    }

    public virtual IEnumerator Execute()
    {
        //Make any changes and Determine next game state and move there.
        yield break;
    }

}
