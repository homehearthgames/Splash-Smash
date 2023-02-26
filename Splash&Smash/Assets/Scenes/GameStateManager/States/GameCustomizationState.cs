using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCustomizationState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("CustomizationScene"))
        {
            SceneManager.LoadScene("CustomizationScene");
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
            Debug.Log("Entered the Customization State.");
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CustomizationScene");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
