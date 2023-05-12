using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour //ns all code
{
    public int health; //Variable to store players health
    public int numOfHearts; //variable to store the max amount of hearts 

    public Image[] hearts; //array to store all heart UI objects
    public Sprite FullHeart; //stores the sprite for a full heart
    public Sprite emptyHeart; //stores the sprite for the empty heart

    private bool Hit = true; //Bool to check if player can be hit
    private Animator anim; //variable for player animation

    public GameObject PlayerDeathParticle;


    private void Start()
    {
        anim = GetComponent<Animator>(); //Gets animator component
    }
   
    private void Update()
    {
        if(health > numOfHearts) //if loop to check if players health is greater than the number of hearts
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) //i is equal to the length of players hearts
        {
            if(i < health) //if that length is greeater than health
            {
                hearts[i].sprite = FullHeart; //that heart within the array is full
            }
            else
            {
                hearts[i].sprite = emptyHeart; //if not then it is set to empty
            }

            if(i < numOfHearts) //if and else statment set the length of the hearts
            {
                hearts[i].enabled = true; 
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        if(health <= 0) //if player is dead
        {
            StartCoroutine(PlayerDeath()); //start death Coroutine
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Hit) //if player has not been hit then
        {
            if (other.tag == "Enemy") //If player collides with enemy
            {
                StartCoroutine(HitBoxOff()); //Turns off player hitbox
                health--; //remove 1 from health
            }
        }
    }

    IEnumerator HitBoxOff() //Function to turn off players hit box
    {
        if(health > 1) //if player health greater than 1
        {
            Hit = false; //Bool set to false so player can't be hit
            anim.SetTrigger("Hit"); //Plays animation to let player know they can't be hit
            yield return new WaitForSeconds(1f); //the player has 1.6 seconds they cant be hit
            Hit = true; //hit = true
        }
    }

    IEnumerator PlayerDeath()
    {
        PlayerMovement.instance.enabled = false; //stop player movement script
        //Stop Gun Script
        EnemyHealth.instance.DespawnEnemies();
        yield return new WaitForSeconds(1); //wait 1 second
        gameObject.SetActive(false);
        Instantiate(PlayerDeathParticle, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); //play particle effect
        //Game over
    }
}
