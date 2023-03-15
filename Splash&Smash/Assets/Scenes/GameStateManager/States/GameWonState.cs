using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        Debug.Log("Entered the GameWon State.");
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("HighScore"))
        {
            SceneManager.LoadScene("HighScore");
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
            Debug.Log("Entered the Game Won State.");
        }
    }
    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {
    }

    IEnumerator WaitForSceneToLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("HighScore");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
