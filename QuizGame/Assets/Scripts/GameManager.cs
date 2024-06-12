using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    #region Singleton

    public static GameManager Instance;

    public void Awake()
    {
        Instance = this; 
    }
    #endregion

    QuizManager quizManager;

    Quiz.Dificulty dificulty;
    Quiz.Theme theme;

    private void Start()
    {
        quizManager= FindObjectOfType<QuizManager>();
        
    }

    public void StarGame(int dificultySelected, int themeSelected)
    {
        UIManager.instance.SetMenu(false);
        dificulty = (Quiz.Dificulty)dificultySelected;
        theme = (Quiz.Theme)themeSelected;
        quizManager.SelectQuiz(theme, dificulty); 

    }
}
