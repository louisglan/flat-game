using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _isPaused;
    public GameObject pauseMenuUI;

    void Start()
    {
        Resume();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscapeKeyPressed();
        }
    }

    private void OnEscapeKeyPressed()
    {
        if (_isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    private void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
