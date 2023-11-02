using TMPro;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
{
    public TextMeshProUGUI quesTxt;
    public AnswerButton A;
    public AnswerButton B;
    public AnswerButton C;
    public virtual void TakeResult(int result) { }
    public void HidePanel()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void DisplayQuestion(IQuestion ques)
    {

    }
}
