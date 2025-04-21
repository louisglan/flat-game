using DefaultNamespace;
using scene.racetrack;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool _isPaused;
    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;

    void OnEnable()
    {
        UnloadPauseMenu();
        PauseMenu.OnResumeGame += UnloadPauseMenu;
        FinishGameMenu.OnRestartGame += UnloadFinishGameMenu;
    }
    
    void OnDisable()
    {
        PauseMenu.OnResumeGame -= UnloadPauseMenu;
        FinishGameMenu.OnRestartGame -= UnloadFinishGameMenu;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick4Button7) || Input.GetKeyDown(KeyCode.Joystick8Button7))
        {
            OnEscapeKeyPressed();
        }
    }

    private void OnEscapeKeyPressed()
    {
        if (GlobalStateManager.Instance.isGameOver)
        {
            return;
        }
        if (_isPaused)
        {
            UnloadPauseMenu();
        }
        else
        {
            LoadPauseMenu();
        }
    }
    
    public void LoadPauseMenu()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }

    public void UnloadPauseMenu()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    private void UnloadFinishGameMenu()
    {
        gameOverMenuUI.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        GlobalStateManager.Instance.ResetState();
        SceneManager.LoadScene("MainMenu");
    }
}
