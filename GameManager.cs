using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayLevelTheme();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }

    public static void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }
    public static void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }

    public static void PlayLevelTheme()
    {
        string levelTheme = null;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                levelTheme = "MenuMusic";
                break;
            case 1:
                levelTheme = "Intro";
                break;
            case 2:
                levelTheme = "Level01";
                break;
            default:
                break;
        }
        FindObjectOfType<AudioManager>().Play(levelTheme);
    }
    public static void StopLevelTheme()
    {
        string levelTheme = null;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                levelTheme = "MenuMusic";
                break;
            case 1:
                levelTheme = "Intro";
                break;
            case 2:
                levelTheme = "Level01";
                break;
            default:
                break;
        }
        FindObjectOfType<AudioManager>().Stop(levelTheme);
    }
}
