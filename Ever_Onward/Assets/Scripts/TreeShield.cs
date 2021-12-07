using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShield : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ByeByeTreeShield());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ByeByeTreeShield()
    {
        yield return new WaitForSeconds(8f);
        anim.SetBool("isShrinking", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
