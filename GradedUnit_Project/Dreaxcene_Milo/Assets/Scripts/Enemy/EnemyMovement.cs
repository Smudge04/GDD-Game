using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour //NS
{
    [SerializeField]
    public float speed; // Variable for speed

    private Transform playerPos; //variable that stores where the player is

    Vector2 PlayerDir; //Variable that the direction the player is in for the enemy to follow

    [SerializeField]
    private float repelRange; //Stores the distance an enemy can get before they can no longer move forward

    [SerializeField] ParticleSystem EnemyParticle;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform; //Finds object with tag player and its location and stores it within playerPos 
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > repelRange) //If enemy is further than repel distance, enemy will move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
 

        Vector2 targetPos = playerPos.transform.position; //Enemy will target the position of the player
       
        transform.up = PlayerDir;
    }
}
