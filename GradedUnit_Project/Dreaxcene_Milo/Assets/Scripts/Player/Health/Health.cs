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
    }
}
