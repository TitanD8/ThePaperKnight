using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : State
{
    public NewGame(StateController stateController) : base(stateController)
    {
    
    }

    public KnightStats Player;
    public KnightStats Enemy;

    public override IEnumerator Start()
    {
        Player = GameObject.FindWithTag("Player").AddComponent<KnightStats>();
        //Enemy = GameObject.FindWithTag("Enemy").AddComponent<KnightStats>();
        //Set Player's Default Stats
        Player.ResetVariableStats();
        Player.currentHealth = Player.MaxHealth;

        //Set Enemy's Default Stats
        //Enemy.ResetVariableStats();
        //Enemy.currentHealth = Enemy.MaxHealth;

        //Then proceed to pre-match.
        StateController.SetState(new PreMatch(StateController));

        yield break;
    }
}
