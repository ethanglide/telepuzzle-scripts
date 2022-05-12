using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject sensSlider;
    public GameObject sensNumber;
    public GameObject invertToggle;

    public static bool isPaused;

    public static KeyCode fire1 = KeyCode.Mouse0;
    public static KeyCode fire2 = KeyCode.Mouse1;

    // Start is called before the first frame update
    void Start()
    {
        //pauseMenu.SetActive(false);
        //optionsMenu.SetActive(false);
        Debug.Log(MouseLook.mouseSensitivity);

        sensSlider.GetComponent<Slider>().value = MouseLook.mouseSensitivity;
        sensNumber.GetComponent<TMP_Text>().text = MouseLook.mouseSensitivity.ToString();

        if (fire1 == KeyCode.Mouse0)
        {
            invertToggle.GetComponent<Toggle>().isOn = false;
        }
        else
        {
            invertToggle.GetComponent<Toggle>().isOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }           
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public static void WinLevel()
    {
        Cursor.lockState = CursorLockMode.Confined;
        
        foreach (var item in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (item.name == "WinMenu")
            {
                item.SetActive(true);
            }
            else if (item.name == "EndTimer")
            {
                item.GetComponent<TMP_Text>().text = string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(Timer.time / 60), Mathf.FloorToInt(Timer.time % 60), Timer.time % 1 * 1000);
            }
            else if (item.name == "Crosshair" || item.name == "Timer" || item.name == "Message")
            {
                item.SetActive(false);
            }
        }

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void SetSensitivity(float sens)
    {
        MouseLook.mouseSensitivity = sens;
        sensNumber.GetComponent<TMP_Text>().text = sens.ToString();
    }

    public void InvertFire(bool inverted)
    {
        if (inverted)
        {
            fire1 = KeyCode.Mouse1;
            fire2 = KeyCode.Mouse0;
        }
        else
        {
            fire1 = KeyCode.Mouse0;
            fire2 = KeyCode.Mouse1;
        }
    }
}
