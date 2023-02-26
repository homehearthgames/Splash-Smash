using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevelSelectState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("LevelSelectScene"))
        {
            SceneManager.LoadScene("LevelSelectScene");
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
            Debug.Log("Entered the LevelSelect State.");
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelSelectScene");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
