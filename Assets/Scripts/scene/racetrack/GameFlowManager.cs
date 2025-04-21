using DefaultNamespace;
using scene.racetrack;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private GameObject timerGameObject;
    [SerializeField] private GameObject finishGameMenuUI;
    private Timer timer;
    FinishGameMenu finishGameMenuScript;

    private void OnEnable()
    {
        timer = timerGameObject.GetComponent<Timer>();
        finishGameMenuScript = finishGameMenuUI.GetComponent<FinishGameMenu>();
        Banana.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Banana.OnGameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        float currentHighScore = GlobalStateManager.Instance.highScore;
        if (timer.elapsedTime < currentHighScore)
        {
            OnNewHighScore();
        } else if (timer.elapsedTime == currentHighScore)
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
        GlobalStateManager.Instance.highScore = timer.elapsedTime;
        finishGameMenuScript.playerScoreText.text = "New Fastest Time!";
        finishGameMenuScript.highScoreText.text = $"High score: {timer.GetFormattedTimerText()}";
    }

    private void OnSameScore()
    {
        finishGameMenuScript.playerScoreText.text = $"You matched the high score!";
        finishGameMenuScript.highScoreText.text = "High score: " + GlobalStateManager.Instance.highScore.ToString("0.00");
    }

    private void OnLowerScore()
    {
        finishGameMenuScript.playerScoreText.text = $"Time: {timer.GetFormattedTimerText()}!";
        finishGameMenuScript.highScoreText.text = "High score: " + GlobalStateManager.Instance.highScore.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
