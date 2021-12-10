using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject loading;
    public GameObject music;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.Find("Music");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PlayerPrefs.GetString("isEastDead") == "true" && PlayerPrefs.GetString("isWestDead") == "true")
        {
            //PlayerPrefs.SetString("spawnLoc", "East");
            //print(PlayerPrefs.GetString("spawnLoc"));
            loading.SetActive(true);
            music.SetActive(false);
            SceneManager.LoadSceneAsync(0);
        }


    }
}
