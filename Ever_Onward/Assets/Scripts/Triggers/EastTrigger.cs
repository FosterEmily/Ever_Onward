using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EastTrigger : MonoBehaviour
{
    public GameObject loading;
    public GameObject music;
    private void Start()
    {
        music = GameObject.Find("Music");
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerPrefs.GetString("isEastDead") == "false")
        {
            PlayerPrefs.SetString("spawnLoc", "East");
            print(PlayerPrefs.GetString("spawnLoc"));
            loading.SetActive(true);
            music.SetActive(false);
            SceneManager.LoadSceneAsync(2);
        }


    }
}
