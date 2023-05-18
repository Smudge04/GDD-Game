using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance; //NS all code for player movement

    public float moveSpeed; //Sets player movespeed
    private float SavedSpeed; //Returns player to original speed

    public Rigidbody2D rb; //Variable to store player rigidbody

    Vector2 movement; //Movement Vector

    public Animator animator;//Varible to store the animator - JM


    public GameObject TopRightLimitGameObject; //Variable to store the game object for the border of the screen (top right)
    public GameObject BottomLeftLimitGameObject; //Variable to store the game object for the border of the screen (Bottom Left)

    private Vector3 TopRightLimit; //Variable to store the position of the Top right limit
    private Vector3 BottomLeftLimit; //Variable to store the position of the Bottom Left Limit

    [Header("Dashing")]
    public bool canDash = true; //Variable to check if player can dash
    public float dashingTime; //Variable to store how long the dash lasts
    public float dashSpeed; //Variable to store the speed of the dash
    public float TimeBtwDash; //Variable to store the time between each dash


    private void Awake()
    {
        instance = this; //Creates and instance of the script
    }

    private void Start()
    {
        TopRightLimit = TopRightLimitGameObject.transform.position; //Stores game object position into variable
        BottomLeftLimit = BottomLeftLimitGameObject.transform.position; //Stores game object position into variable

        SavedSpeed = moveSpeed;   
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //Gets player input for horizontal movement 
        movement.y = Input.GetAxisRaw("Vertical"); //Gets player input for vertical movement       

        animator.SetFloat("Horizontal", movement.x);//the vertical animation will play in the animator in unity and depending if its up or down will play up or down animation - JM
        animator.SetFloat("Vertical", movement.y);//the horizontal animation will play in the animator in unity and depending if its left or right will play left or right animation - JM
        animator.SetFloat("speed", movement.magnitude);//if the player moves at all the animator will know not to play idle animation - JM

        if ((transform.position.x <= BottomLeftLimit.x && movement.x == -1) || (transform.position.x >= TopRightLimit.x && movement.x == 1)) //checks if player is in confines of horizontal limit
        {
            movement.x = 0; //if not then stop player movement horizontally
        }

        if ((transform.position.y <= BottomLeftLimit.y && movement.y == -1) || (transform.position.y >= TopRightLimit.y && movement.y == 1)) //checks if player is in confines of Veritcal limit
        {
            movement.y = 0; //if not then stop player movement Vertically
        }

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
        moveSpeed = SavedSpeed; //Returns move speed to original speed
        yield return new WaitForSeconds(TimeBtwDash); //Waits for length of time between dash
        canDash = true; //Player can now dash again
    }
}
