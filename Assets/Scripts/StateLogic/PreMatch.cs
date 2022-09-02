using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreMatch : State
{
    public PreMatch(StateController stateController) : base(stateController)
    {
    
    }

    public override IEnumerator Start()
    {
        Time.timeScale = 0;
        yield break;
    }
}
