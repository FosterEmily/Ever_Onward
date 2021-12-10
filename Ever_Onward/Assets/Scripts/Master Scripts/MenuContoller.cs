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
    GameObject mainMenu;
    GameObject pauseText;
    GameObject controlButton;
    GameObject creditButton;
    GameObject controlsPopUp;
    GameObject creditsPopUp;
    public void Start()
    {
        optionsMenu = GameObject.Find("Settings");
        playButton = GameObject.Find("Play");
        optionsButton = GameObject.Find("Options");
        quitButton = GameObject.Find("Quit");
        loading = GameObject.Find("Loading");
        music = GameObject.Find("Music");
        pauseMenu = GameObject.Find("PauseMenu");
        mainMenu = GameObject.Find("MainMenu");
        pauseText = GameObject.Find("Pause");
        controlButton = GameObject.Find("Controls");
        creditButton = GameObject.Find("Credits");
        controlsPopUp = GameObject.Find("ControlsPopUp");
        creditsPopUp = GameObject.Find("CreditsPopUp");
        optionsMenu.SetActive(false);
        loading.SetActive(false);
        if (pauseMenu != null) pauseMenu.SetActive(false);
        if (controlsPopUp != null) controlsPopUp.SetActive(false);
        if (creditsPopUp != null) creditsPopUp.SetActive(false);
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
        creditButton.SetActive(!creditButton.activeSelf);
        controlButton.SetActive(!controlButton.activeSelf);
    }

    public void Controls()
    {
        controlsPopUp.SetActive(!controlsPopUp.activeSelf);
        playButton.SetActive(!playButton.activeSelf);
        optionsButton.SetActive(!optionsButton.activeSelf);
        quitButton.SetActive(!quitButton.activeSelf);
        creditButton.SetActive(!creditButton.activeSelf);
        controlButton.SetActive(!controlButton.activeSelf);
    }

    public void Credits()
    {
        creditsPopUp.SetActive(!creditsPopUp.activeSelf);
        playButton.SetActive(!playButton.activeSelf);
        optionsButton.SetActive(!optionsButton.activeSelf);
        quitButton.SetActive(!quitButton.activeSelf);
        creditButton.SetActive(!creditButton.activeSelf);
        controlButton.SetActive(!controlButton.activeSelf);
    }

    public void InGameOptions()
    {
        mainMenu.SetActive(!mainMenu.activeSelf);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        playButton.SetActive(!playButton.activeSelf);
        optionsButton.SetActive(!optionsButton.activeSelf);
        quitButton.SetActive(!quitButton.activeSelf);
        pauseText.SetActive(!pauseText.activeSelf);
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
