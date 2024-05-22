using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField]
    private GraphicSettings graphicSettings;

    [SerializeField]
    private QuestionSO questionSO;
    // Start is called before the first frame update
    void Start()
    {
        GraphicSettings();

        //Debug.Log(questionSO.question + "--" + questionSO.correctAnswerIndex + "--" + questionSO.answers[questionSO.correctAnswerIndex]);
    }

    void GraphicSettings()
    {
        Screen.SetResolution(graphicSettings.resolutionWitdh, graphicSettings.resolutionHeight, graphicSettings.fullScreen);
    }
}
