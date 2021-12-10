using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("spawnLoc", "Hub");
        PlayerPrefs.SetString("isWestDead", "false");
        PlayerPrefs.SetString("isEastDead", "false");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
