using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MBTIQuestionsListSO" , menuName = "new MBTIQuestionsList")]
public class MBTIQuestionsList : ScriptableObject
{
    public List<MBTIQuestionContent> questions;
}
