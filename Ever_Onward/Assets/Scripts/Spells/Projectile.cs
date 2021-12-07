using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector3 velocity;
    public GameObject TreeShield;
    private float lifeSpan = 3;
    private float age = 0;
    private bool isGrass = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void InitBullet(Vector3 vel)
    {
        velocity = vel;
    }

    private void Update()
    {
        age += Time.deltaTime;

        if(age > lifeSpan)
        {
            Destroy(gameObject);
        }

        transform.position += velocity * 3 * Time.deltaTime;

        //if()
    }
    void OnTriggerEnter(Collider other)
    {
        if (this.tag == "Grass" && other.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(TreeShield, transform.position, transform.rotation);
        }
        else
        {
            Destroy(gameObject, 0.01f);
        }
    }
}
