using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MerchantDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) //If player collides, change scene to Merchant room NS
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Merchant_Room");
        }

    }
}
