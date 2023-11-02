using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectQuestionMenu : MonoBehaviour
{
    public QuestionLoader questionsLoader;
    public Button mbtiBtn;
    public Button reviewBtn;

    private void Awake()
    {
        mbtiBtn.onClick.AddListener(LoadQuestionFromLocal);
        reviewBtn.onClick.AddListener(LoadQuestionFormUrl);
    }
    private void LoadQuestionFromLocal()
    {
        questionsLoader.LoadQuestionsFromLocal();
        PlayerPrefs.SetInt("gamemode", 0);
        SceneManager.LoadScene("GamePlay");
    }
    private void LoadQuestionFormUrl()
    {
        questionsLoader.LoadQuestionFormAPI();
        PlayerPrefs.SetInt("gamemode", 1);
        SceneManager.LoadScene("GamePlay");

    }

}
