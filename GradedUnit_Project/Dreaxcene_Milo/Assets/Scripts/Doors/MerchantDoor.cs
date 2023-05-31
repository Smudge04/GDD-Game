using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerchantDoor : MonoBehaviour //NS
{
    private void FixedUpdate()
    {
        if(EnemiesInRoomCounter.instance.EnemyCount == 0)
        {
            GetComponent<SpriteRenderer>().enabled = true; //Sprite renderer on
            GetComponent<BoxCollider2D>().enabled = true; //Collider on
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //If player collides, change scene to Merchant room NS
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Merchant_Room");
        }
    }
}
