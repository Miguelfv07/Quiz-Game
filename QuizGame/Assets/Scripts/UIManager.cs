using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField]Button[] answersButtons;
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]GameObject menuWindow;
    [SerializeField] Button startButton;
    [SerializeField] TMP_Dropdown dificultyDropdown, themeDropdown;
    [SerializeField] Button nextButton;
    private void Start()
    {
        startButton.onClick.AddListener(() => GameManager.Instance.StarGame(dificultyDropdown.value,themeDropdown.value));
        nextButton.onClick.AddListener(() => QuizManager.instance.SelectQuiz(GameManager.Instance.Theme, GameManager.Instance.Dificulty));

        for(int i = 0; i < answersButtons.Length; i++ )

        {
            int x = i;

            answersButtons[i].onClick.AddListener(() => QuizManager.instance. CheckAnswer(x));

            answersButtons[i].onClick.AddListener(() => nextButton.interactable = true);
        }
    }

    public void UpdateQuestion(Quiz quizSelected)
    {
        questionText.text = quizSelected.Question;

        for(int i = 0; i < answersButtons.Length; i++)
        {
            answersButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = quizSelected.Answers[i];
            answersButtons[i].onClick.AddListener(() => nextButton.interactable = true);

            answersButtons[i].GetComponent < Image >().color = Color.white;
        }

        nextButton.interactable = false;
    }

    public void SetMenu(bool active )
    {
        menuWindow.SetActive(active);  
    }

    public void HighlightButton(int correctAnswer, int answerselected)

    {
        answersButtons[correctAnswer].GetComponent<Image>().color = Color.green;

        if( answerselected != correctAnswer)

        {
            answersButtons[answerselected].GetComponent<Image>().color = Color.red;
        }

        for(int i = 0; i < answersButtons.Length; i++ )

        {
            answersButtons[i].interactable = false;
        }
    }
}

