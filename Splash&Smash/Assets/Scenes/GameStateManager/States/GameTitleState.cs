using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTitleState : GameBaseState
{
    public override void EnterState(GameStateManager state)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("TitleScene"))
        {
            SceneManager.LoadScene("TitleScene");
            Debug.Log("Loaded Scene " + SceneManager.GetActiveScene().name);
            state.StartCoroutine(WaitForSceneToLoad());
            Debug.Log("Entered the Title State.");
        }

        state.audioSourceHandler.announcerSource.PlayOneShot(state.audioSourceHandler.gameStartAnnoucement);
    }

    public override void UpdateState(GameStateManager state)
    {
        
    }
    public override void ExitState(GameStateManager state)
    {

    }

    IEnumerator WaitForSceneToLoad()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TitleScene");
        if (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
