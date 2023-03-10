using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    public GameBaseState currentState;
    public GameTitleState TitleState = new GameTitleState();
    public GameLevelSelectState LevelSelectState = new GameLevelSelectState();
    public GameCustomizationState CustomizationState = new GameCustomizationState();
    public GameOptionsState OptionsState = new GameOptionsState();
    public GamePlayState PlayState = new GamePlayState();
    public GamePauseState PauseState = new GamePauseState();
    public GameOverState OverState = new GameOverState();
    public GameWonState WonState = new GameWonState();



    public AudioSourceHandler audioSourceHandler;
    public LevelSO currentLevelSO;
    public string currentScene;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        audioSourceHandler = FindObjectOfType<AudioSourceHandler>();
    }
    
    void Start()
    {
        Debug.Log("GameStateManager Started");
        currentState = TitleState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(GameBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }

}
