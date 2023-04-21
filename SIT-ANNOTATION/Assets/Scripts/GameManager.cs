using System;
using UnityEngine;

public enum GameState
{
    TutorialMenu,
    GamePlay,
    ShowRadialMenu,
    BugReportMode,
    DefaultState,
    ReportMotionSickness,
    FinishScreenANT,
    FinishScreenSIT,
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState state;
    public Condition condition;
    public int currentTaskNumber = 0;
    public int totalNumberTasks = 3;

    public static event Action<GameState> OnGameStateChanged;


    public void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        ChangeColorOnHover.OnRadialMenuOpen += UpdateGameState;
        ChangeColorOnHover.OnMotionSicknessReport += UpdateGameState;
        Buzzer.OnTaskFinished += HandleTaskFinished;
        ToggleObject.OnToggled += UpdateGameState;
    }

    private void OnDestroy()
    {
        ChangeColorOnHover.OnRadialMenuOpen -= UpdateGameState;
        ChangeColorOnHover.OnMotionSicknessReport -= UpdateGameState;
        Buzzer.OnTaskFinished -= HandleTaskFinished;
    }

    void HandleTaskFinished(int oldTaskNumber)
    {
        currentTaskNumber = oldTaskNumber + 1;
        if (currentTaskNumber > totalNumberTasks)
        {
            //turn off logging and end application, play end message
        }
        else
        {
            //load new scene
        }
    }

    public void UpdateGameState(GameState newstate)
    {
        state = newstate;


        switch (newstate)
        {
            case GameState.TutorialMenu:
                HandleTutorialMenu();
                break;
            case GameState.GamePlay:
                break;
            case GameState.ShowRadialMenu:
                break;
            case GameState.BugReportMode:
                break;
            case GameState.DefaultState:
                break;
            case GameState.ReportMotionSickness:
                break;
            case GameState.FinishScreenANT:
                break;
            case GameState.FinishScreenSIT:
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newstate); ///Where did e add the listener to look of change in state?
    }

    private void HandleTutorialMenu()
    {

    }


    public enum Condition
    {
        ANT,
        SIT
    }
}