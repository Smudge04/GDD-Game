using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableStatManager : MonoBehaviour //all NS
{
    public static VariableStatManager instance = null; //Creates Instance of the script

    [Header("Movement Speed")]
    public float moveSpeed; //Sets player movespeed

    [Header("Dashing")]
    public float dashingTime; //Variable to store how long the dash lasts
    public float TimeBtwDash; //Variable to store the time between each dash

    [Header("Gun")]
    public int BulletAmount; //Amount of bullets that come out of the gun per shot
    public float Spread, BulletSpeed; //Determines spread and bullet speed
    public float FireRate; //variable for fire rate
    public float FiringInterval; //Variable for interval between shots

    [Header("Bullet")]
    public float GunDamage; //Determines the damage by the gun

    [Header("Health")]
    public int health; //Variable to store players health
    public int numOfHearts; //variable to store the max amount of hearts


    [Header("Upgrade Manager")]
    public int[] AlreadyGot; //Array to store previously gotten upgrades
    public int Counter = 0; //keeps track of the pos in the array
 

    private void Awake()
    {
        if(instance == null) //If statement to make sure there is only on instance of the game manager 
        {
            instance = this;
            DontDestroyOnLoad(base.gameObject);
        }
        else
        {
            Destroy(base.gameObject);
        }
    }

    private void Start()
    {
        health = numOfHearts; //Sets player health to max health on each new run

        AlreadyGot[0] = 0; //Begins array with the number 0 so it can be overwritten
    }


    void Update()
    {
        if (Input.GetKeyDown("space")) //turns on god mode
        {
            print("GOD MODE ENABLED");
            moveSpeed = 6;
            BulletAmount = 6;
            Spread = 1;
            FireRate = 0;
            GunDamage = 10;
            numOfHearts = 6;
            health = 6;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //UPGRADES

    public void AddHealth() //Adds 3 to max health and current health
    {
        numOfHearts += 3;
        health += 3;
    }

    public void FasterMovement() //makes player move faster and also makes bullets slightly faster
    {
        moveSpeed += 2;
        BulletSpeed += 2;
    }

    public void FireRateUp() //Ups the firerate of the player
    {
        FireRate -= 0.2f;
    }

    public void Shotgun() //Turns the gun into a shotgun by changing the amount and spread
    {
        BulletAmount = 3;
        Spread = 0.1f;
        FireRate += 1f;
        GunDamage = 0.5f;
    }
} //END OF NS
