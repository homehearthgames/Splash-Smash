using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameBaseState
{

    //Reference to score handler
    
    public override void EnterState(GameStateManager state)
    {
        //Play the game over sound
        Debug.Log("Entered the Over State.");
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
        //save current score to player prefs
    }
}
