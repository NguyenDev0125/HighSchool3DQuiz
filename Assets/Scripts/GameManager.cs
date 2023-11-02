using Newtonsoft.Json;
using StarterAssets;
using UnityEngine;

public class GameManager : SingletonGeneric<GameManager>
{
    public UIController UIController;
    public ThirdPersonController player;
    public MBTIQuestionController mbtiQuesController;
    public ReviewQuestionController reviewQuestionController;
    private QuestionController questionController;
    
    public GameState GameState;

    public QuestionController QuestionController { get => questionController;}


    private void Awake()
    {
        Application.targetFrameRate = 60;
        int gameMode = PlayerPrefs.GetInt("gamemode", 0);
        if(gameMode == 0)
        {
            questionController = mbtiQuesController;
        }
        else
        {
            questionController = reviewQuestionController;
        }
    }

    private void Start()
    {
        StartingGame();
        string mbti = "MBTI";
        DBRequestManager.Instance.FieldDataSendRequest(APIUrls.postMBTIResultApi, mbti, PlayerPrefs.GetString("usertoken"), (s) =>
        {
            Debug.Log(s);
        });
    }
    private void StartingGame()
    {
        Debug.Log("Starting game");
    }
    public void ChangeState(GameState state)
    {
        GameState = state;
        switch (state)
        {
            case GameState.Playing: player.CanMove = true; Cursor.lockState = CursorLockMode.Locked; break;
            case GameState.Answering: player.CanMove = false; Cursor.lockState = CursorLockMode.None; break;
        }
    }

    public void GameVictory()
    {
        UIController.HideUI();
    }
}

public enum GameState
{
    Playing,
    Answering
}
