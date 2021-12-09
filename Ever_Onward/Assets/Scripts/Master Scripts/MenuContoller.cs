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
    public void Start()
    {
        optionsMenu = GameObject.Find("Settings");
        playButton = GameObject.Find("Play");
        optionsButton = GameObject.Find("Options");
        quitButton = GameObject.Find("Quit");
        loading = GameObject.Find("Loading");
        music = GameObject.Find("Music");
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        loading.SetActive(!loading.activeSelf);
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
    public void Inventory()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
