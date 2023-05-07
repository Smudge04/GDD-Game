using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] //allows for each enemy to have a different health
    private float health; //Variable to store enemy health

    private void Update()
    {

        if (health < 1) //If enemy dies
        {
            Destroy(gameObject); //Destroy this object
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") //If enemy collides with bullet
        {
            health--; //remove 1 from health
            Destroy(other.gameObject); //destroy bullet game object
        }
    }
}

