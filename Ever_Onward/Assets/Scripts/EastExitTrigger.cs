using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EastExitTrigger : MonoBehaviour
{
    public GameObject loading;
    public GameObject music;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetString("spawnLoc", "Hub");
            print(PlayerPrefs.GetString("spawnLoc"));
            //loading.SetActive(true);
            //music.SetActive(false);
            SceneManager.LoadSceneAsync(1);
        }


    }
}
