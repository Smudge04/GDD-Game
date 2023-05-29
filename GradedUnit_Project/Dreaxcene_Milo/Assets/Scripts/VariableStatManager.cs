using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableStatManager : MonoBehaviour //NS
{
    public static VariableStatManager instance = null; 

    [Header("Movement Speed")]
    public float moveSpeed; //Sets player movespeed

    [Header("Dashing")]
    public float dashingTime; //Variable to store how long the dash lasts
    public float TimeBtwDash; //Variable to store the time between each dash

    [Header("Gun")]
    public int BulletAmount;
    public float Spread, BulletSpeed;
    public float FireRate; //variable for fire rate
    public float FiringInterval; //Variable for interval between shots

    [Header("Bullet")]
    public int GunDamage;

    [Header("Health")]
    public int health; //Variable to store players health
    public int numOfHearts; //variable to store the max amount of hearts


    [Header("Upgrade Manager")]
    public int[] AlreadyGot;
    public int Counter = 0;
 

    private void Awake()
    {
        if(instance == null)
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
        health = numOfHearts;

        AlreadyGot[0] = 0;
    }


    public void AddHealth()
    {
        numOfHearts += 3;
        health += 3;
    }

    public void FasterMovement()
    {
        moveSpeed += 2;
        BulletSpeed += 2;
    }

    public void FireRateUp()
    {
        FireRate -= 0.2f;
    }
} //END OF NS
