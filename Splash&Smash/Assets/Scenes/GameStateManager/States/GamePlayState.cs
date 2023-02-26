using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(GameStateManager.Instance.currentScene))
        {
            SceneManager.LoadScene(GameStateManager.Instance.currentScene);
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
            Debug.Log("Entered the Play State.");
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(GameStateManager.Instance.currentScene);
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
