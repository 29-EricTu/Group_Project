using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool IsGamePause;

    public GameObject Pause_Screen;

    // Start is called before the first frame update
    void Start()
    {
        IsGamePause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IsGamePause = !IsGamePause;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (IsGamePause == true)
        {
            Time.timeScale = 0;
            Pause_Screen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            Pause_Screen.SetActive(false);
        }
    }


    public void MainMenu()
    {
        //Time.timeScale = 1;//
        SceneManager.LoadScene("MenuScene");
    }

    public void ResumeGame()
    {
        IsGamePause = false;
        Time.timeScale = 1;
        Pause_Screen.SetActive(false);
    }

    public void RestartLevel()
    {

        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
