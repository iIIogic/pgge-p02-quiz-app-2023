using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    Text _totalScoreText;
    [SerializeField]
    Text _countdownTimerText;
    [SerializeField]
    Text _progressText;
    [SerializeField]
    Text _questionText;
    [SerializeField]
    Text _optionAText;
    [SerializeField]
    Text _optionBText;
    [SerializeField]
    Text _optionCText;
    [SerializeField]
    Text _optionDText;

    [SerializeField]
    RectTransform _PanelQuiz;
    [SerializeField]
    RectTransform _PanelCorrectAnswer;
    [SerializeField]
    RectTransform _PanelInCorrectAnswer;
    [SerializeField]
    RectTransform _PanelTimeup;

    [SerializeField]
    Button _NextButton;
    [SerializeField]
    Text _CorrectAnswerText;
    [SerializeField]
    Text _scoreText;

    List<Question> _questions;
    int _currentIndex;
    int _totalScore;

    [SerializeField]
    float maxAllowableTime = 30.0f;

    IEnumerator _countdownTimerCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        LoadQuestion();
    }

    void LoadQuestion()
    {
        _questions = Question.CreateQuestions();
        ShowQuestion(0);
    }

    void ShowQuestion(int id)
    {
        if(id >= _questions.Count)
        {
            // we have ended answwering all questions
            // go to the post quiz using SceneManager Loadscene.
            return;
        }

        _currentIndex = id;
        _progressText.text = (_currentIndex + 1).ToString() + "/" + _questions;
        Question q = _questions[id];

        _questionText.text = q.question;

        // TODO: Provide proper validation.
        _optionAText.text = q.choices[0];
        _optionBText.text = q.choices[1];

        // we must have two options. 
        if(q.choices.Count > 2)
            _optionCText.text = q.choices[2];

        if (q.choices.Count > 3)
            _optionDText.text = q.choices[3];

        _countdownTimerCoroutine 
        StartCoroutine();
    }
    IEnumerator Coroutine_CountdownTimer(float t)
    {
        float dt = 0.0f;
        while(dt< t)
        {
            yield return new WaitForSeconds(0.5f);
            dt += 0.5f;
        }
        _countdownTimerText.text = (maxAllowableTime - dt).ToString("F2");

        //Go to: timeover screen
        _PanelTimeup.gameObject.SetActive(true);
        _PanelQuiz.gameObject.SetActive(false);
        _PanelInCorrectAnswer.gameObject.SetActive(false);
        _PanelCorrectAnswer.gameObject.SetActive(false);
        _NextButton.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectOption(int id)
    {
        if(_countdownTimerCoroutine != null)
        {
            StopCoroutine(_countdownTimerCoroutine);
        }
        Question q = _questions[_currentIndex];
        if(id == q.correctAnswerid)
        {
            //correct answer
            int score = 80;
            ShowCorrectAnswerScreen(score);
        }
        else
        {
            //incorrect answer
            ShowInCorrectAnswerScreen();
        }
    }

    void ShowCorrectAnswerScreen(int score)
    {
        _PanelTimeup.gameObject.SetActive(false);
        _PanelQuiz.gameObject.SetActive(false);
        _PanelInCorrectAnswer.gameObject.SetActive(false);
        _PanelCorrectAnswer.gameObject.SetActive(true);
        _NextButton.gameObject.SetActive(true);
        _scoreText.text = score.ToString();
        _totalScore += score;
        

    }

    void ShowInCorrectAnswerScreen()
    {
        _PanelTimeup.gameObject.SetActive(false);
        _PanelQuiz.gameObject.SetActive(false);
        _PanelInCorrectAnswer.gameObject.SetActive(true);
        _PanelCorrectAnswer.gameObject.SetActive(false);
        _NextButton.gameObject.SetActive(true);

        int answerIndex;
    }
    public void OnClickNext()
    {

    }
    public void OnClickOptionA()
    {
        SelectOption(0);
    }
    public void OnClickOptionB()
    {
        SelectOption(1);
    }
    public void OnClickOptionC()
    {
        SelectOption(2);
    }
    public void OnClickOptionD()
    {
        SelectOption(3);
    }

    public void NextQuestion()
    {
        _currentIndex += 1;
        if(_currentIndex == _questions.Count)
        {
            //finish quiz.
            return;
        }
        ShowQuestion(_currentIndex);
    }
}
