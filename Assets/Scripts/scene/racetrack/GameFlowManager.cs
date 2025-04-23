using DefaultNamespace;
using scene.racetrack;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private GameObject timerGameObject;
    [SerializeField] private GameObject finishGameMenuUI;
    private Timer _timer;
    private FinishGameMenu _finishGameMenuScript;

    private void OnEnable()
    {
        _timer = timerGameObject.GetComponent<Timer>();
        _finishGameMenuScript = finishGameMenuUI.GetComponent<FinishGameMenu>();
        Banana.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Banana.OnGameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        float currentHighScore = GlobalStateManager.Instance.highScore;
        if (_timer.elapsedTime < currentHighScore)
        {
            OnNewHighScore();
        } else if (_timer.elapsedTime == currentHighScore)
        {
            OnSameScore();
        }
        else
        {
            OnLowerScore();
        }
    }

    private void OnNewHighScore()
    {
        GlobalStateManager.Instance.highScore = _timer.elapsedTime;
        _finishGameMenuScript.playerScoreText.text = "New Fastest Time!";
        _finishGameMenuScript.highScoreText.text = $"High score: {_timer.GetFormattedTimerText()}";
    }

    private void OnSameScore()
    {
        _finishGameMenuScript.playerScoreText.text = $"You matched the high score!";
        _finishGameMenuScript.highScoreText.text = "High score: " + GlobalStateManager.Instance.highScore.ToString("0.00");
    }

    private void OnLowerScore()
    {
        _finishGameMenuScript.playerScoreText.text = $"Time: {_timer.GetFormattedTimerText()}!";
        _finishGameMenuScript.highScoreText.text = "High score: " + GlobalStateManager.Instance.highScore.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
