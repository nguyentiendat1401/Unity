using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Questions Setting")]
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField]
    private GameObject[] answerButtons;
    private int currentCorrectIndex;
    private bool hasAnswerEarly = true;

    [Header("Button Colors")]
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private Sprite correctAnswerSprite;

    [Header("Time Manager")]
    private TimeManager timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<TimeManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.loadNextQuestion)
        {
            if (questions.Count > 0)
            {
                SetDefaultSprite();
                GetRandomQuestion();
                DisplayQuestion();
                timer.loadNextQuestion = false;
                hasAnswerEarly = false;
                SetButtonState(true);
            }
        }
        else if (!hasAnswerEarly && !timer.isAnsweringQuestion)
        {
            // Hien thi 
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        Debug.Log(currentQuestion.question);

        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }
    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void DisplayAnswer(int index)
    {
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
        }
        else
        {
            currentCorrectIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(currentCorrectIndex);
            questionText.text = correctAnswer;
            answerButtons[currentCorrectIndex].GetComponent<Image>().sprite = correctAnswerSprite;
        }
      
    }

    public void OnAnswerButtonClick(int index)
    {
        hasAnswerEarly = true;
        DisplayAnswer(index);
        timer.CancelTimer();
        SetButtonState(false);
    }

    void SetDefaultSprite()
    {
        for (int i = 0;i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultSprite;
        }
    }
    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = state;
        }
    }
}
