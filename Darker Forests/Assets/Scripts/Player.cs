using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public float health = 50f;
    public Text healthtxt;
    public float foodHealth = 20f;
    public float damage = 0.1f;
    public bool pauseState = false;

    public GameObject pauseMenu;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Enemy")
        {
            TakeDamage(damage);
        }
    }
    // void takeDamage()
    // {
    //     health -= damageTaken;
    //     HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.01f);

    //     healthtxt.text = health.ToString();
    // }
    void AddHealth()
    {
        health += foodHealth;
        if (health > 100f)
        {
            health = 100f;
        }
        HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() + 0.2f);

        healthtxt.text = health.ToString("f0");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - (damage / 100));

        healthtxt.text = health.ToString("f0");
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Debug.Log(item.item);
            Destroy(other.gameObject);
        }
    }
    // private void onApplicationQuit()
    // {
    //     inventory.container.Clear();
    // }
    void awake()
    {
        HealthBarHandler.SetHealthBarValue(0);
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseState = !pauseState;
            if (!pauseState) Cursor.lockState = CursorLockMode.Locked;
        }
        if (pauseState)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
        }
        if (health < 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync(3);
        }
        health -= 0.001f;
        HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.00001f);
        healthtxt.text = health.ToString("f0");
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (inventory.GetAmount(0) > 0)
            {
                AddHealth();
                inventory.RemoveItem(0);
            }
        }
    }
}
