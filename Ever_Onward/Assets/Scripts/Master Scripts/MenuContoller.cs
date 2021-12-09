using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContoller : MonoBehaviour
{
    GameObject optionsMenu;
    GameObject playButton;
    GameObject optionsButton;
    GameObject quitButton;
    GameObject loading;
    GameObject music;
    GameObject pauseMenu;
    public void Start()
    {
        optionsMenu = GameObject.Find("Settings");
        playButton = GameObject.Find("Play");
        optionsButton = GameObject.Find("Options");
        quitButton = GameObject.Find("Quit");
        loading = GameObject.Find("Loading");
        music = GameObject.Find("Music");
        pauseMenu = GameObject.Find("PauseMenu");
        optionsMenu.SetActive(false);
        loading.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                optionsMenu.SetActive(false);
                if (Time.timeScale == 1)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }
    }
    public void Play()
    {
        loading.SetActive(true);
        music.SetActive(false);
        SceneManager.LoadSceneAsync("Forest");
    }

    public void Options()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        playButton.SetActive(!playButton.activeSelf);
        optionsButton.SetActive(!optionsButton.activeSelf);
        quitButton.SetActive(!quitButton.activeSelf);
    }

    public void InGameOptions()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }
    public void Inventory()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void  Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    public void ToMenu()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        loading.SetActive(true);
        music.SetActive(false);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
