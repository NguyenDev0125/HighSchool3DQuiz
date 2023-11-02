
using UnityEngine;

public class Teacher : MonoBehaviour
{
    public ArrowDirection arrowDirection;
    public MissionListPanel missionListPanel;
    public int numQues;
    bool isAnswered = false;
    private void OnTriggerEnter(Collider other)
    {
        if(!isAnswered)
        {
            isAnswered = true;
            GameManager.Instance.QuestionController.StartAnswering(numQues);
            arrowDirection.SetNextTarget();
            missionListPanel.UnLockMission();
        }
    }

    public void SetNumQues(int numQues)
    {
        this.numQues = numQues; 
    }
}
