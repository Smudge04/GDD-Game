using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour //NS
{
    [SerializeField] private float health, maxHealth; //Variable to store enemy health, allows for each enemy to have a different health

    [SerializeField] FloatingHealthBar healthBar;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage; //Take damage equal to bullet damage
        healthBar.UpdateHealthBar(health, maxHealth);
        Debug.Log(health); //shows enemy health on debug log

        if (health <= 0) //If enemy dies
        {
            Destroy(gameObject); //Destroy this object
        }
    }


}

