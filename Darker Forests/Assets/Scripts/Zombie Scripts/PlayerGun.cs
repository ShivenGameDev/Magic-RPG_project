using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 10000f;

    public Camera fpsCam;
    private float counter = 0f;
    public float targetTime = 0.1f;
    private bool flag = false;

    public float manaCount = 0f;
    public InventoryObject inventory;
    float DistanceOfLaser;
    public GameObject bullet;
    public ParticleSystem slash;
    public void SpawnBullet(Vector3 start, Vector3 end, float duration)
    {
        GameObject bulletGameObject = Instantiate(bullet, start, transform.rotation);
        Bullet bulletComponent = bulletGameObject.AddComponent<Bullet>();
        bulletComponent.SetValues(start, end, duration);
    }
    float Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            //Debug.Log(hit.transform);
            //Debug.Log(hit.distance);
            SpawnBullet(fpsCam.transform.position, hit.transform.position, 0.5f);
            ZombieHealth zombie = hit.transform.GetComponentInParent<ZombieHealth>();
            if (zombie != null)
            {

                zombie.takeDamage(damage);
            }

            return (hit.distance);
        }
        return 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (flag && counter < targetTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            flag = false;
            counter = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (inventory.GetAmount(1) > 0)
            {
                manaCount -= 1;
                slash.Play();
                //Debug.Log(manaCount);
                inventory.RemoveItem(1);
                DistanceOfLaser = Shoot();
                if (counter < targetTime)
                {
                    flag = true;

                }
            }
        }
    }
}
