using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingRange : MonoBehaviour //all NS
{
    [SerializeField] float DigSpeed; //Saves digspeed set in inspector
    private bool CanDig = true; //checks if enemy can dig
    public GameObject DigRange; //checks if player is in dig range
    public GameObject ToCloseToDig; //checks if enemy is to close to keep digging

    [SerializeField] ParticleSystem EnemyParticle;

    private void Awake()
    {
        DigRange.GetComponent<CircleCollider2D>().enabled = true;
        ToCloseToDig.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //Checks for Ground Enemy 
    {
        if (other.gameObject.tag == "Player") //if collider contacts player begin digging
        {
            StartCoroutine(EnemyDig());
        }
    }

    public IEnumerator EnemyDig() //routine that will be called by GroundEnemyDistance script to cause the enemy to move faster and go invisible
    {
        ToCloseToDig.GetComponent<CircleCollider2D>().enabled = true;

        if (CanDig == true)
        {
            CanDig = false;
            DigRange.GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<EnemyMovement>().speed = 0; //speed = 0
            GetComponent<SpriteRenderer>().enabled = false; //Turn off sprite renderer
            GetComponent<BoxCollider2D>().enabled = false; //Turn off collider
            GetComponentInChildren<Canvas>().enabled = false; //turn off healthbar
            Instantiate(EnemyParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect           
            
            yield return new WaitForSeconds(1.5f);

            EnemyParticle.Stop();
            GetComponent<EnemyMovement>().speed = DigSpeed; //Speed up
            GetComponent<ParticleSystem>().enableEmission = true; // plays particle effect

        }

        else
        {
            GetComponent<EnemyMovement>().speed = 0; //set speed to 0
            GetComponent<ParticleSystem>().enableEmission = false; //Stop Particle Effect
            GetComponent<SpriteRenderer>().enabled = true; //turns on sprite renderer
            GetComponentInChildren<Canvas>().enabled = true; //displays health bar
            GetComponent<BoxCollider2D>().enabled = true; //turns on collider
            yield return new WaitForSeconds(0.2f); //waits for 0.2 seconds
            GetComponent<EnemyMovement>().speed = 1; //sets speed back to 1

            yield return new WaitForSeconds(2); //waits for 2 seconds

            ToCloseToDig.GetComponent<CircleCollider2D>().enabled = false; //turns off to close to dig range collider
            DigRange.GetComponent<CircleCollider2D>().enabled = true; //turns back on dig range collider
            CanDig = true; //can dig is set true
        }
    }
}
