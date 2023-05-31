using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomDoor : MonoBehaviour
{
    //Check if room complete

    private void OnTriggerEnter2D(Collider2D collision) //If player collides, begin next scene in the build JM
    {
        if(collision.tag == "Player")
        {
            DisplayLevel.Instance.LevelCounter++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
