using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject timer;
    private TimerScript timerScript;

    private void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
    }
    private void Update()
    {
        // Pause menu
        if (Input.GetKeyDown(KeyCode.Escape) && !TakeDamageHandler.IsDead)
        {
            if (GameIsPaused)
            {
                timerScript.timerActive = true;
                Resume();
            }
            else
            {
                timerScript.timerActive = false;
                Pause();
            }
        }
    }

    public void Resume()
    {
        timerScript.timerActive = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
