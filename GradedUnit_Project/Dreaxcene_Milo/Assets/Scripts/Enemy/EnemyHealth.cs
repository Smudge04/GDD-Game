using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health, maxHealth; //Variable to store enemy health, allows for each enemy to have a different health

    private void FixedUpdate() //NS
    {

        if (health <= 0) //If enemy dies
        {
            Destroy(gameObject); //Destroy this object
        }
    }

    public void TakeDamage(int Damage)
    {
        health -= Damage; //Take damage equal to bullet damage
        Debug.Log(health); //shows enemy health on debug log
    }


}

