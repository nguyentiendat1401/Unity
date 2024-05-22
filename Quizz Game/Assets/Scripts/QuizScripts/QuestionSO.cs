using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Question", menuName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(3, 6)]
    public string question = "Enter new question text here";

    public string[] answers = new string[4];

    public int correctAnswerIndex;

    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
