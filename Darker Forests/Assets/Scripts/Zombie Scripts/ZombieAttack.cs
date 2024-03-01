using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    Transform player;
    public float dist;
    public float triggerDistance;
    public Transform enemy;
    public float speed = 1f;
    public Animator animator;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        dist = Vector3.Distance(player.position, transform.position);
        if (dist <= triggerDistance)
        {
            enemy.LookAt(player);
            transform.LookAt(player);

            var delta = player.transform.position - transform.position;
            delta.Normalize();

            var moveSpeed = speed * Time.deltaTime;
            animator.SetFloat("zombie_speed", speed);

            transform.position = transform.position + (delta * moveSpeed);
        }
        else
        {
            animator.SetFloat("zombie_speed", 0f);

        }
    }

}
