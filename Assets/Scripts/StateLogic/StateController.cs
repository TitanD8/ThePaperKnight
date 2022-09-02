using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : StateMachine
{
    
    private void Awake()
    {
        SetState(new NewGame(this));
    }

    public void ReadyForMatch()
    {
        SetState(new Match(this));
    }
}
