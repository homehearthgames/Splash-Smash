using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOptionsState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OptionsScene"))
        {
            SceneManager.LoadScene("OptionsScene");
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
            Debug.Log("Entered the Options State.");
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OptionsScene");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
