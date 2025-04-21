using UnityEngine;

public class RaceTrackEventManager : MonoBehaviour
{
    public GameObject finishGameMenuUI;

    void OnEnable()
    {
        Banana.OnGameOver += LoadFinishGameMenu;
    }

    void OnDisable()
    {
        Banana.OnGameOver -= LoadFinishGameMenu;
    }

    private void LoadFinishGameMenu()
    {
        finishGameMenuUI.SetActive(true);
    }
}
