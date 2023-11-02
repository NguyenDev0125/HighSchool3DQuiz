using TMPro;
using UnityEngine;

public class MBTIQuestionPanel : QuestionPanel
{
    public MBTIQuestionController quesController;
    int group = 0;
    public override void DisplayQuestion(IQuestion ques)
    {
        MBTIQuestionContent question = (MBTIQuestionContent) ques;
        quesTxt.text = question.NameQues;
        A.SetText(question.Ans1);
        B.SetText(question.Ans2);
        C.SetText("Next question");
        group = question.Group;
        this.gameObject.SetActive(true);

    }
    public override void TakeResult(int result)
    {
        quesController.TakeResult(result , group);
    }
}
