using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBackScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // If player collides with box (door) begin check for the previous scene NS
    {
        if(collision.tag == "Player")
        {
            SceneChange.instance.PreviousScene();
        }
    }
}
