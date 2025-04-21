using DefaultNamespace;
using scene.racetrack;
using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TextMeshProUGUI timerText;
    public float elapsedTime { private set; get; }

    private void OnEnable()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        ResetTimer();
        FinishGameMenu.OnRestartGame += ResetTimer;
    }

    private void OnDisable()
    {
        FinishGameMenu.OnRestartGame -= ResetTimer;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString("0.00");
    }

    private void ResetTimer()
    {
        elapsedTime = 0f;
    }

    public string GetFormattedTimerText()
    {
        return timerText.text;
    }
}
