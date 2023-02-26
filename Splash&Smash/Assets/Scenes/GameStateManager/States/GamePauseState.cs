using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered Pause State");
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
    }
}
