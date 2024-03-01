using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float health = 30f;
    public GameObject gameObject;
    public ParticleSystem exp;
    public ParticleSystem death;
    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        exp.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        exp.Stop();
        death.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            death.Play();
            Destroy(gameObject, 1);
        }
    }
}
