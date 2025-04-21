using scene.racetrack;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float _elapsedTime;

    private void OnEnable()
    {
        ResetTimer();
        FinishGameMenu.OnRestartGame += ResetTimer;
    }

    private void OnDisable()
    {
        FinishGameMenu.OnRestartGame -= ResetTimer;
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        timerText.text = _elapsedTime.ToString("0.00");
    }

    private void ResetTimer()
    {
        _elapsedTime = 0f;
    }
}
