using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
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
        if (IsPaused)
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
        IsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    private void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loading Screen");
    }
}
