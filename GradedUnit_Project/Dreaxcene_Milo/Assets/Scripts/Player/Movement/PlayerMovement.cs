using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance; //NS lines 7-60

    public float moveSpeed = 5f; //Sets player movespeed

    public Rigidbody2D rb; //Variable to store player rigidbody

    Vector2 movement; //Movement Vector

    [Header("Dashing")]
    public bool canDash = true; //Variable to check if player can dash
    public float dashingTime; //Variable to store how long the dash lasts
    public float dashSpeed; //Variable to store the speed of the dash
    public float TimeBtwDash; //Variable to store the time between each dash

    private void Awake()
    {
        instance = this; //Creates and instance of the script
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //Gets player input for horizontal movement 
        movement.y = Input.GetAxisRaw("Vertical"); //Gets player input for vertical movement       

        if (Input.GetKeyDown(KeyCode.Mouse1)) //If player right clicks
        {
            DashAbility(); //Begin dash function
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //determins player movement based on position, movement speed and time

    }

    private void DashAbility()
    {
        if (canDash) //If can dash equals true
        {
            StartCoroutine(Dash()); //Starts coroutine to Dash
        }
    }
    IEnumerator Dash()
    {
        canDash = false; //Sets can dash to false

        moveSpeed = dashSpeed; //Move speed is increased to the number set within dash speed variable

        yield return new WaitForSeconds(dashingTime); //Waits for length of dash
        moveSpeed = 5; //Returns move speed to original speed
        yield return new WaitForSeconds(TimeBtwDash); //Waits for length of time between dash
        canDash = true; //Player can now dash again
    }
}
