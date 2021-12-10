using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestBossTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject rDoor;
    Vector3 westBossSpawn;
    void Start()
    {
        westBossSpawn = GameObject.Find("WestBossSpawn").transform.position;
        rDoor = GameObject.Find("RDoor");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player") && PlayerMovement.LightsOn >= 5)
        {
            Destroy(rDoor);
        }
    }

}
