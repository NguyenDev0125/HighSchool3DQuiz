using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLoader : MonoBehaviour
{
    public MBTIQuestionsList MBTIquestionList;
    public ReviewQuestionList ReviewQuestionList;
    public void LoadQuestionsFromLocal()
    {
        TextAsset quesTxt = Resources.Load<TextAsset>("CauHoi");
        TextAsset ansTxt = Resources.Load<TextAsset>("DapAn");

        QuestionStruct[] arrQuesStruct = JsonConvert.DeserializeObject<QuestionStruct[]>(quesTxt.text);
        AnswerStruct[] arrAnswerStruct = JsonConvert.DeserializeObject<AnswerStruct[]>(ansTxt.text);
        MBTIquestionList.questions = new List<MBTIQuestionContent>();
        for (int i = 0; i < arrQuesStruct.Length; i += 2)
        {
            MBTIQuestionContent newQues = new MBTIQuestionContent();
            newQues.IDQues = arrQuesStruct[i].IDQues;
            newQues.NameQues = arrQuesStruct[i].NameQues;
            newQues.Ans1 = arrQuesStruct[i].NameAns;
            newQues.Ans2 = arrQuesStruct[i + 1].NameAns;
            newQues.Group = arrQuesStruct[i].Group;
            newQues.TrueAnswer = (arrQuesStruct[i].IDAns == arrAnswerStruct[i / 2].IDAns) ? 0 : 1;
            MBTIquestionList.questions.Add(newQues);
        }
    }

    public void LoadQuestionFormAPI()
    {
        DBRequestManager.Instance.DataGetRequestWithToken(APIUrls.getExaminationsApi, PlayerPrefs.GetString("usertoken"), (json) =>
        {
            Respone root = JsonConvert.DeserializeObject<Respone>(json);
            ReviewQuestionList.questions = new List<ReviewQuestionContent>();
            ReviewQuestionList.examId = root.result.items[0].id;
            Debug.Log(ReviewQuestionList.examId);
            List<Exam> items = root.result.items;
            foreach (var item in items)
            {
                foreach (var examQuestion in item.examinationQuestions)
                {       
                    ReviewQuestionContent ques = JsonConvert.DeserializeObject<ReviewQuestionContent>(examQuestion.question.content);
                    ques.examinationQuestionId = examQuestion.id;
                    ReviewQuestionList.questions.Add(ques);
                }
            }
        });
    }
}
