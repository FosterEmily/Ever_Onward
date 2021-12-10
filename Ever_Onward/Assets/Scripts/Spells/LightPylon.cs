using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPylon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Light")
        {
            //anim.SetBool("isWilted", false);
            //rend.material.color = Color.red;
            Invoke("SetAddCollision", 2f);
            Invoke("DisableCollision", 15f);
        }
    }
}
