using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float timeToCompleteQuestion = 30f;
    [SerializeField]
    private float timeToShowAnswer = 10f;

    [SerializeField]
    private Image timeImage;

    public float timer;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToCompleteQuestion;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

       // Debug.Log(timer);

        if (isAnsweringQuestion)
        {
            if (timer > 0)
            {
                timeImage.fillAmount = timer / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timer = timeToShowAnswer;
            }
        }
        else
        {
            if (timer > 0)
            {
                timeImage.fillAmount = timer / timeToShowAnswer;
            }
            else
            {
                timer = timeToCompleteQuestion;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
        }  
    }

    public void CancelTimer()
    {
        timer = 0;
    }
}
