using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour //all NS
{
    [SerializeField] private float health, maxHealth; //Variable to store enemy health, allows for each enemy to have a different health

    [SerializeField] FloatingHealthBar healthBar; //stores canvas slider

    public static EnemyHealth instance; //creates instance

    public GameObject EnemyDeathEffect; //stores death effect

    private void Start()
    {
        health = maxHealth; //Sets current health to max health
        healthBar.UpdateHealthBar(health, maxHealth); //Changes it on the update health bar script

        instance = this;
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>(); //gets the health bar object stored as a child
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage; //Take damage equal to bullet damage
        healthBar.UpdateHealthBar(health, maxHealth); //Changes in seperate script to change the visual
        Debug.Log(health); //shows enemy health on debug log

        if (health <= 0) //If enemy dies
        {
            Destroy(gameObject); //Destroy this object
            Instantiate(EnemyDeathEffect, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect
        }
    }

    public void DespawnEnemies()
    {
        this.gameObject.SetActive(false); //If player dies, despawns all enemies
    }
}

