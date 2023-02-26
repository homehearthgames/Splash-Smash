using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered the GameWon State.");
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
    }
}
