using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPylon1 : MonoBehaviour
{
    private bool isOn = false;
    public GameObject PylonLight;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Light" && !isOn)
        {
            PlayerMovement.LightsOn++;
            isOn = true;
            PylonLight.SetActive(true);
            if(PlayerMovement.LightsOn >= 5)
            {
                print("LITTY");
            }
        }
    }
}
