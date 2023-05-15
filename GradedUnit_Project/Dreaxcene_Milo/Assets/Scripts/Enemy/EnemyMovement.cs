using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    public float speed; // Variable for speed

    private Transform playerPos; //variable that stores where the player is

    Vector2 PlayerDir; //Variable that the direction the player is in for the enemy to follow
    private Rigidbody2D rb; //A vriable that stores enemy RigidBody when enemy is spawned

    [SerializeField]
    private float repelRange; //Stores the distance an enemy can get before they can no longer move forward

    [SerializeField] ParticleSystem EnemyParticle;

    [SerializeField] float DigSpeed = 3;
    private bool CanDig = true;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform; //Finds object with tag player and its location and stores it within playerPos
        rb = GetComponent<Rigidbody2D>();  //Gets enemy rigidbody
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, playerPos.position) > repelRange) //If enemy is further than repel distance, enemy will move towards the player
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        Vector2 targetPos = playerPos.transform.position; //Enemy will target the position of the player
       
        transform.up = PlayerDir;

    }

    private void OnTriggerEnter2D(Collider2D other) //Checks for Ground Enemy NS
    {
        switch (other.gameObject.tag) //Checks for objects tags
        {
            case "Player":
                StartCoroutine(EnemyDig()); //Begin Digging
                break;
            case "DigRange":
                StartCoroutine(StopDigging()); //Stop digging
                break;
        }
    }

    public IEnumerator EnemyDig() //routine that will be called by GroundEnemyDistance script to cause the enemy to move faster and go invisible
    {
        if (CanDig)
        {
            CanDig = false;
            speed = 0;
            GetComponent<SpriteRenderer>().enabled = false; //Turn off sprite renderer
            GetComponent<BoxCollider2D>().enabled = false; //Turn off collider
            GetComponentInChildren<Canvas>().enabled = false; //turn off healthbar
            Instantiate(EnemyParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect           
            yield return new WaitForSeconds(1.5f);
            EnemyParticle.Stop();
            speed = DigSpeed; //Speed up
            GetComponent<ParticleSystem>().enableEmission = true;
        }      
    }

    public IEnumerator StopDigging() //Stops ground enemy attacking
    {
        speed = 0;
        GetComponent<ParticleSystem>().enableEmission = false; //Stop Particle Effect
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponentInChildren<Canvas>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        speed = 1;

        yield return new WaitForSeconds(1.5f);
        CanDig = true;

    }
}
