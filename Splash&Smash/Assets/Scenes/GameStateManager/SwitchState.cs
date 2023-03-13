using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToTitleState()
    {
        GameStateManager.Instance.SwitchState(GameStateManager.Instance.TitleState);
    }    
    public void SwitchToLevelSelectState()
    {
        Debug.Log("SwitchToLevelSelectState");
        GameStateManager.Instance.SwitchState(GameStateManager.Instance.LevelSelectState);
    }   
    public void SwitchToOptionsState()
    {
        Debug.Log("SwitchToOptionsState");
        GameStateManager.Instance.SwitchState(GameStateManager.Instance.OptionsState);
    }

    public void SwitchToPlayState(string sceneName)
    {
        GameStateManager.Instance.currentScene = sceneName;
        GameStateManager.Instance.SwitchState(GameStateManager.Instance.PlayState);
    }

    private void OnMouseDown()
    {
        Debug.Log("Mousedown:" + name);
    }


}
