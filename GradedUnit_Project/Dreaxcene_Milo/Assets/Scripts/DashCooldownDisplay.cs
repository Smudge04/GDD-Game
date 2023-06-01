using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownDisplay : MonoBehaviour
{
    public Image imageCooldown; //Shows the player the progress
    public float cooldown; //Sets how long the cooldown amount is
    public bool isCooldown; //True or false, wether the player can use the ability

    public static DashCooldownDisplay instance; //Creates an Instance

    private void Awake()
    {
        instance = this; //Creates an Instance
    }

    private void Start()
    {
        imageCooldown.fillAmount = 0; //Sets the image cooldown fill to 0 
    }

    private void FixedUpdate()
    {
        cooldown = VariableStatManager.instance.TimeBtwDash;
    }


    private void Update()
    {
        if (isCooldown) //If isCooldown = true
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime; //overtime will fill the image cooldown to 1

            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0; //If image cooldown = 1, resets image cooldown
                isCooldown = false; //isCooldown resets to being equal to false until used again 
                PlayerMovement.instance.canDash = true;
            }
        }
    }


}

