using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class MBTIQuestionController : QuestionController
{
    private int E = 0, I = 0, S = 0, N = 0, T = 0, F = 0, J = 0, P = 0;

    [SerializeField] MBTIQuestionsList MBTIquestionList;

    private MBTIQuestionContent currQuestion;
    public override void DisplayRandomQuestion()
    {
        currQuestion = GetRandomQuestion();
        questionPanel.DisplayQuestion(currQuestion);
    }
    public MBTIQuestionContent GetRandomQuestion()
    {
        int randInt = Random.Range(0, MBTIquestionList.questions.Count);
        MBTIQuestionContent ques = MBTIquestionList.questions[randInt];
        MBTIquestionList.questions.RemoveAt(randInt);
        return ques;
    }

    public string GetMBTIString()
    {
        string MBTI = "";
        MBTI += (E > I) ? "E" : "I";
        MBTI += (S > N) ? "S" : "N";
        MBTI += (T > F) ? "T" : "F";
        MBTI += (J > P) ? "J" : "P";
        return MBTI;
    }

    public override void TakeResult(int result, int group)
    {
        numQuesAnswered++;
        if (result != 2)
        {
            int trueAns = currQuestion.TrueAnswer;
            switch (group)
            {
                case 0: if (result == trueAns) E++; else I++; break;
                case 1: if (result == trueAns) T++; else F++; break;
                case 2: if (result == trueAns) S++; else N++; break;
                case 3: if (result == trueAns) J++; else P++; break;
            }
        }
        Debug.Log(MBTIquestionList.questions.Count);
        if (MBTIquestionList.questions.Count == 0)
        {
            string mbti = GetMBTIString();

            mbti = JsonConvert.SerializeObject(mbti);
            Debug.Log(mbti);
            DBRequestManager.Instance.DataSendRequestWithToken(APIUrls.postMBTIResultApi, mbti, PlayerPrefs.GetString("usertoken"), (s) =>
            {
                Debug.Log(s);
            });
            GameManager.Instance.GameVictory();
            questionPanel.HidePanel();
            return;

        }
        if (numQuesAnswered < numQues)
        {
            DisplayRandomQuestion();
        }
        else
        {
            GameManager.Instance.ChangeState(GameState.Playing);
            questionPanel.HidePanel();
        }
    }
}
